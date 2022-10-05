using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuddlesNextGen.Application.User.Users.UserAdd.Command
{
    public class UserRequest
    {
        public string username { get; set; }

        public string password { get; set; }

        public string fullname { get; set; }

        public string emailaddress { get; set; }

        public string mobilenumber { get; set; }

        public string mobileotp { get; set; }

        // public string emailotp { get; set; }


    }
}
