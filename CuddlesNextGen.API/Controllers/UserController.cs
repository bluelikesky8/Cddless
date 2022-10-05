using MediatR;
using Microsoft.AspNetCore.Mvc;
//using PARSNextGen.Application.User.ContactDetailByEmail.Queries;
using FluentValidation;
using CuddlesNextGen.Application.Service;
using CuddlesNextGen.API.DataModel;
using CuddlesNextGen.Application.User.UserStatus.Queries;
using CuddlesNextGen.Application.User.UserPhoto.Command;
using CuddlesNextGen.Application.User.UserRole.Command;
using CuddlesNextGen.Application.User.UserProfile.Queries;
using CuddlesNextGen.API.Extensions.Exceptions;
using CuddlesNextGen.Application.User.UserStatus.Command;
using CuddlesNextGen.Application.User.Users.UserAdd.Command;
using CuddlesNextGen.Application.User.Users.UserById.Queries;
using CuddlesNextGen.Application.User.Users.AllUsers.Queries;
using CuddlesNextGen.Application.User.Users.UserValidation.Queries;

namespace CuddlesNextGen.API.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/V{v:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        private readonly ICustomMessageService _customMsgSvc;

        public UserController(IMediator mediator, ILogger<UserController> logger, ICustomMessageService customMsgSvc)
        {
            _logger = logger;
            _mediator = mediator;
            _customMsgSvc = customMsgSvc;
        }

        #region API CONTROLLER METHODS




        /// <summary>
        /// API  sets user status to active or in-active    
        /// </summary>
        /// <param name="UserStatusDto"> This Dto takes user_id and status</param>
        /// <returns></returns>

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBase<long>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUserStatus(UpdateUserStatusReq updateUserStatusReq)
        {
            ResponseBase<long> updResponse = new ResponseBase<long>();

            bool isUpdSuccessful = await _mediator.Send(new UpdateUserStatusCommand { id = updateUserStatusReq.id, is_active = updateUserStatusReq.is_active });
            if (isUpdSuccessful)

            {
                updResponse.Data = updateUserStatusReq.id;
                updResponse.MessageDetail = _customMsgSvc.GetCustomMessageByShortCode("CUDDLES_RECORD_UPDATE_SUCCESS");
                return new OkObjectResult(updResponse);
            }
            else
            {
                throw new BusinessException("CUDDLES_UPDATION_FAILURE");
            }
        }



        /// <summary>
        /// API gets details of all users
        /// </summary>
        /// <returns> List of all users </returns>
        /// <exception cref="BusinessException"></exception>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseBase<List<AccountUsersDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAccountUsers()
        {
            ResponseBase<List<AccountUsersDto>> response = new ResponseBase<List<AccountUsersDto>>();
            var user = await _mediator.Send(new GetAccountUsersQuery { });
            if (user?.Count != 0)
            {
                response.Data = user;
                response.MessageDetail = _customMsgSvc.GetCustomMessageByShortCode("CUDDLES_RECORD_FOUND");
                return new OkObjectResult(response);
            }
            else
            {
                throw new BusinessException("CUDDLES_RECORD_NOT_FOUND");
            }
        }


        /// <summary>
        /// API to get role by user id.
        /// </summary>
        /// <param name="userId"> user id </param>
        /// <returns> User Roles dto </returns>
        /// <exception cref="BusinessException"></exception>

