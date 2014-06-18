using System.Data.Entity;

//Context can be used as a go between. It's data-aware, you iterate through it

namespace ZooTwo.Models
{
    public class ZooTwoContext : ApplicationDbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ZooDetail> ZooDetails { get; set; } 
    }
}