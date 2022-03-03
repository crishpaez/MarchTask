using Microsoft.EntityFrameworkCore;

namespace StarWars.Models
{
    public class StarWarsDb : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public StarWarsDb()
        {

        }
        public StarWarsDb(DbContextOptions<StarWarsDb> options) : base(options)
        {

        }        
    }
}
