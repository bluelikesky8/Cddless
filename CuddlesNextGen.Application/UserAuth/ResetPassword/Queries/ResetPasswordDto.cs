using System;
using System.Collections.Generic;
using System.Text;

namespace CuddlesNextGen.Application.UserAuth.ResetPassword.Queries
{
    public class ResetPasswordDto
    {
        public int id { get; set; }
        public string user_name { get; set; }
        public bool is_active { get; set; }
        public bool is_locked { get; set; }
        public Guid password_reset_token { get; set; }
        public DateTime password_reset_on { get; set; }
    }
}
