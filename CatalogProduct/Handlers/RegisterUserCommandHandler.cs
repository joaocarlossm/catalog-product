using CatalogProduct.Commands;
using CatalogProduct.Models;
using CatalogProduct.Repositories.Interface;
using System.Threading.Tasks;

namespace CatalogProduct.Handlers
{
    public class RegisterUserCommandHandler
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(RegisterUserCommand command)
        {
            var user = new User
            {
                Username = command.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(command.Password)
            };

            await _userRepository.AddUserAsync(user);
        }
    }
}
