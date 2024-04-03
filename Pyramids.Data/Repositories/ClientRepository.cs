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
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public ClientRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Client> GetClientByName(string name, int companyId)
        {
            
            var client = await AppDbContext?.Clients.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower() && c.CompanyId==companyId);

            if (client != null)
            {
                return client;
            }

            // If no exact match is found, try to find a client with a similar sounding name.
            var similarClient = await AppDbContext?.Clients.FirstOrDefaultAsync(c => AppDbContext.SoundsLike(c.Name.ToLower()) == AppDbContext.SoundsLike(name.ToLower()) && c.CompanyId == companyId);

            if (similarClient != null)
            {
                return similarClient;
            }

            // If no match is found using similarity, fall back to a simple substring containment check.
            var substringMatch = await AppDbContext?.Clients.FirstOrDefaultAsync(c => c.Name.ToLower().Contains(name.ToLower()) && c.CompanyId == companyId);

            if (substringMatch != null)
            {
                return substringMatch;
            }

            // If no match is found in any condition, return 0.
            return null;


        }
    }
}
