using CuddlesNextGen.Domain.Interface;
using MediatR;

namespace CuddlesNextGen.Application.UserAuth.ChangePassword.Command
{
    public class ChangePasswordCommand : IRequest<bool>
    {
        public long user_id { get; set; }
        public string new_password { get; set; }
    }
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IAuthServiceRepository _authRepo;
        public ChangePasswordCommandHandler(IAuthServiceRepository authRepo)
        {
            _authRepo = authRepo;
        }

        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            bool result = await _authRepo.UpdatePassword(request.user_id, request.new_password);
            return result;
        }
    }
}
