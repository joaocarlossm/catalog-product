using CatalogProduct.Data;
using CatalogProduct.Models;
using CatalogProduct.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CatalogProduct.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CatalogContext _context;

        public UserRepository(CatalogContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
