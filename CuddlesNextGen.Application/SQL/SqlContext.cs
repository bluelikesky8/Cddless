using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CuddlesNextGen.Application.SQL
{
    public class SqlContext : ISqlContext, IDisposable
    {
        private readonly IConfiguration _config;
        private IDbConnection _connection;

        public SqlContext(IConfiguration config)
        {
            _config = config;
        }
        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Dispose();
            }
        }

        public IDbConnection GetOpenConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                _connection.Open();
            }
            return _connection;
        }

    }
}
