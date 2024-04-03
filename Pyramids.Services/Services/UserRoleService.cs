using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.IServices;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{
    public class UserRoleService : Service<UserRole>, IUserRoleService
    {
        public UserRoleService(IUnitOfWork unitOfWork, IGenericRepository<UserRole> repository) : base(unitOfWork, repository)
        {
        }
    }
}
