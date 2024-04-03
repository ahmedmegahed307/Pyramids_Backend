using Pyramids.Core.Enums;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> repository) : base(unitOfWork, repository) { }

        public Task<bool> AddProduct(Product product, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
