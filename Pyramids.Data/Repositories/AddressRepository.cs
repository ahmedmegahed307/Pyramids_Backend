using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Data.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public AddressRepository(AppDbContext context) : base(context)
        {
        }

    }
}
