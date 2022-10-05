namespace CuddlesNextGen.Domain.Interface
{
    public interface IAuthServiceRepository
    {
        Task<bool> UpdatePassword(long userId, string passwordHash);
        Task<string> GenerateResetPasswordTokenByUserId(long userId);
    }
}
