using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CuddlesNextGen.Application.SQL
{
    public interface ISqlContext
    {
        IDbConnection GetOpenConnection();
    }
}
