using System.Data.Entity;

namespace Zoo.Models
{
    public class AnimalContext : ApplicationDbContext
    {
        public DbSet<Animal> Name { get; set; }
    }
}