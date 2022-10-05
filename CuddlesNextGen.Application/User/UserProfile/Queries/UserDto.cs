using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuddlesNextGen.Application.User.UserProfile.Queries
{
    public class UserDto
    {

        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string user_image { get; set; }
        public string job_title { get; set; }
        public string company_works_for { get; set; }
        public string about { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public string mobile_phone { get; set; }
        public string business_phone { get; set; }

    }
}
