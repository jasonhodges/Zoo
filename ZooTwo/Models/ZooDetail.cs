using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZooTwo.Models
{
    public class ZooDetail
    {
        public Int32 Id { get; set; }
        public Int32 LocationId { get; set; }
        public Int32 AnimalId { get; set; }

        // Navigation properties
        public Location Location { get; set; }
        public Animal Animal { get; set; }
    }
}