namespace DapperORM.Repositories
{
    public interface IUser
    {
        public Task<bool> CreateUserAsync(string name);
        public int Update(int id, string name);
    }
}
