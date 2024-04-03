using Microsoft.EntityFrameworkCore;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Data.Repositories
{
    public class JobStatusRepository : Repository<JobStatus>, IJobStatusRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public JobStatusRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<JobStatus> GetJobStatusByName(string name)
        {
            var exactMatch = await AppDbContext?.JobStatuses.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());

            if (exactMatch != null)
            {
                return exactMatch;
            }

            // If no exact match is found, try to find a partial match (contains).
            var partialMatch = await AppDbContext?.JobStatuses.FirstOrDefaultAsync(c => c.Name.ToLower().Contains(name.ToLower()));

            if (partialMatch != null)
            {
                return partialMatch;
            }

            // If no partial match is found, try to find a similar sounding name.
            var similarStatus = await AppDbContext?.JobStatuses.FirstOrDefaultAsync(c => AppDbContext.SoundsLike(c.Name.ToLower()) == AppDbContext.SoundsLike(name.ToLower()));

            if (similarStatus != null)
            {
                return similarStatus;
            }

            // If no match is found in any condition, return null.
            return null;
        }
    }
}
