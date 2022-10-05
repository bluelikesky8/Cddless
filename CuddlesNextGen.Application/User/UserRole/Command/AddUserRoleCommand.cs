using CuddlesNextGen.Domain.Interface;
using MediatR;

namespace CuddlesNextGen.Application.User.UserRole.Command
{
    public class AddUserRoleCommand : IRequest<bool>
    {
        public int user_id { get; set; }
        public List<int> role_ids { get; set; }
    }

    public class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommand, bool>
    {
        private readonly IUserRepository _userRepo;
        public AddUserRoleCommandHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<bool> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            bool status = await _userRepo.AddUserRole(request.user_id,request.role_ids);
            return status;
        }
    }
}
