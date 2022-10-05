using System;

namespace CuddlesNextGen.Application.User.Users.UserById.Queries
{
    public class UserByIdDto
    {
        public long id { get; set; }
        public string email { get; set; }
        public string contact { get; set; }
        public string name { get; set; }
        public bool is_active { get; set; }
        public DateTime created_on { get; set; }
    }
}
