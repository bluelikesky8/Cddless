using MediatR;
using CuddlesNextGen.Domain.Interface;
using CuddlesNextGen.Application.Service;

namespace CuddlesNextGen.Application.User.GridPreference.Command
{
    public class SetDefaultGridFilterPreferenceCommand : IRequest<bool>
    {
        public string entity_name { get; set; }
        public string view_column_json { get; set; }
    }

    public class SetDefaultGridFilterPreferenceCommandHandler : IRequestHandler<SetDefaultGridFilterPreferenceCommand, bool>
    {
        private readonly IUserRepository _userRepo;
        private readonly ICurrentUserService _currentUserContext;
        public SetDefaultGridFilterPreferenceCommandHandler(IUserRepository userRepo, ICurrentUserService currentUserContext)
        {
            _userRepo = userRepo;
            _currentUserContext = currentUserContext;
        }
        public async Task<bool> Handle(SetDefaultGridFilterPreferenceCommand request, CancellationToken cancellationToken)
        {
            bool status = await _userRepo.SetDefaultGridColumnFilterPreference(request.entity_name, _currentUserContext.AccountTypeId, request.view_column_json, _currentUserContext.UserId);
            return status;
        }
    }
   
}
