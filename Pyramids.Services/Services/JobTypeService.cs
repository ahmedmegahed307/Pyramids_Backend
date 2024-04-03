using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{
    public class JobTypeService : Service<JobType>, IJobTypeService
    {
        public JobTypeService(IUnitOfWork unitOfWork, IGenericRepository<JobType> repository) : base(unitOfWork, repository)
        {
        }

        public Task<JobType> GetJobTypeByName(string name, int companyId)
        {
            return _unitOfWork.JobTypeRepository.GetJobTypeByName(name,companyId);
        }

    }
}
