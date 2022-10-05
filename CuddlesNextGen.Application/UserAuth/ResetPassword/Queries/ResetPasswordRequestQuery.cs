using System.Data;
using CuddlesNextGen.Application.SQL;
using CuddlesNextGen.Application.Utility;
using Dapper;
using MediatR;

namespace CuddlesNextGen.Application.UserAuth.ResetPassword.Queries
{
    public class ResetPasswordRequestQuery : IRequest<ResetPasswordDto>
    {
        public string reset_request_id { get; set; }
    }

    public class ResetPasswordRequestQueryHandler : IRequestHandler<ResetPasswordRequestQuery, ResetPasswordDto>
    {
        private readonly ISqlContext _sqlCtx;
        public ResetPasswordRequestQueryHandler(ISqlContext sqlContext)
        {
            _sqlCtx = sqlContext;
        }

        public async Task<ResetPasswordDto> Handle(ResetPasswordRequestQuery request, CancellationToken cancellationToken)
        {
            ResetPasswordDto resetPasswordDto = new ResetPasswordDto();
            DynamicParameters dp = new DynamicParameters();
            using (var connection = _sqlCtx.GetOpenConnection())
            {
                var query = "sp_get_user_auth_detail_by_reset_token";
                dp.Add("@pResetId", request.reset_request_id);
                resetPasswordDto = await connection.QueryFirstOrDefaultAsyncWithRetry<ResetPasswordDto>(query, dp, commandType: CommandType.StoredProcedure);
            }
            return resetPasswordDto;
        }
    }
}
