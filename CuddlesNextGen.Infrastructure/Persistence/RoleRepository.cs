using System.Data;
using Dapper;
using CuddlesNextGen.Application.Service;
using CuddlesNextGen.Application.SQL;
using CuddlesNextGen.Application.Utility;
using CuddlesNextGen.Domain.Interface;

namespace CuddlesNextGen.Infrastructure.Persistence
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ISqlContext _dbCntx;
        private readonly ICurrentUserService _currentUserService;
        public RoleRepository(ISqlContext dbCntx, ICurrentUserService currentUserService)
        {
            _dbCntx = dbCntx;
            _currentUserService = currentUserService;
        }

        /// <summary>
        ///  This method is used to create a new role
        /// </summary>
        /// <param name="roleName"> role Name </param>
        /// <param name="roleDescription"> role Description </param>
        /// <returns> Newly created role id </returns>
        
        public async Task<bool> CreateRole(string roleName, string roleDescription)
        {
            DynamicParameters dp = new DynamicParameters();
            var query = "sp_create_role";
            bool result = false;
            using (var connection = _dbCntx.GetOpenConnection())
            {
                dp.Add("@pName", roleName);
                dp.Add("@pDescription", roleDescription);
                dp.Add("@pId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dp.Add("@accountId", _currentUserService.AccountId);
                dp.Add("@created_by", _currentUserService.LoggedInUserId);
                int affectedRows = await connection.ExecuteAsyncWithRetry(query, dp, commandType: CommandType.StoredProcedure);
                result = affectedRows > 0 ? true : false;
            }
            return result;
        }
        

        /// <summary>
        /// This method is used to update role status
        /// </summary>
        /// <param name="roleId"> Role Id </param>
        /// <param name="roleStatus"> Role status </param>
        /// <returns></returns>
        
        public async Task<bool> UpdateRoleStatus(int roleId, bool roleStatus)
        {
            DynamicParameters dp = new DynamicParameters();
            bool result = false;
            var query = "sp_update_role_status";

            //Changes role status
            int statusUpdate = 0;
            if (roleStatus == true)
            {
                statusUpdate = 1;
            }

            using (var connection = _dbCntx.GetOpenConnection())
            {
                dp.Add("@pRoleId", roleId);
                dp.Add("@pParameter", statusUpdate);
                dp.Add("@updated_by", _currentUserService.LoggedInUserId);
                
                int affectedRows = await connection.ExecuteAsyncWithRetry(query, dp, commandType: CommandType.StoredProcedure);
                result = affectedRows > 0 ? true : false;
            }
            return result;
        }
        

        
        /// <summary>
        /// this method is used to Update role by using its id
        /// </summary>
        /// <param name="roleId"> role id </param>
        /// <param name="roleName"> role name </param>
        /// <returns></returns>
        public async Task<bool> UpdateRoleById(int roleId,string roleName, string roleDescription)
        {
            DynamicParameters dp = new DynamicParameters();
            bool result = false;
            var query = "sp_update_role";
            using(var c = _dbCntx.GetOpenConnection())
            {
                dp.Add("@pId",roleId);
                dp.Add("@pRole",roleName);
                dp.Add("@pDescription", roleDescription);
                dp.Add("@updated_by", _currentUserService.LoggedInUserId);
                int affectedRows = await c.ExecuteAsyncWithRetry(query, dp, commandType: CommandType.StoredProcedure);
                result = affectedRows > 0 ? true : false;
            }
            return result ;
        }
        
        
        /// <summary>
        /// This method is used to delete role by id
        /// </summary>
        /// <param name="roleId"> role id </param>
        /// <returns></returns>
        
        public async Task<bool> DeleteRoleById(int roleId)
        {
            DynamicParameters dp = new DynamicParameters();
            var query = "sp_delete_role";
            bool result = false;
            using (var c = _dbCntx.GetOpenConnection())
            {
                dp.Add("@pRoleId", roleId);
                int affectedRows = await c.ExecuteAsyncWithRetry(query, dp, commandType: CommandType.StoredProcedure);
                result = affectedRows > 0 ? true : false;
            }
            return result;
        }



        /// <summary>
        /// This method is used to Add Permission for Role
        /// </summary>
        /// <returns> True if permission Addded false if not </returns>
        public async Task<bool> CreateRolePermission( long role_id, List<long> permission_ids)
        {
            using (var connection = _dbCntx.GetOpenConnection())
            {
                bool result = false;
                var parameters = new { @pRoleId = role_id };
                using (var trx = connection.BeginTransaction())
                {

                    var sql_delete = "DELETE FROM role_permission WHERE role_id = @pRoleId ";
                    int rowsAffected1 = await connection.ExecuteAsyncWithRetry(sql_delete, parameters, commandType: CommandType.Text, transaction: trx);
                    result = rowsAffected1 > 0 ? true : false;

                    DynamicParameters Dparameters = new DynamicParameters();
                    var procedure = "sp_add_user_role_permissions";
                    foreach (var permission_id in permission_ids)
                    {
                        Dparameters.Add("@pRoleId", role_id);
                        Dparameters.Add("@pPermissionId", permission_id);
                        Dparameters.Add("@loggedInUserId", _currentUserService.LoggedInUserId);
                        int rowsInserted = await connection.ExecuteAsyncWithRetry(procedure, Dparameters, commandType: CommandType.StoredProcedure, transaction: trx);
                        result = rowsInserted > 0 ? true : false;
                    }
                    trx.Commit();
                    return result;
                }
            }
        }
    }
}
