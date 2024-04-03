using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Data.Repositories
{
    public class AssetManufacturerRepository : Repository<AssetManufacturer>, IAssetManufacturerRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public AssetManufacturerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
