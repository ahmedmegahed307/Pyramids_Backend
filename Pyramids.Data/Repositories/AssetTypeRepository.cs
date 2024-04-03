using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Data.Repositories
{
    public class AssetTypeRepository : Repository<AssetType>, IAssetTypeRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public AssetTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
