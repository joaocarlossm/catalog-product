using CatalogProduct.Models;

namespace CatalogProduct.Commands
{
    public class RegisterUserCommand
    {
        public string Username { get; }
        public string Password { get; }

        public RegisterUserCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}