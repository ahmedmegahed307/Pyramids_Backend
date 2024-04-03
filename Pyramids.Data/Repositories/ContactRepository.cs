using Microsoft.EntityFrameworkCore;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Data.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public ContactRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Contact>> GetAllContactsByClientId(int clientId)
        {
            return await AppDbContext.Contacts.Where(a => a.ClientId == clientId).ToListAsync();
        }

    }
}
