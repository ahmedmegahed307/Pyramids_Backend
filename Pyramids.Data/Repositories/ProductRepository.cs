using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;
        public ProductRepository(AppDbContext context) : base(context) { }
    }
}
