using System.Data;
using MediatR;
using Dapper;
using CuddlesNextGen.Application.UserAuth.UserLogin.Queries;
using CuddlesNextGen.Application.SQL;
using CuddlesNextGen.Application.Utility;

namespace CuddlesNextGen.Application.Permissions.Query
{
    public class GetUserPersonalizedCategoryByUserIdQuery : IRequest<List<UserPersonalizedSettingDto>>
    {
        public Guid user_id { get; set; }
    }

    public class GetUserPreferenceByUserIdQueryHandler : IRequestHandler<GetUserPersonalizedCategoryByUserIdQuery, List<UserPersonalizedSettingDto>>
    {
        private readonly ISqlContext _dbCntx;
        public GetUserPreferenceByUserIdQueryHandler(ISqlContext dbCntx)
        {
            _dbCntx = dbCntx;
        }

        public async Task<List<UserPersonalizedSettingDto>> Handle(GetUserPersonalizedCategoryByUserIdQuery request, CancellationToken cancellationToken)
        {
            List<UserPersonalizedSettingDto> userPreferenceList = new List<UserPersonalizedSettingDto>();
            DynamicParameters parameters = new DynamicParameters();
            var procedure = "sp_get_user_personalized_category_by_user_id";
            using (var connection = _dbCntx.GetOpenConnection())
            {
                parameters.Add("@pUserId", request.user_id);
                userPreferenceList = (List<UserPersonalizedSettingDto>)await connection.QueryAsyncWithRetry<UserPersonalizedSettingDto>(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return userPreferenceList;


        }
    }
}
