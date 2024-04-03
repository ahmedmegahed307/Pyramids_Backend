using Pyramids.Core.Enums;
using Pyramids.Core.Models;

namespace Pyramids.Core.IServices
{
    public interface IJobService : IService<Job>
    {
        Task<IEnumerable<Job>> GetAllJobsByClientIdAsync(int clientId,int? jobStatusId);
        Task<Job> UpdateJobStatusAsync(int jobId, int jobStatusId,string? cancelReason, int? engineerId);
        Task<Job> UpdateJobScheduleDate(int jobId, DateTime? scheduleDateEnd, int? ModifiedByUserId);
        Task<Job> LogJobFromVisitAsync(User currentUser, Job logJob, JobActionSourceEnum source);
        Task<IEnumerable<Job>> GetLastFiveJobsForSiteId(int siteId);

    }
}
