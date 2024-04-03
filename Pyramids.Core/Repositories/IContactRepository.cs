using Pyramids.Core.Models;

namespace Pyramids.Core.Repositories
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetAllContactsByClientId(int clientId);

    }
}
