using CuddlesNextGen.Application.SQL;
using CuddlesNextGen.Application.Utility;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace CuddlesNextGen.Application.User.Users.UserValidation.Queries
{
    public class UserEmailAddressValidation : IRequest<bool>
    {
        public string Email { get; set; }
    }

    public class UserEmailAddressValidationHandler : IRequestHandler<UserEmailAddressValidation, bool>
    {
        private readonly ISqlContext _dbCntx;

        public UserEmailAddressValidationHandler(ISqlContext dbCntx)
        {

            _dbCntx = dbCntx;

        }

        public async Task<bool> Handle(UserEmailAddressValidation request, CancellationToken cancellationToken)
        {
            // UserEmailDto user = null;
            DynamicParameters parameters = new DynamicParameters();
            using (var connection = _dbCntx.GetOpenConnection())
            {

                string emailaddress = "";
                var exists = connection.ExecuteScalar<bool>("select count(1) from vw_userdetail where emailaddress=@emailaddress", new { emailaddress });

                return exists;
            }

        }
    }
}
