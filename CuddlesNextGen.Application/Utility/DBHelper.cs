using CuddlesNextGen.Application.Service;
using System.Text;

namespace PARSNextGen.Application.Utility
{
    public static class DBHelper
    {

        public static Dictionary<string, object> GenerateDynamicParameters(SearchFilter searchFilters)
        {
            var dynamicParam = new Dictionary<string, object>();

            if (searchFilters?.filters.Count > 0)
            {
                List<string> columnNames = new List<string>();

                foreach (var filter in searchFilters.filters)
                {
                    //In order to avoid duplicate column name when a query contains criateria for same column more than once
                    //e.g. first_name = mark and first_name = alley. In this case same field name will not be added in the dictnary key.
                    //so creatign a unique key for column like first_name_0 first_name_1 etc.
                    string uniqueColumnKey = filter.dataField.fieldName + "_" + columnNames.FindAll(c => c.Equals(filter.dataField.fieldName, StringComparison.OrdinalIgnoreCase)).Count;
                    columnNames.Add(filter.dataField.fieldName);

                    if (filter.operators.type.ToLower() == "equals")
                    {
                        dynamicParam.Add("@" + uniqueColumnKey, DBHelper.ConvertValueForDataType(filter.dataField.dataType, filter.value));
                    }

                    else if (filter.operators.type.ToLower() == "contains")
                    {
                        dynamicParam.Add("@" + uniqueColumnKey, "%" + filter.value + "%");
                    }
                    else if (filter.operators.type.ToLower() == "does not contains")
                    {
                        dynamicParam.Add("@" + uniqueColumnKey, "%" + filter.value + "%");
                    }
                    else if (filter.operators.type.ToLower() == "starts with")
                    {
                        dynamicParam.Add("@" + uniqueColumnKey, filter.value + "%");
                    }

                    else if (filter.operators.type.ToLower() == "ends with")
                    {
                        dynamicParam.Add("@" + uniqueColumnKey, "%" + filter.value);
                    }
                    else if (filter.operators.type.ToLower() == "empty")
                    {
                    }
                    else if (filter.operators.type.ToLower() == "not empty")
                    {
                    }
                    else if (filter.operators.type.ToLower() == "greater than")
                    {
                        dynamicParam.Add("@" + uniqueColumnKey, DBHelper.ConvertValueForDataType(filter.dataField.dataType, filter.value));
                    }
                    else if (filter.operators.type.ToLower() == "less than")
                    {
                        dynamicParam.Add("@" + uniqueColumnKey, DBHelper.ConvertValueForDataType(filter.dataField.dataType, filter.value));
                    }
                    else if (filter.operators.type.ToLower() == "greater than equal to")
                    {
                        dynamicParam.Add("@" + uniqueColumnKey, DBHelper.ConvertValueForDataType(filter.dataField.dataType, filter.value));
                    }
                    else if (filter.operators.type.ToLower() == "less than equal to")
                    {
                        dynamicParam.Add("@" + uniqueColumnKey, DBHelper.ConvertValueForDataType(filter.dataField.dataType, filter.value));
                    }
                    else if (filter.operators.type.ToLower() == "before")
                    {
                        dynamicParam.Add("@" + uniqueColumnKey, DBHelper.ConvertValueForDataType(filter.dataField.dataType, filter.value));
                    }
                    else if (filter.operators.type.ToLower() == "after")
                    {
                        dynamicParam.Add("@" + uniqueColumnKey, DBHelper.ConvertValueForDataType(filter.dataField.dataType, filter.value));
                    }
                    //else if (filter.operators.type.ToLower() == "all")
                    //{
                    //    dynamicParam.Add("@" + filter.dataField.fieldName, DBHelper.ConvertValueForDataType(filter.dataField.dataType, filter.value));
                    //}
                    else if (filter.operators.type.ToLower() == "true")
                    {

                    }
                    else if (filter.operators.type.ToLower() == "false")
                    {
                    }

                }
            }

            return dynamicParam;
        }

        public static dynamic ConvertValueForDataType(string dataType, string value)
        {

            if (dataType.Equals("Numeric", StringComparison.OrdinalIgnoreCase))
            {
                return Convert.ToDecimal(value);
            }
            else if (dataType.Equals("DateTime", StringComparison.OrdinalIgnoreCase))
            {
                return Convert.ToDateTime(value);
            }
            else if (dataType.Equals("bool", StringComparison.OrdinalIgnoreCase))
            {
                return Convert.ToBoolean(value);
            }
            else
                return value;
        }


