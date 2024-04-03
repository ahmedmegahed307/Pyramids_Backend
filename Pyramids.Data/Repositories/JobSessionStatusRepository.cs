using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Data.Repositories
{
    public class JobSessionStatusRepository : Repository<JobSessionStatus>, IJobSessionStatusRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;
        public JobSessionStatusRepository(AppDbContext context) : base(context)
        {
        }
    }
}
