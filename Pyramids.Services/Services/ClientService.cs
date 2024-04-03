using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.IServices;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{
    public class ClientService : Service<Client>, IClientService
    {

        public ClientService(IUnitOfWork unitOfWork, IGenericRepository<Client> repository) : base(unitOfWork, repository)
        {
        }

        public Task<Client> GetClientByName(string name, int companyId)
        {
            return _unitOfWork.ClientRepository.GetClientByName(name,companyId);
        }
    }
}
