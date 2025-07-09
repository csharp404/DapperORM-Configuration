using Dapper;
using DapperORM.Context;

namespace DapperORM.Repositories
{
    public class User(DapperContext context) : IUser
    {
        public async Task<bool> CreateUserAsync(string name)
        {
            using (var connect = context.CreateConnection())
            {
                string query = "exec CreateUser @name";
                var data = connect.Execute(query, new { name = name });
                return true;

            }
        }

        public int Update(int id, string name)
        {
            using (var connect = context.CreateConnection()) {
                string query = "exec updateUser @id , @name";
                int data = connect.Execute(query, new { id = id, name = name });
                return data;



            }
        }
    }
}
