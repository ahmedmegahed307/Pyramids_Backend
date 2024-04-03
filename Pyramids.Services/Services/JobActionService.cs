using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Service.Services
{
    public class JobActionService : IJobActionService
    {
        private readonly IJobActionRepository _jobActionRepository;

        public JobActionService(IJobActionRepository jobActionRepository)
        {

            _jobActionRepository = jobActionRepository;
        }

        public async Task<JobAction> AddAsync(JobAction jobAction)
        {
            return await _jobActionRepository.AddAsync(jobAction);
        }
        public async Task<IEnumerable<JobAction>> GetAllAsync(int jobId)
        {
            return await _jobActionRepository.GetAllAsync(jobId);

        }
    }
}
