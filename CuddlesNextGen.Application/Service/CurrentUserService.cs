using CuddlesNextGen.Application.Service;
using Microsoft.AspNetCore.Http;

namespace CuddlesNextGen.Application.Service
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        //Id of the user who has loggedin to the application. This is taken from the JWT Access Token.
        public long UserId => _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("claims_UserId") ? Convert.ToInt64(_httpContextAccessor.HttpContext?.Request?.Headers["claims_UserId"]) : 0;

        //In case the logged in user is trying to access the system as another user then Id of orignal logged in user. Else this and UserId above are same.
        public long LoggedInUserId => _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("X-LoginUserId") ? Convert.ToInt64(_httpContextAccessor.HttpContext?.Request?.Headers["X-LoginUserId"]) : this.UserId;
        public string DataAccessKey => _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("claims_DataAccessKey") ? _httpContextAccessor.HttpContext?.Request?.Headers["claims_DataAccessKey"] : string.Empty;
        public string AccessLevel => _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("claims_AccessLevel") ? _httpContextAccessor.HttpContext?.Request?.Headers["claims_AccessLevel"] : string.Empty;
        public long AccountId => _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("claims_AccountId") ? Convert.ToInt64(_httpContextAccessor.HttpContext?.Request?.Headers["claims_AccountId"]) : 0;
        public long ContactTypeId => _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("claims_ContactTypeId") ? Convert.ToInt64(_httpContextAccessor.HttpContext?.Request?.Headers["claims_ContactTypeId"]) : 0;
        public long AccountTypeId => _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("claims_AccountTypeId") ? Convert.ToInt64(_httpContextAccessor.HttpContext?.Request?.Headers["claims_AccountTypeId"]) : 0;
    }
}
