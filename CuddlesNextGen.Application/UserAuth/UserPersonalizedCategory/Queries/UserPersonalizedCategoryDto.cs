using System.Collections.Generic;
using System.Text;

namespace CuddlesNextGen.Application.UserPreferences.Queries
{
    public class UserPersonalizedCategoryDto
    {
        public int id { get; set; }
        public int personalized_category_id { get; set; }
        public int user_id { get; set; }
        public string value { get; set; }
    }
}
