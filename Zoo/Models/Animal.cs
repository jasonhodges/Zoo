using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zoo.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(160, MinimumLength = 2)]
        [DisplayName("Animal")]
        public string Name { get; set; }

        //public virtual List<Location> City { get; set; } //LazyLoading "if you GET an Animal load Locations"

    }
}