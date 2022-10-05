using System.Data;
using CuddlesNextGen.Application.Service;
using CuddlesNextGen.Application.SQL;
using CuddlesNextGen.Application.UserLogin.Queries;
using CuddlesNextGen.Application.Utility;
using Dapper;
using FluentValidation;
using MediatR;

namespace CuddlesNextGen.Application.UserAuth.UserLogin.Queries
{
    public class GetUserAuthQuery : IRequest<UserCredentialDto>
    {
        public string user_name { get; set; }
        public string password { get; set; }
    }
    public class UserAuthQueryHandler : IRequestHandler<GetUserAuthQuery, UserCredentialDto>
    {
        private readonly ISqlContext _dbCntx;
        private readonly IIdentityService _identity;

        public UserAuthQueryHandler( ISqlContext dbCntx, IIdentityService identity)
        {
            _dbCntx = dbCntx;
            _identity = identity;
        }

        public async Task<UserCredentialDto> Handle(GetUserAuthQuery request, CancellationToken cancellationToken)
        {
            UserCredentialDto user = null;
            DynamicParameters parameters = new DynamicParameters();
            using (var connection = _dbCntx.GetOpenConnection())
            {
                var querycolumns = @"SELECT " +
                                   "username,password as password_hash ,userid as id,emailaddress as email from  vw_userdetail where username = @pUserName ";
                parameters.Add("@pUserName", request.user_name);
              
               
                user = await connection.QueryFirstOrDefaultAsyncWithRetry<UserCredentialDto>(querycolumns, parameters, commandType: CommandType.Text);
            }
            return user;
        }

    }

    public class GetUserAuthQueryValidator : AbstractValidator<GetUserAuthQuery>
    {
        public GetUserAuthQueryValidator()
        {
            RuleFor(x => x.user_name).NotEmpty().EmailAddress();
               
        }
    }
}
