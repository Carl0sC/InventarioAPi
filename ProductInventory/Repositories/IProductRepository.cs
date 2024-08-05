using System.Collections.Generic;
using System.Threading.Tasks;
using ProductInventory.Models;

namespace ProductInventory.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task<IEnumerable<Product>> GetProductsByStateAsync(ProductState state);
        Task AddProductsBulkAsync(IEnumerable<Product> products);
    }
}
