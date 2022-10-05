using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuddlesNextGen.Application.User.UserViewPreference.Queries
{
    public class GridPreferenceDto
    {
        public int id { get; set; }
        public string myview_column { get; set; }
        public string myview_filter { get; set; }
    }
}
