using System.Data;
using MediatR;
using Dapper;
using CuddlesNextGen.Application.UserAuth.UserLogin.Queries;
using CuddlesNextGen.Application.SQL;
using CuddlesNextGen.Application.Utility;

namespace CuddlesNextGen.Application.UserAuth.UserPermissions.Queries
{
    public class GetUserPermisssionQuery : IRequest<List<UserAuthPermissionsDto>>
    {
        public string user_name { get; set; }
    }
    public class GetUserPermisssionQueryHandler : IRequestHandler<GetUserPermisssionQuery, List<UserAuthPermissionsDto>>
    {
        private readonly ISqlContext _dbCntx;
        public GetUserPermisssionQueryHandler(ISqlContext dbCntx)
        {
            _dbCntx = dbCntx;
        }

        public async Task<List<UserAuthPermissionsDto>> Handle(GetUserPermisssionQuery request, CancellationToken cancellationToken)
        {
            List<UserAuthPermissionsDto> userPermissions = null;
            DynamicParameters parameters = new DynamicParameters();
            var procedure = "sp_get_user_role_permissions";
            using (var connection = _dbCntx.GetOpenConnection())
            {
                parameters.Add("@pUserName", request.user_name);
                userPermissions = (List<UserAuthPermissionsDto>)await connection.QueryAsyncWithRetry<UserAuthPermissionsDto>(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return userPermissions;
        }
    }
}
