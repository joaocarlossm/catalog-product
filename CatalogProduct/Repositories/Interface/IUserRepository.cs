using CatalogProduct.Models;
using System.Threading.Tasks;

namespace CatalogProduct.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);
    }
}