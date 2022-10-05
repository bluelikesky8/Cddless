using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuddlesNextGen.Domain.Interface
{
    public interface  IEmailService
    {

        bool OTP(int OTP, string email);
    }
}
