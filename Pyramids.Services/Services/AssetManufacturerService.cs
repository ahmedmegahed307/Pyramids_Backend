using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{
    public class AssetManufacturerService : Service<AssetManufacturer>, IAssetManufacturerService
    {
        public AssetManufacturerService(IUnitOfWork unitOfWork, IGenericRepository<AssetManufacturer> repository) : base(unitOfWork, repository)
        {
        }
    }
}
