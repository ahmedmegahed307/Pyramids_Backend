using Pyramids.Core.Models;

namespace Pyramids.Core.IServices
{
    public interface IAssetService : IService<Asset>
    {
        Task<bool> AddAssetAsync(Asset asset);
        Task<IEnumerable<Asset>> GetAllAssetsByClientId(int clientId);
        Task<IEnumerable<Asset>> GetAllAssetsBySiteId(int siteId);

    }
}
