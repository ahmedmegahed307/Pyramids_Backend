using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{
    public class AssetTypeService : Service<AssetType>, IAssetTypeService
    {
        public AssetTypeService(IUnitOfWork unitOfWork, IGenericRepository<AssetType> repository) : base(unitOfWork, repository)
        {
        }
    }
}
