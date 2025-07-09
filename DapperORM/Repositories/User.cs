using Dapper;
using DapperORM.Context;
using DapperORM.Dto;
using DapperORM.Entities;
using System.Threading.Tasks;

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

        public async Task<MyMultipleData> GetMultipleData(int id)
        {
            string query = @"
    SELECT TOP (1000) id, name FROM [testStoredProcedure].[dbo].[company];
    SELECT TOP (1000) id, name FROM [testStoredProcedure].[dbo].[users] WHERE id = @id";

            using var connect = context.CreateConnection();
            using (var multipleQuery = await connect.QueryMultipleAsync(query, new { id }))
            {
                var user = await multipleQuery.ReadFirstOrDefaultAsync<Entities.User>();
                var coms = (await multipleQuery.ReadAsync<company>()).ToList();

                return new MyMultipleData { companies = coms, user = user };
            }


        }

        public int Update(int id, string name)
        {
            using (var connect = context.CreateConnection())
            {
                string query = "exec updateUser @id , @name";
                int data = connect.Execute(query, new { id = id, name = name });
                return data;



            }
        }
    }
}
