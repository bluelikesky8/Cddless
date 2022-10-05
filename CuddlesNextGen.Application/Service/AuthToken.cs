using System;

namespace CuddlesNextGen.Application.Service
{
    public class AuthToken
    { 
        public string access_token { get; set; }
        public DateTime token_expiry { get; set; }
    }
}
