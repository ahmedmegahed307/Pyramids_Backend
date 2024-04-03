using Microsoft.EntityFrameworkCore;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Data.Repositories
{
    public class JobSubTypeRepository : Repository<JobSubType>, IJobSubTypeRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public JobSubTypeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<JobSubType>> GetAllSubTypesByTypeId(int typeId)
        {
            return await AppDbContext.JobSubTypes.Where(a => a.JobTypeId == typeId).ToListAsync();

        }
        public async Task<JobSubType> GetJobSubTypeByName(string name, int companyId)
        {
            // First, try to find an exact match on the name (case-insensitive).
          //  var exactMatch = await AppDbContext?.JobSubTypes.FirstOrDefaultAsync(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
           var exactMatch = await AppDbContext?.JobSubTypes.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower() && c.CompanyId==companyId);
            if (exactMatch != null)
            {
                return exactMatch;
            }

            // If no exact match is found, try to find a partial match (contains).
            var partialMatch = await AppDbContext?.JobSubTypes.FirstOrDefaultAsync(c => c.Name.ToLower().Contains(name.ToLower()) && c.CompanyId == companyId);

            if (partialMatch != null)
            {
                return partialMatch;
            }

            // If no partial match is found, try to find a similar sounding name.
            var similarJobSubType = await AppDbContext?.JobSubTypes.FirstOrDefaultAsync(c => AppDbContext.SoundsLike(c.Name.ToLower()) == AppDbContext.SoundsLike(name.ToLower()) && c.CompanyId == companyId);

            if (similarJobSubType != null)
            {
                return similarJobSubType;
            }

            // If no match is found in any condition, return null.
            return null;

        }
    }
}
