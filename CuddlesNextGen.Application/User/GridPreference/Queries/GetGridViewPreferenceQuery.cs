using CuddlesNextGen.Application.Service;
using CuddlesNextGen.Application.SQL;
using CuddlesNextGen.Application.Utility;
using FluentValidation;
using MediatR;
using System.Data;

namespace CuddlesNextGen.Application.User.UserViewPreference.Queries
{
    public class GetGridViewPreferenceQuery : IRequest<GridPreferenceDto>
    {
        public string entity_name { get; set; }
      
    }
    public class GetGridViewPreferenceQueryHandler : IRequestHandler<GetGridViewPreferenceQuery, GridPreferenceDto>
    {
        private readonly ISqlContext _dbCntx;
        private readonly ICurrentUserService _currentUserContext;
        public GetGridViewPreferenceQueryHandler(ISqlContext dbCntx, ICurrentUserService currentUserContext)
        {
            _dbCntx = dbCntx;
            _currentUserContext = currentUserContext;
        }
        public async Task<GridPreferenceDto> Handle(GetGridViewPreferenceQuery request, CancellationToken cancellationToken)
        {
            GridPreferenceDto userPreference = new  GridPreferenceDto();
            var procedure = "sp_get_viewpreference_by_entity_name";

            using (var connection = _dbCntx.GetOpenConnection())
            {
                var values = new { pentity_name = request.entity_name , paccount_type_id  = _currentUserContext.AccountTypeId , user_id = _currentUserContext.UserId};
               
                userPreference =  await connection.QueryFirstOrDefaultAsyncWithRetry<GridPreferenceDto>(procedure, values, commandType: CommandType.StoredProcedure);
            }
            return userPreference;
        }
        public class GridViewPreferenceQueryValidator : AbstractValidator<GetGridViewPreferenceQuery>
        {
            public GridViewPreferenceQueryValidator()
            {
                RuleFor(p => p.entity_name).NotEmpty();
            }
        }
    }
}
