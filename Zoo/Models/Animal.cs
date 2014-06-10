using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Zoo.Models
{
    public class AnimalEntites : ApplicationDbContext
    {
        public DbSet<Animal> Animals { get; set; }
    }

    public class Animal
    {
        public int Id { get; set; }

        [Required]
        [StringLength(160, MinimumLength = 2)]
        [DisplayName("Animal")]
        public string Name { get; set; }
    }
}