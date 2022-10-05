using System;

namespace CuddlesNextGen.Application.User.Users.AllUsers.Queries
{
    public class AccountUsersDto
    {
        public long id { get; set; }
        public string email { get; set; }
        public string contact { get; set; }
        public string name { get; set; }
        public bool is_active { get; set; }
        public DateTime created_on { get; set; }


        public string contact_type { get; set; }
        public long contact_type_id { get; set; }


    }
}
