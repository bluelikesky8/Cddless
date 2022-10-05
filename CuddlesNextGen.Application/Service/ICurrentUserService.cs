using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuddlesNextGen.Application.Service
{
    public interface ICurrentUserService
    {
        long UserId { get; }
        long AccountId { get; }
        long ContactTypeId { get; }
        long AccountTypeId { get; }
        long LoggedInUserId { get; }
        string DataAccessKey { get; }
        string AccessLevel { get; }

    }
}
