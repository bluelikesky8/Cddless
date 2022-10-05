namespace CuddlesNextGen.Application.Service
{
    public interface IIdentityService
    {
        bool ValidatePassword(string password, string passwordHash);
        AuthToken GenerateSecurityToken(string userId, string userName, string roleSet, string permissionSet, long contactTypeId, long accountId, long accountTypeId, string dataAccessKey, string accessLevel);
        string CreatePasswordHash(string password);
        string GenerateRandomPassword();
    }
}
