using CatalogProduct.Models;
using CatalogProduct.Queries;
using CatalogProduct.Repositories.Interface;
using System.Threading.Tasks;

namespace CatalogProduct.Handlers
{
    public class GetUserByUsernameQueryHandler
    {
        private readonly IUserRepository _userRepository;

        public GetUserByUsernameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByUsernameQuery query)
        {
            return await _userRepository.GetUserByUsernameAsync(query.Username);
        }
    }
}