        [HttpGet]
        [ProducesResponseType(typeof(ResponseBase<List<UserRolesDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllRolesByUserId(int userId)
        {
            var userRoles = await _mediator.Send(new GetAllRolesByUserIdQuery { user_id = userId });
            if (userRoles.Count > 0)
            {
                ResponseBase<List<UserRolesDto>> response = new ResponseBase<List<UserRolesDto>>();
                response.Data = userRoles;
                response.MessageDetail = _customMsgSvc.GetCustomMessageByShortCode("CUDDLES_RECORD_FOUND");
                return new OkObjectResult(response);
            }
            else
            {
                throw new BusinessException("CUDDLES_RECORD_NOT_FOUND");
            }
        }




        /// <summary>
        /// API gets user by user id
        /// </summary>
        /// /// <param name="id">user id</param>

        [HttpGet]
        [ProducesResponseType(typeof(ResponseBase<UserByIdDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById(long id)
        {
            var userById = await _mediator.Send(new GetUserByIdQuery { id = id });
            if (userById != null)
            {
                ResponseBase<UserByIdDto> response = new ResponseBase<UserByIdDto>();
                response.Data = userById;
                response.MessageDetail = _customMsgSvc.GetCustomMessageByShortCode("CUDDLES_RECORD_FOUND");
                return new OkObjectResult(response);
            }
            else
            {
                throw new BusinessException("CUDDLES_RECORD_NOT_FOUND");
            }
        }




        /// <summary>
        /// API used to update user photo.
        /// </summary>
        /// <param name="UpdateUserPhotoReq"> Dto takes user id and the user image url </param>
        /// <returns> Updated user id </returns>
        /// <exception cref="Exception"></exception>

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBase<long>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUserPhoto(UpdateUserPhotoReq updateUserPhotoReq)
        {
            ResponseBase<long> updResponse = new ResponseBase<long>();
            bool isUpdSuccessful = await _mediator.Send(new UpdateUserPhotoCommand { user_id = updateUserPhotoReq.user_id, image_url = updateUserPhotoReq.image_url });
            if (isUpdSuccessful)
            {
                updResponse.Data = updateUserPhotoReq.user_id;
                updResponse.MessageDetail = _customMsgSvc.GetCustomMessageByShortCode("CUDDLES_RECORD_UPDATE_SUCCESS");
                return new OkObjectResult(updResponse);
            }
            else
            {
                throw new BusinessException("CUDDLES_UPDATION_FAILURE");
            }
        }

        /// <summary>
        ///  API is For Add user roles
        /// </summary>
        /// <param name="UserRolesAddDto"> This dto is used to Add Role for user</param>
        /// <returns></returns>

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBase<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AssignRoleToUser(UserRolesAddReq userRoles)
        {
            ResponseBase<bool> response = new ResponseBase<bool>();
            bool isUpdateSuccessful = await _mediator.Send(new AddUserRoleCommand { user_id = userRoles.user_id, role_ids = userRoles.role_ids });
            if (isUpdateSuccessful)
            {
                response.Data = isUpdateSuccessful;
                response.MessageDetail = _customMsgSvc.GetCustomMessageByShortCode("CUDDLES_RECORD_UPDATE_SUCCESS");
                return new OkObjectResult(response);
            }
            else
            {
                throw new BusinessException("CUDDLES_UPDATION_FAILURE");
            }
        }



        /// <summary>
        /// API gets user profile information    
        /// </summary>
        /// <param name="UserStatusDto"> This Dto takes user_id and status</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseBase<List<UserDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserProfile()
        {
            ResponseBase<List<UserDto>> response = new ResponseBase<List<UserDto>>();
            var user = await _mediator.Send(new GetuserDetailQuery { });
            if (user?.Count != 0)
            {
                response.Data = user;
                response.MessageDetail = _customMsgSvc.GetCustomMessageByShortCode("CUDDLES_RECORD_FOUND");
                return new OkObjectResult(response);
            }
            else
            {
                throw new BusinessException("CUDDLES_RECORD_NOT_FOUND");
            }
        }


        /// <summary>
        /// Add new User 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseBase<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddUser(UserRequest user)
        {
            ResponseBase<bool> responseBase = new ResponseBase<bool>();

            var re = await _mediator.Send(new UserEmailAddressValidation { Email = user.emailaddress });

            if (re == false) 
            {

                var result = await _mediator.Send(new AddUserCommand { UserRequest = user });
                if (result)
                {
                    responseBase.Data = result;
                    responseBase.MessageDetail = _customMsgSvc.GetCustomMessageByShortCode("CUDDLE_RECORD_FOUND");
                    return new OkObjectResult(responseBase);
                }
                else
                {
                    throw new BusinessException("CUDDLE_CREATION_FAILURE");
                }
            }
            else
            {
                throw new BusinessException("CUDDLE_DUPLICATE_EMAIL");
            }

            

        }

        /// <summary>
        /// Verify user's email 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>


        [HttpPost]
        [ProducesResponseType(typeof(ResponseBase<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> OTPverify(UserOTPVm user)
        {

            ResponseBase<bool> responseBase = new ResponseBase<bool>();

            var result = await _mediator.Send(new UserEmailOTP { UserOTPVm = user });

            if (result)
            {
                responseBase.Data = result;
                responseBase.MessageDetail = _customMsgSvc.GetCustomMessageByShortCode("CUDDLE_RECORD_FOUND");
                return new OkObjectResult(responseBase);
            }
            else
            {
                throw new BusinessException("CUDDLE_RECORD_NOT_FOUND");
            }
        }


        #endregion


        #region API CONTRACT MODEL AND VALIDATORS

        public class UserRolesAddReq
        {
            public int user_id { get; set; }
            public List<int> role_ids { get; set; }

        }

        //Add validator here for UserRolesAddReqValidator.

        public class UpdateUserPhotoReq
        {
            public int user_id { get; set; }
            public string image_url { get; set; }
        }

        public class UpdateUserPhotoReqValidator : AbstractValidator<UpdateUserPhotoReq>
        {
            public UpdateUserPhotoReqValidator()
            {
                RuleFor(p => p.user_id).NotEmpty();
                RuleFor(p => p.image_url).NotEmpty();
            }
        }


        public class UpdateUserStatusReq
        {
            public int id { get; set; }
            public bool is_active { get; set; }
        }


        public class UpdateUserStatusReqValidator : AbstractValidator<UpdateUserStatusReq>
        {
            public UpdateUserStatusReqValidator()
            {
                RuleFor(p => p.id).NotEmpty();
            }
        }
        #endregion

    }
}
