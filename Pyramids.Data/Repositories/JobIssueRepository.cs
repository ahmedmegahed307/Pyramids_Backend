
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Data.Repositories
{
   
    public class JobIssueRepository : Repository<JobIssue>, IJobIssueRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public JobIssueRepository(AppDbContext context) : base(context)
        {
        }

    }
}
