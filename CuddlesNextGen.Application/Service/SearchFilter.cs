using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuddlesNextGen.Application.Service
{
    public class SearchFilter
    {
        public List<Filter> filters { get; set; }
    }
    public class DataField
    {
        public string fieldName { get; set; }
        public string dataType { get; set; }
        public string displayText { get; set; }
    }

    public class Filter
    {
        public DataField dataField { get; set; }
        public Operator operators { get; set; }
        public string value { get; set; }
        public string condition { get; set; }
    }

    public class Operator
    {
        public int id { get; set; }
        public string type { get; set; }
        public string icon { get; set; }
    }
}
