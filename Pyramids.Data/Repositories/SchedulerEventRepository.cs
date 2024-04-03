using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Data.Repositories;
using Pyramids.Data;

namespace Pyramids.Data.Repositories
{
    public class SchedulerEventRepository : Repository<SchedulerEvent>, ISchedulerEventRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public SchedulerEventRepository(AppDbContext context) : base(context)
        {
        }

    }
}
