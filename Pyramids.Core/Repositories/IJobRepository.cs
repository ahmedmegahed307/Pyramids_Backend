using Pyramids.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyramids.Core.Enums;

namespace Pyramids.Core.Repositories
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        Task<Job> LogJobFromVisitAsync(User user, Job logJob, JobActionSourceEnum source);
        Task<IEnumerable<Job>> GetLastFiveJobsForSiteId(int siteId);
        Task<IEnumerable<Job>> GetAllJobsByClientIdAsync(int clientId, int? jobStatusId);

    }
}
