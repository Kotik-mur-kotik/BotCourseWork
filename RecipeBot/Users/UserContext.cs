using Microsoft.EntityFrameworkCore;


namespace RecipeBot.Users
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RecipeFirst;Trusted_Connection=True;");
        }
    }
}
