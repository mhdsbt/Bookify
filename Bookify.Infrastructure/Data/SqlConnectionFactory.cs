using Bookify.Application.Abstraction.Data;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Infrastructure.Data
{
    internal sealed class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionstring)
        {
            _connectionString = connectionstring;
        }
        public IDbConnection CreateConnection()
        {
            var connection = new NpgsqlConnection(_connectionString);

            connection.Open();

            return connection;
        }
    }
}
