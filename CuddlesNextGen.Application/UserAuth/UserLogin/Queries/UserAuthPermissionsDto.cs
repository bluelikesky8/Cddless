using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuddlesNextGen.Application.UserAuth.UserLogin.Queries
{
    public class UserAuthPermissionsDto
    {
        public string description { get; set; }
        public string role_name { get; set; }
        public string permission_name { get; set; }
        public int role_id { get; set; }
        public int permission_id { get; set; }
        public bool is_read_only { get; set; }
        
    }
}
