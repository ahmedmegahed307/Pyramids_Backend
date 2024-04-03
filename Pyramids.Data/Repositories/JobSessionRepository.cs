using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Data.Repositories
{
    public class JobSessionRepository : Repository<JobSession>, IJobSessionRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;
        public JobSessionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
