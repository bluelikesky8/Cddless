namespace CuddlesNextGen.Domain.Interface
{
    public interface IRoleRepository
    {
        Task<bool> CreateRole(string roleName, string roleDescription);
        Task<bool> UpdateRoleStatus(int roleId, bool roleStatus);
        Task<bool> UpdateRoleById(int roleId, string roleName, string roleDescription);
        Task<bool> DeleteRoleById(int roleId);
        Task<bool> CreateRolePermission(long role_id, List<long> permission_ids);
    }
}
