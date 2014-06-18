using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZooTwo.Models
{
    public class Location
    {
        public Int32 Id { get; set; }

        [Required]
        public String City { get; set; }

        [DataType(DataType.MultilineText)]
        public string Info { get; set; }


        //public Int32 AnimalID { get; set; }

        //public virtual Animal Animal { get; set; }
        //public virtual List<Comment> Comments { get; set; }

        public ICollection<ZooDetail> ZooDetails { get; set; }

        public virtual Animal Animal { get; set; }
    }
}