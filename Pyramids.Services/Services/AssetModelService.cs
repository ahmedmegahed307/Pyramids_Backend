using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{
    public class AssetModelService : Service<AssetModel>, IAssetModelService
    {
        public AssetModelService(IUnitOfWork unitOfWork, IGenericRepository<AssetModel> repository) : base(unitOfWork, repository)
        {
        }
    }
}
