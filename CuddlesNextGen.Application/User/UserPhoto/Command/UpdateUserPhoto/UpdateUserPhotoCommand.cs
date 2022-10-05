using CuddlesNextGen.Domain.Interface;
using MediatR;

namespace CuddlesNextGen.Application.User.UserPhoto.Command
{
    public class UpdateUserPhotoCommand : IRequest<bool>
    {
        public int user_id { get; set; }
        public string image_url { get; set; }
    }

    public class UpdateUserPhotoCommandHandler : IRequestHandler<UpdateUserPhotoCommand, bool>
    {
        private readonly IUserRepository _userRepo;
        public UpdateUserPhotoCommandHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<bool> Handle(UpdateUserPhotoCommand request, CancellationToken cancellationToken)
        {
            bool result = await _userRepo.UpdateUserPhotoByUserId(request.user_id, request.image_url);
            return result;
        }
    }

}
