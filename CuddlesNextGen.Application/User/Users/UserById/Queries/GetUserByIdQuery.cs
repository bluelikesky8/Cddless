using CuddlesNextGen.Application.SQL;
using CuddlesNextGen.Application.Utility;
using Dapper;
using FluentValidation;
using MediatR;
using System.Data;

namespace CuddlesNextGen.Application.User.Users.UserById.Queries
{
    public class GetUserByIdQuery : IRequest<UserByIdDto>
    {
        public long id { get; set; }
    }
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserByIdDto>
    {
        private readonly ISqlContext _dbCntx;

        public GetUserByIdQueryHandler(ISqlContext dbCntx)
        {
            _dbCntx = dbCntx;
        }

        public async Task<UserByIdDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            UserByIdDto user = null;
            DynamicParameters parameters = new DynamicParameters();
            using (var connection = _dbCntx.GetOpenConnection())
            {
                var querycolumns = @"SELECT " +
                                   "u.id,CONCAT(u.first_name, ' ', ' ', u.last_name) AS name, u.business_phone as contact,u.email,u.is_active,u.created_on " +
                                   "from vw_userdetail u where u.id=@pId";

                parameters.Add("@pId", request.id);
                user = await connection.QueryFirstOrDefaultAsyncWithRetry<UserByIdDto>(querycolumns, parameters, commandType: CommandType.Text);
            }
            return user;
        }

        public class GetUserByIdQueryValidator : AbstractValidator<UserByIdDto>
        {
            public GetUserByIdQueryValidator()
            {
                RuleFor(x => x.id).NotEmpty();
            }
        }
    }
}
