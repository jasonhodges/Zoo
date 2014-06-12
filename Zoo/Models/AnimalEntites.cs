using System.Data.Entity;

namespace Zoo.Models
{
    public class AnimalEntites : ApplicationDbContext
    {
        public DbSet<Animal> Animals { get; set; }
    }
}