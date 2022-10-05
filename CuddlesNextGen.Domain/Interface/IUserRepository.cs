using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CuddlesNextGen.Domain.Interface
{
    public interface IUserRepository
    {
        Task<bool> UpdateUserStatus(int id, bool is_active);
        Task<bool> UpdateUserPhotoByUserId(int userId, string imageUrl);
        Task<bool> AddUserRole(int user_id, List<int> role_ids); 
        Task<bool> SetDefaultGridColumnPreference(string entity_name, long account_type_id, string view_column_json, long userid);
        Task<bool> SetDefaultGridColumnFilterPreference(string entity_name, long account_type_id, string view_column_json, long userid);
    }
}
