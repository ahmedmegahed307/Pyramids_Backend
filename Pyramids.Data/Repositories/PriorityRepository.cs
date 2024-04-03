using Microsoft.EntityFrameworkCore;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Data.Repositories
{
    public class PriorityRepository : Repository<Priority>, IPriorityRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public PriorityRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Priority> GetJobPriorityByName(string name)
        {
            var exactMatch = await AppDbContext?.Priorities.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());

            if (exactMatch != null)
            {
                return exactMatch;
            }

            // If no exact match is found, try to find a partial match (contains).
            var partialMatch = await AppDbContext?.Priorities.FirstOrDefaultAsync(c => c.Name.ToLower().Contains(name.ToLower()));

            if (partialMatch != null)
            {
                return partialMatch;
            }

            // If no partial match is found, try to find a similar sounding name.
            var similarPriority = await AppDbContext?.Priorities.FirstOrDefaultAsync(c => AppDbContext.SoundsLike(c.Name.ToLower()) == AppDbContext.SoundsLike(name.ToLower()));

            if (similarPriority != null)
            {
                return similarPriority;
            }

            // If no match is found in any condition, return null.
            return null;
        }
    }
}
