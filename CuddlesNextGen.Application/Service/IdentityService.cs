using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace CuddlesNextGen.Application.Service
{
    public class IdentityService : IIdentityService
    {
        private IConfiguration _configuration;

        public IdentityService(IConfiguration config)
        {
            _configuration = config;
        }


        /// <summary>
        /// Generate Security Token For user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// /// <param name="roleSet"></param>
        /// <param name="permissionSet"></param>
        /// <returns></returns>
        public AuthToken GenerateSecurityToken(string userId, string userName, string roleSet, string permissionSet, long contactTypeId, long accountId, long accountTypeId, string dataAccessKey, string accessLevel)
        {
            AuthToken authToken = new AuthToken();

            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub, userName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64),
                    new Claim("UserId", userId),
                    new Claim("AccountId", accountId.ToString()),
                    new Claim("ContactTypeId", contactTypeId.ToString()),
                    new Claim("AccountTypeId", accountTypeId.ToString()),
                    new Claim("AccessLevel", accessLevel),
                    new Claim("DataAccessKey", dataAccessKey),
                    new Claim("UserPermission", permissionSet),
                    new Claim(ClaimTypes.Role, roleSet)
            };

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JwtConfig:Key"]));
            var jwt = new JwtSecurityToken(
                issuer: _configuration["JwtConfig:Issuer"],
                audience: _configuration["JwtConfig:Audience"],
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(double.Parse(_configuration["JwtConfig:expirationInMinutes"])),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );

            authToken.access_token = new JwtSecurityTokenHandler().WriteToken(jwt);
            authToken.token_expiry = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["JwtConfig:expirationInMinutes"]));

            return authToken;
        }

        /// <summary>
        /// Validates the plain text password against the hash.
        /// </summary>
        /// <param name="Password">The password to validate.</param>
        /// <param name="PasswordHash">Hash of the password to match against.</param>
        /// <returns>true if we have a match.</returns>
        public  bool ValidatePassword(string password, string passwordHash)
        {
             bool verified = BCrypt.Net.BCrypt.Verify(password, passwordHash);
            //Verify(password,passwordHash);
            if(verified == true)
            {
                return true;
            }else
            return false;
            
        }


        /// <summary>
        /// Creates a hash for a password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>Hash for the password.</returns>
        public string CreatePasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Function to generate a random passowrd string
        /// </summary>
        /// <returns></returns>
        public string GenerateRandomPassword()
        {
            StringBuilder pwdBuilder = new StringBuilder();
            StringBuilder builderLower = new StringBuilder();
            StringBuilder builderUpper = new StringBuilder();

            Random random = new Random();
            int iRanNum = random.Next(1000, 9999);

            char ch1, ch2;
            for (int i = 0; i < 4; i++)
            {
                ch1 = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builderLower.Append(ch1);
            }

            for (int n = 0; n < 2; n++)
            {
                ch2 = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builderUpper.Append(ch2);
            }

            pwdBuilder.Append(builderLower.ToString().ToLower());
            pwdBuilder.Append(iRanNum);
            pwdBuilder.Append(builderUpper);

            return pwdBuilder.ToString();
        }
    }
}
