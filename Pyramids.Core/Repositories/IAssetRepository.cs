using Pyramids.Core.Models;

namespace Pyramids.Core.Repositories
{
    public interface IAssetRepository : IGenericRepository<Asset>
    {
        Task<IEnumerable<Asset>> GetAllAssetsByClientId(int clientId);
        Task<IEnumerable<Asset>> GetAllAssetsBySiteId(int siteId);

    }
}
