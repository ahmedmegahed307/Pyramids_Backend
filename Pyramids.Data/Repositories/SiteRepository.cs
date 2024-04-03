using Microsoft.EntityFrameworkCore;
using Pyramids.Core.Enums;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Data.Repositories
{
    public class SiteRepository : Repository<Site>, ISiteRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public SiteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Site>> GetAllSitesByClientId(int clientId)
        {
            return await AppDbContext.Sites.Where(a=>a.ClientId ==clientId).ToListAsync();
        }

        public async Task<Site> GetSiteByName(string name, int clientId)
        {
            // First, try to find an exact match on the name (case-insensitive).
            var exactMatch = await AppDbContext?.Sites.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower() && c.ClientId == clientId);

            if (exactMatch != null)
            {
                return exactMatch;
            }

            // If no exact match is found, try to find a partial match (contains).
            var partialMatch = await AppDbContext?.Sites.FirstOrDefaultAsync(c => c.Name.ToLower().Contains(name.ToLower()) && c.ClientId == clientId);

            if (partialMatch != null)
            {
                return partialMatch;
            }

            // If no partial match is found, try to find a similar sounding name.
            var similarSite = await AppDbContext?.Sites.FirstOrDefaultAsync(c => AppDbContext.SoundsLike(c.Name.ToLower()) == AppDbContext.SoundsLike(name.ToLower()) && c.ClientId == clientId);

            if (similarSite != null)
            {
                return similarSite;
            }

            // If no match is found in any condition, return null.
            return null;

        }
    }
}
