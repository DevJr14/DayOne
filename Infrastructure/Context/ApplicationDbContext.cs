using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Context
{
    public class ApplicationDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
