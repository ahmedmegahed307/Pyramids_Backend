using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Service.Services
{
    public class ContactService : Service<Contact>, IContactService
    {
        public ContactService(IUnitOfWork unitOfWork, IGenericRepository<Contact> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<IEnumerable<Contact>> GetAllContactsByClientId(int clientId)
        {
            return await _unitOfWork.ContactRepository.GetAllContactsByClientId(clientId);
        }
    }
}
