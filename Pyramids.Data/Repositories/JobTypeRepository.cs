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
    public class JobTypeRepository : Repository<JobType>, IJobTypeRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public JobTypeRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<JobType> GetJobTypeByName(string name, int companyId)
        {
            // First, try to find an exact match on the name (case-insensitive).
            var exactMatch = await AppDbContext?.JobTypes.FirstOrDefaultAsync(c =>c.Name.ToLower()==name.ToLower() && c.CompanyId== companyId);

            if (exactMatch != null)
            {
                return exactMatch;
            }

            // If no exact match is found, try to find a partial match (contains).
            var partialMatch = await AppDbContext?.JobTypes.FirstOrDefaultAsync(c => c.Name.ToLower().Contains(name.ToLower()) && c.CompanyId == companyId);

            if (partialMatch != null)
            {
                return partialMatch;
            }

            // If no partial match is found, try to find a similar sounding name.
            var similarJobType = await AppDbContext?.JobTypes.FirstOrDefaultAsync(c => AppDbContext.SoundsLike(c.Name.ToLower()) == AppDbContext.SoundsLike(name.ToLower()) && c.CompanyId == companyId);

            if (similarJobType != null)
            {
                return similarJobType;
            }

            // If no match is found in any condition, return null.
            return null;

        }
    }
}
