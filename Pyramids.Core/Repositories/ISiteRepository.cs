using Pyramids.Core.Models;

namespace Pyramids.Core.Repositories
{
    public interface ISiteRepository : IGenericRepository<Site>
    {
        Task<IEnumerable<Site>> GetAllSitesByClientId(int clientId);
        Task<Site> GetSiteByName(string name,int clientId);

    }
}
