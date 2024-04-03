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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public CompanyRepository(AppDbContext context) : base(context)
        {
        }

    }
}
