using System.Data;
using CuddlesNextGen.Application.Service;
using CuddlesNextGen.Application.SQL;
using CuddlesNextGen.Application.Utility;
using CuddlesNextGen.Domain.Interface;
using Dapper;

namespace CuddlesNextGen.Infrastructure.Persistence
{
    public class AuthServiceRepository : IAuthServiceRepository
    {
        private readonly ISqlContext _isql;
        private readonly ICurrentUserService _currentUserService;
        public AuthServiceRepository(ISqlContext isql, ICurrentUserService currentUserService)
        {
            _isql = isql;
            _currentUserService = currentUserService;
        }

        #region GenerateResetPasswordTokenByUserId
        ///<summary>
        /// This method is used to generate password reset token for User  
        /// </summary>
        /// <param name="userId"> User Id for whom password needs to be set.</param>
        /// <returns> Return the password reset token </returns>
        
        public async Task<string> GenerateResetPasswordTokenByUserId(Guid userId)
        {
            DynamicParameters dp = new DynamicParameters();
            string result;
            using (var connection = _isql.GetOpenConnection())
            {
                var query = "sp_reset_user_password";
                dp.Add("@pUserId", userId);
                dp.Add("@pPasswordResetToken", dbType: DbType.StringFixedLength, direction: ParameterDirection.Output, size: 50);
                var affectedRows = await connection.ExecuteAsyncWithRetry(query, dp, commandType: CommandType.StoredProcedure);
                result = affectedRows > 0 ? dp.Get<string>("@pPasswordResetToken").Trim() : "";
            }
            return result;
        }
        #endregion

        #region UpdatePassword
        /// <summary>
        /// This method is used to update the Password
        /// </summary>
        /// <param name="userId">User Id for whom passowrd needs to be set.</param>
        /// <returns></returns>
        
        public async Task<bool> UpdatePassword(long userId, string passwordHash)
        {
            DynamicParameters dp = new DynamicParameters();
            bool result = false;
            var query = "sp_change_password";
            using (var connection = _isql.GetOpenConnection())
            {
                dp.Add("@pPasswordHash", passwordHash);
                dp.Add("@pUserId", userId);
                dp.Add("@updatedbyId", _currentUserService.LoggedInUserId);
                int rowsAffected = await connection.ExecuteAsyncWithRetry(query, dp, commandType: CommandType.StoredProcedure);
                result = rowsAffected > 0 ? true : false;
            }
            return result;
        }
        #endregion

    }
}
