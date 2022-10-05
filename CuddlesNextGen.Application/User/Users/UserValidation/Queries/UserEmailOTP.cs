using CuddlesNextGen.Application.SQL;
using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CuddlesNextGen.Application.User.Users.UserValidation.Queries
{
    public class UserEmailOTP : IRequest<bool>
    {

        public UserOTPVm UserOTPVm { get; set; }

        public class UserEmailOTPHandler : IRequestHandler<UserEmailOTP, bool>
        {
            // private readonly UserOTPVm _userOTPVm;
            private readonly ISqlContext _sql;

            public UserEmailOTPHandler(ISqlContext sql)
            {
                _sql = sql;

            }

            public async Task<bool> Handle(UserEmailOTP request, CancellationToken cancellationToken)
            {

                DynamicParameters parameters = new DynamicParameters();

                using (var connection = _sql.GetOpenConnection())
                {

                    var query = @"Select" + "count(1), userid,emailotp from vw_userdetail where userid = @puserId AND emailotp = @pemailotp ";

                    parameters.Add("@puserId", request.UserOTPVm.id);
                    parameters.Add("@pemailotp", request.UserOTPVm.OTP);

                    int script = await connection.ExecuteScalarAsync<int>(query, parameters, commandType: CommandType.Text);

                    if(script > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                    
                }


            }

        }



    }
}
