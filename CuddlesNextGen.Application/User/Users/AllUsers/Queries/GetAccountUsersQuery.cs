using CuddlesNextGen.Application.Service;
using CuddlesNextGen.Application.SQL;
using CuddlesNextGen.Application.Utility;
using Dapper;
using MediatR;
using System.Data;

namespace CuddlesNextGen.Application.User.Users.AllUsers.Queries
{
    public class GetAccountUsersQuery : IRequest<List<AccountUsersDto>>
    {
    }
    public class GetAllUsersQueryHandler : IRequestHandler<GetAccountUsersQuery, List<AccountUsersDto>>
    {
        private readonly ISqlContext _dbCntx;
        private readonly ICurrentUserService _currentUserService;
        public GetAllUsersQueryHandler(ISqlContext dbCntx, ICurrentUserService currentUserService)
        {
            _dbCntx = dbCntx;
            _currentUserService = currentUserService;
        }

        public async Task<List<AccountUsersDto>> Handle(GetAccountUsersQuery request, CancellationToken cancellationToken)
        {
            DynamicParameters parameters = new DynamicParameters();
            List<AccountUsersDto> user = null;
            using (var connection = _dbCntx.GetOpenConnection())
            {
                string where = "";
                //  if (_currentUserService.AccountTypeId != (long)EnumTypes.AccountTypes.PARS)
                where = "WHERE ua.account_id=@accountId ";
                var querycolumns = @"SELECT " +
                                   " ua.id, CONCAT(ua.first_name,' ', ' ', ua.last_name) AS name, ua.business_phone as contact,ua.user_name as email,ua.is_active,ua.created_on,ua.contact_type,ua.contact_type_id " +
                                   " from vw_userdetail ua " +
                                   where +
                                  " order by ua.created_on desc ";

                parameters.Add("@accountId", _currentUserService.AccountId);


                user = (List<AccountUsersDto>)await connection.QueryAsyncWithRetry<AccountUsersDto>(querycolumns, parameters, commandType: CommandType.Text);
            }
            return user;
        }

    }
}


