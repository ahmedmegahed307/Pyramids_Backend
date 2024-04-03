using Pyramids.Core.Models;

namespace Pyramids.Core.IServices
{
    public interface IUserService : IService<User>
    {
        User? GetById(int id);
        User Get(string email);
        Task<IEnumerable<User>> GetEngineers(bool isActive, int companyId);
        User GetUserByEmail(string email);
        Task<bool> IsExist(string email);
        Task<string> UpdatePhoto(int userId, string logoUrl);

        bool ForgotPassword(string email);
        bool SendGeneratedPasswordEmail(string email, string password);
        Task<User> GetEngineerByName(string name,int companyId);

    }
}
