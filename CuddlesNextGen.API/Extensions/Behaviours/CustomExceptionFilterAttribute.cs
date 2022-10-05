using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Text;
using CuddlesNextGen.Application.Service;
using CuddlesNextGen.API.DataModel;
using CuddlesNextGen.Application.Utility;
using CuddlesNextGen.API.Extensions.Exceptions;

namespace CuddlesNextGen.API.Extensions.Behaviours
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private const string _errMsgIdentifier = "PARS_";

        private readonly ILogger _logger;
        private readonly ICustomMessageService _customMsgSvc;

        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger, ICustomMessageService customMsgSvc)
        {
            _logger = logger;
            _customMsgSvc = customMsgSvc;
        }

        public override void OnException(ExceptionContext context)
        {

            context.HttpContext.Response.ContentType = "application/json";

            if (context.Exception is ValidationException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //context.Result = new JsonResult(((ValidationException)context.Exception).Errors);

                StringBuilder errMsg = new StringBuilder();
                foreach (var item in ((ValidationException)context.Exception).Errors.Values)
                {
                    errMsg.AppendLine(item[0].ToString());
                }

                ResponseBase<string> invalidResponse = new ResponseBase<string>();
                invalidResponse.IsSuccessful = false;

                invalidResponse.MessageDetail = new CustomMessage
                {
                    message_code = "5999",
                    message_shortcode = "CUDDLE_MODEL_VALIDATION_FAILED",
                    message_type = "Validation",
                    message = errMsg.ToString()
                };

                context.Result = new JsonResult(invalidResponse);
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                ResponseBase<string> response = new ResponseBase<string>();
                response.IsSuccessful = false;

                if (context.Exception.Message.StartsWith(_errMsgIdentifier))
                {
                    response.MessageDetail = _customMsgSvc.GetCustomMessageByShortCode(context.Exception.Message);
                    _logger.LogError(response?.MessageDetail?.message, "CUDDLENxtGenAPI Unauthorized Access Exception");
                }
                else
                {
                    response.MessageDetail = new Application.Utility.CustomMessage
                    {
                        message = context.Exception.Message,
                        message_code = "4449",
                        message_type = "Error",
                        message_shortcode = "CUDDLE_UNAUTHORIZED_ACCESS"
                    };

                    _logger.LogError(context.Exception, "CUDDLENxtGenAPI Unauthorized Access Exception");
                }

                context.Result = new JsonResult(response);
            }
            else if (context.Exception is BusinessException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                ResponseBase<string> response = new ResponseBase<string>();
                response.IsSuccessful = false;
                response.MessageDetail = _customMsgSvc.GetCustomMessageByShortCode(context.Exception.Message);

                context.Result = new JsonResult(response);

            }
            else// Incase it is an unhandled error, then log the error.
            {
                _logger.LogError(context.Exception, "CUDDLENxtGenAPI Unhandled Exception");
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ResponseBase<string> response = new ResponseBase<string>();
                response.IsSuccessful = false;


                if (context.Exception.Message.StartsWith(_errMsgIdentifier))
                    response.MessageDetail = _customMsgSvc.GetCustomMessageByShortCode(context.Exception.Message);
                else
                {
                    response.MessageDetail = new Application.Utility.CustomMessage
                    {
                        message = context.Exception.Message,
                        message_code = "4449",
                        message_type = "Error",
                        message_shortcode = "CUDDLE_UNHANDLED_ERROR"
                    };
                }

                context.Result = new JsonResult(response);
            }
        }
    }
}
