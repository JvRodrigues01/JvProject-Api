using ProjetinhoApi.Context;
using ProjetinhoApi.Helpers;
using ProjetinhoApi.Models;
using ProjetinhoApi.Services.Interfaces;

namespace ProjetinhoApi.Services
{
    public class UsersService : IUsersService
    {
        private readonly AppDbContext _context;

        public UsersService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string username, string password)
        {

            // Validate the input field required
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Username e Password é obrigatório !");

            // Query data in the database to validate the user
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
                throw new Exception("Usuário não encontrado!");

            if (user.Password != Functions.Encrypt(password))
                throw new Exception("Usuário e senha não coincidem");

            return user;
        }

        public async Task CreateUser(User model, string password)
        {
            // Encrypt password
            model.Password = Functions.Encrypt(password);

            // Add the user in the database service
            _context.Users.Add(model);
            await _context.SaveChangesAsync();
        }
    }
}
