using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperORM.Context
{
    public class DapperContext(IConfiguration configuration)
    {
        private readonly string ConnectionString = configuration.GetConnectionString("DBCS")!;


        public IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

    }


}
