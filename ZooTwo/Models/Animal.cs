using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZooTwo.Models
{
    public class Animal
    {
        [ScaffoldColumn(false)]
        public Int32 Id { get; set; }

        [Required(ErrorMessage = "{0} is required")] //{0} grabs what the Display is
        [Display(Name = "Animal")]
        public String Specie { get; set; }

        //public virtual List<Location> Locations { get; set; }
    }
}