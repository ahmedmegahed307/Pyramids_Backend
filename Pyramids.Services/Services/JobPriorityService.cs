using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{
    public class PriorityService : Service<Priority>, IPriorityService
    {
        public PriorityService(IUnitOfWork unitOfWork, IGenericRepository<Priority> repository) : base(unitOfWork, repository)
        {
        }

        public Task<Priority> GetJobPriorityByName(string name)
        {
            return _unitOfWork.PriorityRepository.GetJobPriorityByName(name);
        }
    }
}
