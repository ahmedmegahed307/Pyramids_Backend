using Pyramids.Core.Models;

namespace Pyramids.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User Get(string email);
        User? GetById(int id);
        Task<IEnumerable<User>> GetEngineers(bool isActive, int companyId);
        Task<User> GetEngineerByName(string name, int companyId);

    }
}
