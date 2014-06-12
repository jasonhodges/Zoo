using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Zoo.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(160, MinimumLength = 2)]
        [DisplayName("Location")]
        public string City { get; set; }
    }
}
