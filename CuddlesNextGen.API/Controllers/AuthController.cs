using CuddlesNextGen.API.DataModel;
using CuddlesNextGen.API.Extensions.Exceptions;
using CuddlesNextGen.Application.Permissions.Query;
using CuddlesNextGen.Application.Service;
using CuddlesNextGen.Application.UserAuth.ChangePassword.Command;
using CuddlesNextGen.Application.UserAuth.ResetPassword.Command;
using CuddlesNextGen.Application.UserAuth.ResetPassword.Queries;
using CuddlesNextGen.Application.UserAuth.UserLogin.Queries;
using CuddlesNextGen.Application.UserAuth.UserPermissions.Queries;
using CuddlesNextGen.Application.UserLogin.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CuddlesNextGen.API.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/V{v:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;
        private readonly IIdentityService _identityService;
        private readonly ICustomMessageService _customMsgSvc;
        // private readonly IBus _bus;
        private readonly IConfiguration _config;
        //  private readonly ITemplateMapper _templateMapper;

        public AuthController(IMediator mediator, IIdentityService identityService, ILogger<AuthController> logger, ICustomMessageService customMsgSvc, IConfiguration config) //IBus bus, , ITemplateMapper templateMapper)
        {
            _logger = logger;
            _mediator = mediator;
            _identityService = identityService;
            _customMsgSvc = customMsgSvc;
            //  _bus = bus;
            _config = config;
            //   _templateMapper = templateMapper;
        }

        #region API CONTROLLER METHODS

        /// <summary>
        /// API Authenticates the user by user name and password
        /// </summary>
        /// <param name="userCredential"> This dto is used to take username and password </param>
        /// <returns> UserAuthProfile dto having user information </returns>

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBase<UserAuthResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Authenticate(AuthReq authReq)
        {
            UserAuthResponse userAuthResponse = new UserAuthResponse();
            //Send query to get user details
            UserCredentialDto userCredential = await _mediator.Send(new GetUserAuthQuery { user_name = authReq.user_name  });
            if (userCredential == null)
                throw new UnauthorizedAccessException("Cuddle_AUTHENTICATION_FAILED");

           // return new OkObjectResult(userCredential);
            /* if (userCredential.is_active == true)
             {*/
             if (_identityService.ValidatePassword(authReq.password, userCredential.password_hash))
             {
                 //Populate User Profile Details
                 userAuthResponse.user = new UserDetailsDto
                 {
                     id = userCredential.id,
                     contact_id = userCredential.contact_id,
                     user_name = userCredential.user_name,
                     email = userCredential.email,
                     full_name = userCredential.full_name,
                     profile_image = userCredential.profile_image,
                     account_id = userCredential.account_id,
                     account_type_id = userCredential.account_type_id,
                     account_name = userCredential.account_name,
                     contact_type = userCredential.contact_type,
                     last_login_on = userCredential.last_login_on
                 };
                 return new OkObjectResult(userAuthResponse);
             }
             else
             {
                 throw new UnauthorizedAccessException("CUDDLE_AUTHENTICATION_FAILED");
             }

            //Send query to get user permissions
            /* userAuthResponse.userPermissions = await _mediator.Send(new GetUserPermisssionQuery { user_name = authReq.user_name });


                 if (userAuthResponse.userPermissions?.Count > 0)
                 {
                     //Flatten permissions into a comma seperated string. In future move away from names to hexcode
                     string permissionSet = userAuthResponse.userPermissions.Count > 0 ? string.Join(",", userAuthResponse.userPermissions.Select(x => x.permission_name).Distinct()) : string.Empty;
                     //Flatten roles into a comma seperated string. In future move away from names to hexcode
                     string roleset = userAuthResponse.userPermissions.Count > 0 ? string.Join(",", userAuthResponse.userPermissions.Select(x => x.role_id).Distinct()) : string.Empty;
                     //Generate JWT Auth Token
                     userAuthResponse.authToken = _identityService.GenerateSecurityToken(userAuthResponse.user.id.ToString(), userAuthResponse.user.user_name, roleset, permissionSet, userCredential.contact_type_id, userCredential.account_id, userCredential.account_type_id, "", "");
                     //Send query to get user preferences
                     userAuthResponse.userPersonalizedSetting = await _mediator.Send(new GetUserPersonalizedCategoryByUserIdQuery { user_id = userCredential.id });

                     ResponseBase<UserAuthResponse> response = new ResponseBase<UserAuthResponse>();
                     response.Data = userAuthResponse;
                     return new OkObjectResult(response);
                 }
                 else
                 {
                     throw new UnauthorizedAccessException("PARS_NO_PERMISSION");
                 }
             }
             else
             {
                 throw new UnauthorizedAccessException("PARS_AUTHENTICATION_FAILED");
             }
         }
         else
         {
             throw new UnauthorizedAccessException("PARS_INACTIVE_USER");
         }*/
        }




        /// <summary>
        /// API sends an email message to user for password reset
        /// </summary>
        /// <param name="userName"> User name </param>
        /// <returns> Password reset token </returns>

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBase<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ForgotPassword(string userName)
        {
            ResponseBase<string> response = new ResponseBase<string>();
            var userDetail = await _mediator.Send(new GetUserAuthQuery { user_name = userName });
            if (userDetail == null)
            {
                throw new UnauthorizedAccessException("PARS_INVALID_EMAIL");
            }
            else
            {
                var resetPasswordToken = await _mediator.Send(new ResetPasswordCommand { user_id = userDetail.id });
                if (string.IsNullOrWhiteSpace(resetPasswordToken))
                {
                    throw new BusinessException("PARS_FORGOT_PASSWORD_FAILURE");
                }
                else
                {
                    ResetPasswordNotification resetPasswordReq = new ResetPasswordNotification();
                    resetPasswordReq.user_id = userDetail.id;
                    resetPasswordReq.full_name = userDetail.full_name;
                    resetPasswordReq.email = userDetail.email;
                    resetPasswordReq.reset_password_token = resetPasswordToken;
                    resetPasswordReq.base_url = _config["appSettings:WebAppBaseURI"];
                    /*
                                        MergedContent emailTemplateContent = await _templateMapper.MergeTemplateByCode<ResetPasswordNotification>("RESET_PASSWORD_EMAIL_TEMPLATE", resetPasswordReq);

                                        //Publish send email event for sending reset password link to user.
                                        SendEmail emailMessage = new SendEmail
                                        {
                                            ToPartyEmails = new List<string>(new[] { userName }),
                                            Subject = emailTemplateContent.subject,
                                            MessageBody = emailTemplateContent.body_text,
                                            IsMessageHTML = emailTemplateContent.body_text.EndsWith("</html>", StringComparison.OrdinalIgnoreCase)
                                        };

                                        await _bus.Publish(emailMessage);
                    */
                }

                response.Data = "True";
                response.MessageDetail = _customMsgSvc.GetCustomMessageByShortCode("PARS_FORGOT_PASSWORD_SUCCESS");
                return new OkObjectResult(response);
            }
        }
    


    /// <summary>
    /// API resets the password 
    /// </summary>
    /// <param name="userId"> User id </param>
    /// <param name="newPassword"> New Password </param>
    /// <returns> User details for reset token. </returns>

    /*  [HttpPost]
      [ProducesResponseType(typeof(ResponseBase<ResetPasswordDto>), StatusCodes.Status200OK)]
      public async Task<IActionResult> ResetPassword(ResetPasswordReq resetPasswordReq)
      {
          ResponseBase<ResetPasswordDto> response = new ResponseBase<ResetPasswordDto>();
          var userDetailByResetToken = await _mediator.Send(new ResetPasswordRequestQuery { reset_request_id = resetPasswordReq.reset_password_token });
          //USER existence check
          if (userDetailByResetToken != null)
          {
              //Reset Token
              var resetToken = userDetailByResetToken.password_reset_token;
              if (resetToken != Guid.Empty)
              {
                  //Token expiry time check
                  var tokenExpiry = DateTime.UtcNow - userDetailByResetToken.password_reset_on;
                  if (tokenExpiry.Hours <= 23)
                  {
                      //New Password Hash created
                      var passwordHash = _identityService.CreatePasswordHash(resetPasswordReq.new_password);
                      var isUpdateSuccessful = await _mediator.Send(new ChangePasswordCommand { user_id = userDetailByResetToken.id, new_password = passwordHash });
                      if (isUpdateSuccessful)
                      {
                          response.Data = userDetailByResetToken;
                          response.MessageDetail = _customMsgSvc.GetCustomMessageByShortCode("PARS_RESET_PASSWORD_SUCCESS");
                          return new OkObjectResult(response);
                      }
                      else
                      {
                          throw new BusinessException("PARS_RESET_PASSWORD_FAILURE");
                      }
                  }
                  else
                  {
                      throw new Exception("PARS_RESET_PASSWORD_LINK_EXPIRED");
                  }
              }
              else
              {
                  throw new Exception("PARS_INVALID_PASSWORD_REQUEST");
              }
          }
          else
          {
              throw new Exception("PARS_INVALID_PASSWORD_REQUEST");
          }

      }


*/
    /// <summary>
    ///API is used to change the Password
    /// </summary>
    /// <param name="userId"> User id </param>
    /// <param name="newPassword"> New Password </param>
    /// <returns></returns>

    /*  [HttpPost]
      [ProducesResponseType(typeof(ResponseBase<long>), StatusCodes.Status200OK)]
      public async Task<IActionResult> ChangePassword(ChangePasswordReq changePasswordReq)
      {
          ResponseBase<long> response = new ResponseBase<long>();
          var newPasswordHash = _identityService.CreatePasswordHash(changePasswordReq.password);
          bool isUpdateSuccessful = await _mediator.Send(new ChangePasswordCommand { user_id = changePasswordReq.user_id, new_password = newPasswordHash });
          if (isUpdateSuccessful)
          {
              response.Data = changePasswordReq.user_id;
              response.MessageDetail = _customMsgSvc.GetCustomMessageByShortCode("PARS_CHANGE_PASSWORD_SUCCESS");
              return new OkObjectResult(response);
          }
          else
          {
              throw new BusinessException("PARS_CHANGE_PASSWORD_FAILURE");
          }
      }
*/


    /// <summary>
    /// API generates new password for User 
    /// </summary>
    /// <param name="userName"> User name </param>
    /// <param name="password"> Password </param>
    /// <returns></returns>

    /*  [HttpPost]
      [ProducesResponseType(typeof(ResponseBase<long>), StatusCodes.Status200OK)]
      public async Task<IActionResult> GenerateNewUserPassword(AuthReq authReq)
      {
          ResponseBase<long> response = new ResponseBase<long>();
          //Create new hash for password
          var passwordHash = _identityService.CreatePasswordHash(authReq.password);
          //get user of this user name
          var userDetails = await _mediator.Send(new GetUserAuthQuery { user_name = authReq.user_name });
          if (userDetails != null)
          {
              var isUpdateSuccessful = await _mediator.Send(new ChangePasswordCommand { user_id = userDetails.id, new_password = passwordHash });
              if (isUpdateSuccessful)
              {
                  response.Data = userDetails.id;
                  response.MessageDetail = _customMsgSvc.GetCustomMessageByShortCode("PARS_CHANGE_PASSWORD_SUCCESS");
                  return new OkObjectResult(response);
              }
              else
              {
                  throw new BusinessException("PARS_CHANGE_PASSWORD_FAILURE");
              }
          }
          else
          {
              throw new Exception("PARS_INVALID_USER");
          }
      }
*/


    /// <summary>
    /// API gets Acccess Token for User
    /// </summary>
    /// <param name="username"> Username </param>
    /// <returns> Authentication Token </returns>

    /*        [HttpPost]
            [ProducesResponseType(typeof(ResponseBase<AuthToken>), StatusCodes.Status200OK)]
            public async Task<IActionResult> GetAccessToken(AuthReq authReq)
            {
                ResponseBase<AuthToken> response = new ResponseBase<AuthToken>();
                UserAuthResponse userAuthResponse = new UserAuthResponse();

                //Send query to get user details
                UserCredentialDto userCredential = await _mediator.Send(new GetUserAuthQuery { user_name = authReq.user_name });
                if (userCredential == null)
                    throw new BusinessException("PARS_RECORD_NOT_FOUND");
                //Send query to get user permissions
                var userPermission = await _mediator.Send(new GetUserPermisssionQuery { user_name = authReq.user_name });
                userAuthResponse.user = new UserDetailsDto
                {
                    id = userCredential.id,
                    contact_id = userCredential.contact_id,
                    user_name = userCredential.user_name,
                    email = userCredential.email,
                    full_name = userCredential.full_name,
                    profile_image = userCredential.profile_image,
                    account_id = userCredential.account_id,
                    account_name = userCredential.account_name,
                    contact_type = userCredential.contact_type,
                    last_login_on = userCredential.last_login_on
                };

                if (userCredential.is_active == true)
                {
                    if (_identityService.ValidatePassword(authReq.password, userCredential.password_hash))
                    {
                        if (userPermission?.Count > 0)
                        {
                            //Flatten permissions into a comma seperated string. In future move away from names to hexcode
                            string permissionSet = userPermission?.Count > 0 ? string.Join(",", userPermission.Select(x => x.permission_name).Distinct()) : string.Empty;
                            //Flatten roles into a comma seperated string. In future move away from names to hexcode
                            string roleset = userPermission.Count > 0 ? string.Join(",", userPermission.Select(x => x.role_id).Distinct()) : string.Empty;

                            var authToken = _identityService.GenerateSecurityToken(userAuthResponse.user.id.ToString(), userAuthResponse.user.user_name, roleset, permissionSet, 1, userCredential.account_id, 1, "", "");

                            response.Data = authToken;
                            return new OkObjectResult(response);
                        }
                        else
                        {
                            throw new UnauthorizedAccessException("PARS_NO_PERMISSION");
                        }
                    }
                    else
                    {
                        throw new UnauthorizedAccessException("PARS_AUTHENTICATION_FAILED");
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("PARS_INACTIVE_USER");
                }
            }*/

        #endregion

        #region API CONTRACT MODEL AND VALIDATORS


        public class UserAuthResponse
        {
            public UserDetailsDto user { get; set; }
            public AuthToken authToken { get; set; }
            public List<UserAuthPermissionsDto> userPermissions { get; set; }
            public List<UserPersonalizedSettingDto> userPersonalizedSetting { get; set; }
        }

        public class AuthReq
        {
            public string user_name { get; set; }
            public string password { get; set; }
        }
        public class AuthReqValidator : AbstractValidator<AuthReq>
        {
            public AuthReqValidator()
            {
                RuleFor(p => p.user_name).NotEmpty().EmailAddress();
                RuleFor(p => p.password).NotEmpty().MinimumLength(8);
            }
        }

        public class ChangePasswordReq
        {
            public int user_id { get; set; }
            public string password { get; set; }
        }
        public class ChangePasswordReqValidator : AbstractValidator<ChangePasswordReq>
        {
            public ChangePasswordReqValidator()
            {
                RuleFor(p => p.user_id).NotEmpty();
                RuleFor(p => p.password).NotEmpty().MinimumLength(8);
            }
        }

        public class ResetPasswordReq
        {
            public string reset_password_token { get; set; }
            public string new_password { get; set; }
        }
        public class ResetPasswordReqValidator : AbstractValidator<ResetPasswordReq>
        {
            public ResetPasswordReqValidator()
            {
                RuleFor(p => p.reset_password_token).NotEmpty();
                RuleFor(p => p.new_password).NotEmpty().MinimumLength(8);
            }
        }

        public class ResetPasswordNotification
        {
            public Guid user_id { get; set; }
            public string full_name { get; set; }
            public string email { get; set; }
            public string reset_password_token { get; set; }
            public string base_url { get; set; }
        }


        #endregion
    }
}

