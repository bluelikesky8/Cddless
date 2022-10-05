using System;

namespace CuddlesNextGen.Application.UserLogin.Queries
{
    public class UserCredentialDto 
    {
        public Guid id { get; set; }
        public long contact_id { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string full_name { get; set; }

        public long contact_type_id { get; set; }
        public string profile_image { get; set; }
        public int account_id { get; set; }
        public string account_name { get; set; }

        public long account_type_id { get; set; }
        public string contact_type { get; set; }
        public DateTime last_login_on { get; set; }
        public string password_hash { get; set; }
        public bool is_active { get; set; }
        public Guid password_reset_token { get; set; }
        public DateTime password_reset_on { get; set; }
        public DateTime updated_on { get; set; }
        public DateTime created_on { get; set; }
        public string updated_by { get; set; }
        public string created_by { get; set; }
        public int login_attempt { get; set; }
    }
}