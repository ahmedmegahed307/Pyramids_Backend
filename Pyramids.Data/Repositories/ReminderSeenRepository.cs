using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Data.Repositories
{
    public class ReminderSeenRepository : Repository<ReminderSeen>, IReminderSeenRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public ReminderSeenRepository(AppDbContext context) : base(context)
        {
        }
    }
}
