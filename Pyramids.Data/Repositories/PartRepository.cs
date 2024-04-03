using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Data.Repositories
{

    public class JobPartRepository : Repository<JobPart>, IJobPartRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public JobPartRepository(AppDbContext context) : base(context)
        {
        }

    }
}
