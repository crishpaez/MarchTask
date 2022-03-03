using Microsoft.EntityFrameworkCore;

namespace StarWars.Models
{
    public class StarWarsDb : DbContext
    {
        public DbSet<Player> Players { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("StarWars");
        }
    }
}
