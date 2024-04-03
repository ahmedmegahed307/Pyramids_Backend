using Microsoft.EntityFrameworkCore;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Data.Repositories
{
    public class AssetRepository : Repository<Asset>, IAssetRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public AssetRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Asset>> GetAllAssetsByClientId(int clientId)
        {
            return await AppDbContext.Assets.Where(a => a.ClientId == clientId).ToListAsync();
        }
        public async Task<IEnumerable<Asset>> GetAllAssetsBySiteId(int siteId)
        {
            return await AppDbContext.Assets.Where(a => a.SiteId == siteId).ToListAsync();
        }
    }
}
