using Microsoft.Data.SqlClient;


namespace AdoNetDemo.Data
{
    public class DBHelper
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DBHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
