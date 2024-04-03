using Pyramids.Core.Models;

namespace Pyramids.Core.Repositories
{
    public interface IJobActionRepository 
    {
        Task<IEnumerable<JobAction>> GetAllAsync(int jobId);
        Task<JobAction> AddAsync(JobAction jobAction);


    }
}
