using CuddlesNextGen.Application.Utility;
using PARSNextGen.Application.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuddlesNextGen.Application.Service
{
    public interface ICustomMessageService
    {
        CustomMessage GetCustomMessageByShortCode(string shortCode);
    }
}
