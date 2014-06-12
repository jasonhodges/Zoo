using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Zoo.Models
{
    public class ZooContext : ApplicationDbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ZooMemberInfo> ZooMemberInfo { get; set; }
    }
}