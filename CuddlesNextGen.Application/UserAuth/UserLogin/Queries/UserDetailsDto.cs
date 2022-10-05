namespace CuddlesNextGen.Application.UserLogin.Queries
{
    public class UserDetailsDto
    {
        public Guid id { get; set; }
        public long contact_id { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string full_name { get; set; }
        public string profile_image { get; set; }
        public long account_id { get; set; }
        public long account_type_id { get; set; }
        public string account_name { get; set; }
        public string contact_type { get; set; }
        public DateTime last_login_on { get; set; }

       
    }


}
