using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{

    public class JobStatusService : Service<JobStatus>, IJobStatusService
    {
        public JobStatusService(IUnitOfWork unitOfWork, IGenericRepository<JobStatus> repository) : base(unitOfWork, repository)
        {
        }

        public Task<JobStatus> GetJobStatusByName(string name)
        {
            return _unitOfWork.JobStatusRepository.GetJobStatusByName(name);
        }

    }
}
