using CuddlesNextGen.Domain.Interface;
using MediatR;

namespace CuddlesNextGen.Application.UserAuth.ResetPassword.Command
{
    public class ResetPasswordCommand : IRequest<string>
    {
        public Guid user_id { get; set; }
    }

    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, string>
    {
        private readonly IAuthServiceRepository _authRepo;
        public ResetPasswordCommandHandler(IAuthServiceRepository authRepo)
        {
            _authRepo = authRepo;
        }

        public async Task<string> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            string result = await _authRepo.GenerateResetPasswordTokenByUserId(request.user_id);
            return result;
        }
    }
}