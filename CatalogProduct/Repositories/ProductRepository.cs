using CatalogProduct.Data;
using CatalogProduct.Models;
using CatalogProduct.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CatalogProduct.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext _context;

        public ProductRepository(CatalogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _context.Product.ToListAsync();

        public async Task<Product> GetByIdAsync(int id)
        {
            Product? produto = await _context.Product.FindAsync(id);
            return produto;
        }

        public async Task AddAsync(Product produto)
        {
            await _context.Product.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product produto)
        {
            _context.Product.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await GetByIdAsync(id);
            if (produto != null)
            {
                _context.Product.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }
    }
}