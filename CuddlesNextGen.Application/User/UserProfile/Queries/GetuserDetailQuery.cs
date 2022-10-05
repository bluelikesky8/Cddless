using System.Data;
using CuddlesNextGen.Application.Service;
using CuddlesNextGen.Application.SQL;
using CuddlesNextGen.Application.Utility;
using Dapper;
using MediatR;

namespace CuddlesNextGen.Application.User.UserProfile.Queries
{
    public class GetuserDetailQuery : IRequest<List<UserDto>>
    { 
    }
    public class GetuserDetailQueryHandler : IRequestHandler<GetuserDetailQuery, List<UserDto>>
    {
        private readonly ISqlContext _dbCntx;
        private readonly ICurrentUserService _currentUserService;
        public GetuserDetailQueryHandler(ISqlContext dbCntx, ICurrentUserService currentUserService)
        {
            _dbCntx = dbCntx;
            _currentUserService= currentUserService;
        }
        public async Task<List<UserDto>> Handle(GetuserDetailQuery request, CancellationToken cancellationToken)
        {
            DynamicParameters dp = new DynamicParameters();
            List<UserDto> userdetails = null;
            var userProfileQuery = @"SELECT" +
                                   " ua.first_name,ua.middle_name,ua.user_image,ua.last_name,ua.email,ua.job_title,ua.home_phone,ua.mobile_phone,ua.country ,ua.company_works_for ,ua.business_phone from vw_userdetail AS ua where id=@userId";

            dp.Add("@userId", _currentUserService.LoggedInUserId);

            using (var connection = _dbCntx.GetOpenConnection())
            {
                userdetails = (List<UserDto>)await connection.QueryAsyncWithRetry<UserDto>(userProfileQuery,dp ,commandType: CommandType.Text);
            }
            return userdetails;
        }
    }
}
