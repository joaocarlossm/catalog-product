using CatalogProduct.Models;

namespace CatalogProduct.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product produto);
        Task UpdateAsync(Product produto);
        Task DeleteAsync(int id);
    }
}
