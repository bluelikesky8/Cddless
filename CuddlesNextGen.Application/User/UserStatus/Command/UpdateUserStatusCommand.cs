using CuddlesNextGen.Domain.Interface;
using MediatR;

namespace CuddlesNextGen.Application.User.UserStatus.Command
{
    public class UpdateUserStatusCommand : IRequest<bool>
    {
        public int id { get; set; }
        public bool is_active { get; set; }
    }

    public class UpdateUserStatusCommandHandler : IRequestHandler<UpdateUserStatusCommand, bool>
    {
        private readonly IUserRepository _userRepo;
        public UpdateUserStatusCommandHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<bool> Handle(UpdateUserStatusCommand request, CancellationToken cancellationToken)
        {
            bool status = await _userRepo.UpdateUserStatus(request.id,request.is_active);
            return status;
        }
    }
}
