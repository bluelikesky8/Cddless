using CuddlesNextGen.Application.Service;
using CuddlesNextGen.Application.SQL;
using CuddlesNextGen.Application.Utility;
using CuddlesNextGen.Domain.Entities;
using CuddlesNextGen.Domain.Interface;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CuddlesNextGen.Application.User.Users.UserAdd.Command
{
    public class AddUserCommand : IRequest<bool>
    {
        public UserRequest UserRequest { get; set; }
    }
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, bool>
    {
        private readonly ISqlContext _dbCntx;
        private readonly IIdentityService _identity;
        private readonly IEmailService _email;

        public AddUserCommandHandler(ISqlContext context, IIdentityService identity, IEmailService email)
        {
            _dbCntx = context;
            _identity = identity;
            _email = email;
        }
        public async Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            DynamicParameters dp = new DynamicParameters();
            bool result = false;



            var query = "sp_useradd";
            using (var connection = _dbCntx.GetOpenConnection())
            {
                dp.Add("@username", request.UserRequest.username);
                dp.Add("@password", _identity.CreatePasswordHash(request.UserRequest.password));
                dp.Add("@fullname", request.UserRequest.fullname);
                dp.Add("@emailaddress", request.UserRequest.emailaddress);
                dp.Add("@mobilenumber", request.UserRequest.mobilenumber);
                dp.Add("@mobileotp", request.UserRequest.mobileotp);

                Random random = new Random();
                var otp = random.Next(1000, 9999);
                dp.Add("@emailotp", otp);
                int rowsAffected = await connection.ExecuteAsyncWithRetry(query, dp, commandType: CommandType.StoredProcedure);
                result = rowsAffected > 0 ? true : false;

                _email.OTP(otp, request.UserRequest.emailaddress);

            }
            return result;

        }
    }
}
