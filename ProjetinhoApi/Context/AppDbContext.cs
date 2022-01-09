using Microsoft.EntityFrameworkCore;
using ProjetinhoApi.Models;

namespace ProjetinhoApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

    }
}
