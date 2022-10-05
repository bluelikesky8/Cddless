namespace CuddlesNextGen.Application.UserAuth.UserLogin.Queries
{
    public class UserPersonalizedSettingDto
    {
        public int id { get; set; }
        public int personalized_category_id { get; set; }
        public string keys { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int user_id { get; set; }
        public string value { get; set; }
    }
}
