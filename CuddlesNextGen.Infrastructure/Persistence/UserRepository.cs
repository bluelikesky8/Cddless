using System.Data;
using CuddlesNextGen.Application.Service;
using CuddlesNextGen.Application.SQL;
using CuddlesNextGen.Application.Utility;
using CuddlesNextGen.Domain.Interface;
using Dapper;

namespace CuddlesNextGen.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlContext _dbCntx;
        private readonly ICurrentUserService _currentUserService;
        public UserRepository(ISqlContext dbCntx, ICurrentUserService currentUserService)
        {
            _dbCntx = dbCntx;
            _currentUserService = currentUserService;
        }

        #region UpdateUserStatus
        /// <summary>
        /// This method is used to update the status of user
        /// </summary>
        /// <param name="id"> User id </param>
        /// <param name="isActive"> User status </param>
        /// <returns></returns>
        public async Task<bool> UpdateUserStatus(int id, bool isActive)
        {
            DynamicParameters parameters = new DynamicParameters();
            var procedure = "sp_update_user_status";
            bool result = false;
            using (var connection = _dbCntx.GetOpenConnection())
            {
                parameters.Add("@pId", id);
                parameters.Add("@pIsActive", isActive);
                parameters.Add("@updatedbyId", _currentUserService.LoggedInUserId);
                int rowsAffected = await connection.ExecuteAsyncWithRetry(procedure, parameters, commandType: CommandType.StoredProcedure);
                result = rowsAffected > 0 ? true : false;
            }
            return result;
        }
        #endregion
            
        #region UpdateUserPhotoByUserId

        /// <summary>
        /// This method updates the user photo for the given user
        /// </summary>
        /// <returns> true if updated false if not </returns>
        public async Task<bool> UpdateUserPhotoByUserId(int userId, string imageUrl) 
        {
            DynamicParameters dp = new DynamicParameters();
            var query = "sp_update_user_photo";
            bool result = false;
            using (var c = _dbCntx.GetOpenConnection())
            {
                dp.Add("@pUserId", userId);
                dp.Add("@pImageUrl", imageUrl);
                dp.Add("@updatedbyId", _currentUserService.LoggedInUserId);
                var affectedRow = await c.ExecuteAsyncWithRetry(query, dp, commandType: CommandType.StoredProcedure);
                result = affectedRow > 0 ? true : false;
            }
            return result;
        }
        #endregion
        
        #region AddUserRole

        /// <summary>
        /// This method is used for Add User Role
        /// </summary>
        /// <returns> true if user Addded false if not </returns>
        public async Task<bool> AddUserRole(int user_id, List<int> role_ids)
        {
            using (var connection = _dbCntx.GetOpenConnection())
            {
                bool result = false;
                var parameters = new { UserId = user_id };
                using (var trx = connection.BeginTransaction())
                {

                    var sql_delete = "Delete from user_role where user_id = @UserId ";
                    int rowsAffected1 = await connection.ExecuteAsyncWithRetry(sql_delete, parameters, commandType: CommandType.Text, transaction: trx);
                    result = rowsAffected1 > 0 ? true : false;

                    DynamicParameters addRoleParam = new DynamicParameters();
                    var procedure = "sp_create_user_role";
                    foreach (var roleid in role_ids)
                    {
                        addRoleParam.Add("@pUser_id", user_id);
                        addRoleParam.Add("@prole_id", roleid);
                        int rowsInserted = await connection.ExecuteAsyncWithRetry(procedure, addRoleParam, commandType: CommandType.StoredProcedure, transaction: trx);
                        result = rowsInserted > 0 ? true : false;
                    }

                    trx.Commit();
                    return result;
                }
            }
        }
        #endregion

        #region SetDefaultGridColumnPreference

        /// <summary>
        /// This method is used for Set default Grid Column Preference
        /// </summary>
        /// <returns> true if Preference Set false if not </returns>
        public async Task<bool> SetDefaultGridColumnPreference(string entity_name, long account_type_id, string view_column_json, long userid)
        {
            DynamicParameters dp = new DynamicParameters();
            var query = "sp_set_default_gridcolumn_preference";
            bool result = false;
            using (var c = _dbCntx.GetOpenConnection())
            {
                dp.Add("@pentity_name", entity_name);
                dp.Add("@paccount_type_id", account_type_id);
                dp.Add("@pview_column_json", view_column_json);
                dp.Add("@puserid", userid);
                dp.Add("@id_identity", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var affectedRow = await c.ExecuteAsyncWithRetry(query, dp, commandType: CommandType.StoredProcedure);
                int id = 0;
                id = dp.Get<int>("@id_identity");
                if (id > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
               
            }
            return result;
        }
        #endregion

        #region SetDefaultGridColumnPreference

        /// <summary>
        /// This method is used for Set default Grid Column filter Preference
        /// </summary>
        /// <returns> true if Preference Set false if not </returns>
        public async Task<bool> SetDefaultGridColumnFilterPreference(string entity_name, long account_type_id, string view_column_json, long userid)
        {
            DynamicParameters dp = new DynamicParameters();
            var query = "sp_set_default_gridfilter_preference";
            bool result = false;
            using (var c = _dbCntx.GetOpenConnection())
            {
                dp.Add("@pentity_name", entity_name);
                dp.Add("@paccount_type_id", account_type_id);
                dp.Add("@pview_filter_json", view_column_json);
                dp.Add("@puserid", userid);
                dp.Add("@id_identity", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var affectedRow = await c.ExecuteAsyncWithRetry(query, dp, commandType: CommandType.StoredProcedure);
                int id = 0;
                id = dp.Get<int>("@id_identity");
                if (id > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            return result;
        }
        #endregion

    }
}
