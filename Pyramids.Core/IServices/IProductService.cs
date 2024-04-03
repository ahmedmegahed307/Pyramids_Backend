using Pyramids.Core.Models;

namespace Pyramids.Core.IServices
{
    public interface IProductService : IService<Product>
    {
        Task<bool> AddProduct(Product product, int quantity);
    }
}
