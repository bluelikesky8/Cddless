using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuddlesNextGen.Application.User.Users.UserValidation.Queries
{
    public class UserOTPVm
    {
        public Guid id { get; set; }
        public string OTP { get; set; }

    }
}
