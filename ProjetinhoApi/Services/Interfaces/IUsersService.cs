using ProjetinhoApi.Models;

namespace ProjetinhoApi.Services.Interfaces
{
    public interface IUsersService
    {
        Task<User> Login(string username, string password);
        Task CreateUser(User user, string password);
    }
}