        public static string GenerateDynamicWhereClause(SearchFilter searchFilters)
        {
            StringBuilder whereClause = new StringBuilder();
            if (searchFilters?.filters.Count > 0)
            {
                List<string> columnNames = new List<string>();

                foreach (var item in searchFilters.filters)
                {
                    //In order to avoid duplicate column name when a query contains criateria for same column more than once
                    //e.g. first_name = mark and first_name = alley. In this case same field name was not added in the dictnary key.
                    string uniqueColumnKey = item.dataField.fieldName + "_" + columnNames.FindAll(c => c.Equals(item.dataField.fieldName, StringComparison.OrdinalIgnoreCase)).Count;
                    columnNames.Add(item.dataField.fieldName);

                    if (whereClause.Length > 0)
                        whereClause.Append(" AND ");

                    if (item.operators.type.ToLower() == "equals")
                    {
                        whereClause.Append(item.dataField.fieldName);
                        whereClause.Append("=@");
                        whereClause.Append(uniqueColumnKey);
                    }
                    else if (item.operators.type.ToLower() == "contains")
                    {
                        whereClause.Append(item.dataField.fieldName);
                        whereClause.Append(" like @");
                        whereClause.Append(uniqueColumnKey);
                    }
                    else if (item.operators.type.ToLower() == "does not contains")
                    {
                        whereClause.Append(item.dataField.fieldName);
                        whereClause.Append(" not like @");
                        whereClause.Append(uniqueColumnKey);
                    }
                    else if (item.operators.type.ToLower() == "starts with")
                    {
                        whereClause.Append(item.dataField.fieldName);
                        whereClause.Append(" like @");
                        whereClause.Append(uniqueColumnKey);
                    }
                    else if (item.operators.type.ToLower() == "ends with")
                    {
                        whereClause.Append(item.dataField.fieldName);
                        whereClause.Append(" like @");
                        whereClause.Append(uniqueColumnKey);
                    }
                    else if (item.operators.type.ToLower() == "does not equals")
                    {
                        whereClause.Append(item.dataField.fieldName);
                        whereClause.Append("  != @");
                        whereClause.Append(uniqueColumnKey);
                    }
                    else if (item.operators.type.ToLower() == "empty")
                    {
                        whereClause.Append(item.dataField.fieldName);
                        whereClause.Append(" IS NULL ");
                    }
                    else if (item.operators.type.ToLower() == "not empty")
                    {
                        whereClause.Append(item.dataField.fieldName);
                        whereClause.Append(" IS NOT NULL ");
                    }
                    else if (item.operators.type.ToLower() == "greater than")
                    {
                        whereClause.Append(item.dataField.fieldName);
                        whereClause.Append(" >@");
                        whereClause.Append(uniqueColumnKey);
                    }
                    else if (item.operators.type.ToLower() == "less than")
                    {
                        whereClause.Append(item.dataField.fieldName);
                        whereClause.Append(" <@");
                        whereClause.Append(uniqueColumnKey);
                    }
                    else if (item.operators.type.ToLower() == "greater than equal to")
                    {
                        whereClause.Append(item.dataField.fieldName);
                        whereClause.Append(" >=@");
                        whereClause.Append(uniqueColumnKey);
                    }
                    else if (item.operators.type.ToLower() == "less than equal to")
                    {
                        whereClause.Append(item.dataField.fieldName);
                        whereClause.Append(" <=@");
                        whereClause.Append(uniqueColumnKey);
                    }
                    else if (item.operators.type.ToLower() == "before")
                    {
                        whereClause.Append(item.dataField.fieldName);
                        whereClause.Append(" >@");
                        whereClause.Append(uniqueColumnKey);
                    }
                    else if (item.operators.type.ToLower() == "after")
                    {
                        whereClause.Append(item.dataField.fieldName);
                        whereClause.Append(" <@");
                        whereClause.Append(uniqueColumnKey);
                    }
                    //else if (item.operators.type.ToLower() == "all")
                    //{
                    //    whereClause.Append(item.dataField.fieldName);
                    //    whereClause.Append(" <@");
                    //    whereClause.Append(item.dataField.fieldName);
                    //}
                    else if (item.operators.type.ToLower() == "true")
                    {
                        whereClause.Append(item.dataField.fieldName);
                        whereClause.Append(" = 1");
                    }
                    else if (item.operators.type.ToLower() == "false")
                    {
                        whereClause.Append(item.dataField.fieldName);
                        whereClause.Append(" = 0");
                    }
                }
            }
            return whereClause.ToString();
        }
    }
}
