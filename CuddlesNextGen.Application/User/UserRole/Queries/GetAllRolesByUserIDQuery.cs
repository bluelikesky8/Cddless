using MediatR;
using System.Data;
using FluentValidation;
using Dapper;
using CuddlesNextGen.Application.Service;
using CuddlesNextGen.Application.SQL;
using CuddlesNextGen.Application.Utility;

namespace CuddlesNextGen.Application.User.UserStatus.Queries
{
    public class GetAllRolesByUserIdQuery : IRequest<List<UserRolesDto>>
    {
        public int user_id { get; set; }
    }
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesByUserIdQuery, List<UserRolesDto>>
    {
        private readonly ISqlContext _sqlCtx;
        private readonly ICurrentUserService _currentUserContext;
        public GetAllRolesQueryHandler(ISqlContext sqlCtx, ICurrentUserService currentUserContext)
        {
            _sqlCtx = sqlCtx;
            _currentUserContext = currentUserContext;
        }

        public async Task<List<UserRolesDto>> Handle(GetAllRolesByUserIdQuery request, CancellationToken cancellationToken)
        {
            List<UserRolesDto> userRoles = new List<UserRolesDto>();
            DynamicParameters parameters = new DynamicParameters();
            var procedure = "sp_get_user_role";
            using (var connection = _sqlCtx.GetOpenConnection())
            {
                parameters.Add("@pUserId", request.user_id);
                parameters.Add("@pAcountId", _currentUserContext.AccountId);
                userRoles = (List<UserRolesDto>)await connection.QueryAsyncWithRetry<UserRolesDto>(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return userRoles;
        }
        public class RolesByUserIDRequestValidator : AbstractValidator<GetAllRolesByUserIdQuery>
        {
            public RolesByUserIDRequestValidator()
            {
                RuleFor(p => p.user_id).NotEmpty();
            }
        }

    }
}
