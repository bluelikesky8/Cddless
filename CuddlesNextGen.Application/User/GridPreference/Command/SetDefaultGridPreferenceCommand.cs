using CuddlesNextGen.Application.Service;
using CuddlesNextGen.Domain.Interface;
using MediatR;

namespace CuddlesNextGen.Application.User.GridPreference.Command
{

    public class SetDefaultGridPreferenceCommand : IRequest<bool>
    {
        public string entity_name { get; set; }
        public string view_column_json { get; set; }
    }

    public class SetDefaultGridColumnPreferenceCommandHandler : IRequestHandler<SetDefaultGridPreferenceCommand, bool>
    {
        private readonly IUserRepository _userRepo;
        private readonly ICurrentUserService _currentUserContext;
        public SetDefaultGridColumnPreferenceCommandHandler(IUserRepository userRepo, ICurrentUserService currentUserContext)
        {
            _userRepo = userRepo;
            _currentUserContext = currentUserContext;
        }
        public async Task<bool> Handle(SetDefaultGridPreferenceCommand request, CancellationToken cancellationToken)
        {
            bool status = await _userRepo.SetDefaultGridColumnPreference(request.entity_name, _currentUserContext.AccountTypeId, request.view_column_json, _currentUserContext.UserId);
            return status;
        }
    }

}
