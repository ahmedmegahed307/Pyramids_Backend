using Pyramids.Core.Enums;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{
    public class AssetService : Service<Asset>, IAssetService
    {
        public AssetService(IUnitOfWork unitOfWork, IGenericRepository<Asset> repository) : base(unitOfWork, repository)
        {
            
        }
        public async Task<bool> AddAssetAsync(Asset asset)
        {
            try
            {

                await _unitOfWork.AssetRepository.AddAsync(asset);
                await _unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                // todo: log
                return false;
            }
        }

        public async Task<IEnumerable<Asset>> GetAllAssetsByClientId(int clientId)
        {
            return await _unitOfWork.AssetRepository.GetAllAssetsByClientId(clientId);
        }

        public async Task<IEnumerable<Asset>> GetAllAssetsBySiteId(int siteId)
        {
            return await _unitOfWork.AssetRepository.GetAllAssetsBySiteId(siteId);
        }
    }
}
