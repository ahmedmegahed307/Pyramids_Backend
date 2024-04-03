using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{
    
    public class JobIssueService : Service<JobIssue>, IJobIssueService
    {
        public JobIssueService(IUnitOfWork unitOfWork, IGenericRepository<JobIssue> repository) : base(unitOfWork, repository)
        {
        }
    }
}
