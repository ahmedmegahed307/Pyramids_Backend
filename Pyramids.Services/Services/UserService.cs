using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;
using Pyramids.Shared.Helper;

namespace Pyramids.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IGenericRepository<User> _repository;

        public UserService(IUnitOfWork unitOfWork, IGenericRepository<User> repository) : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetEngineers(bool isActive, int companyId)
        {
            return await _unitOfWork.UserRepository.GetEngineers(isActive,companyId);
        }

        public User GetUserByEmail(string email)
        {
            return _unitOfWork.UserRepository.Get(email);
        }
        public User? GetById(int id)
        {
            return _unitOfWork.UserRepository.GetById(id);
        }
        public User Get(string email)
        {
            return _unitOfWork.UserRepository.Get(email);
        }

        public async Task<bool> IsExist(string email)
        {
            return await _unitOfWork.UserRepository.ExistsAsync(x => x.Email == email);
        }

        public Task<User> GetEngineerByName(string name, int companyId)
        {
            return _unitOfWork.UserRepository.GetEngineerByName(name, companyId);
        }
        public async Task<string> UpdatePhoto(int userId, string photoUrl)
        {
            var user = await _repository.GetByIdAsync(userId);
            user.ProfilePhotoUrl = photoUrl;

            await _unitOfWork.CommitAsync();
            return user.ProfilePhotoUrl;

        }

        public bool ForgotPassword(string email)
        {
            throw new NotImplementedException();
        }

        public bool SendGeneratedPasswordEmail(string email, string password)
        {
            throw new NotImplementedException();
        }
    }

}
