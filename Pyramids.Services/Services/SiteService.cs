using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{
    public class SiteService : Service<Site>, ISiteService
    {
        public SiteService(IUnitOfWork unitOfWork, IGenericRepository<Site> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<IEnumerable<Site>> GetAllSitesByClientId(int clientId)
        {
            return await _unitOfWork.SiteRepository.GetAllSitesByClientId(clientId);
        }
        public Task<Site> GetSiteByName(string name, int clientId)
        {
            return _unitOfWork.SiteRepository.GetSiteByName(name,clientId);
        }
    }
}
