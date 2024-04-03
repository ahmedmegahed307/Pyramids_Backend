using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Data.Repositories
{
    public class AssetModelRepository : Repository<AssetModel>, IAssetModelRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public AssetModelRepository(AppDbContext context) : base(context)
        {
        }
    }
}
