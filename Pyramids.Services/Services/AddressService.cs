using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;


namespace Pyramids.Service.Services
{
    public class AddressService : Service<Address>, IAddressService
    {
        public AddressService(IUnitOfWork unitOfWork, IGenericRepository<Address> repository) : base(unitOfWork, repository)
        {
        }
    }
}
