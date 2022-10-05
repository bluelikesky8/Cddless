using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuddlesNextGen.Application.User.UserStatus.Queries
{
    public class UserRolesDto
    {
        public string role_name { get; set; }
        public string role_id { get; set; }
        public bool is_assigned { get; set; }
        public bool is_read_only { get; set; }

    }
}
