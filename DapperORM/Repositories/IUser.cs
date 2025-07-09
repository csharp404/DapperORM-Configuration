using DapperORM.Dto;
using DapperORM.Entities;

namespace DapperORM.Repositories
{
    public interface IUser
    {
        public Task<bool> CreateUserAsync(string name);
        public int Update(int id, string name);
        public Task<MyMultipleData> GetMultipleData(int id);
    }
}
