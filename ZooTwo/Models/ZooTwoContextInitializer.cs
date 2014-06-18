//NOT FOR PRODUCTION USE!! Used for Development so you have sample data to work with

using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ZooTwo.Models
{
    public class ZooTwoContextInitializer : DropCreateDatabaseIfModelChanges<ZooTwoContext>
    {
        private bool AddUserAndRole(ZooTwoContext context)
        {
            //Create the Admin role
            IdentityResult ir;
            //var rm = new RoleManager<IdentityRole>
            //    (new RoleStore<IdentityRole>(context));
            //ir = rm.Create(new IdentityRole("Admin"));

            //Create new user and assign Admin role
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser
            {
                UserName = "zoomaster@zoo.com",
            };
            ir = um.Create(user, "P@ssword!");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "Administrator");
            return ir.Succeeded;
        }

        protected override void Seed(ZooTwoContext context)
        {

            var animals = new List<Animal>()
            {
                new Animal() {Specie = "Panda"},
                new Animal() {Specie = "Zebra"},
                new Animal() {Specie = "Cheetah"},
                new Animal() {Specie = "Monkey"},
                new Animal() {Specie = "Tiger"},
                new Animal() {Specie = "Koala"}

            };

            animals.ForEach(a => context.Animals.Add(a));
            context.SaveChanges();

            var locations = new List<Location>()
            {
                new Location() {City = "Chicago", Info = "Windy City Zoo with lots of furry creatures"},
                new Location() {City = "Louisville", Info = "Purebreed horses!"},
                new Location() {City = "Indianapolis", Info = "More to see than just Colts"},
                new Location() {City = "Cincinatti", Info = "Not as great as it's rated"},
                new Location() {City = "SanDiego", Info = "West Coast wildlife!"}
            };

            locations.ForEach(l => context.Locations.Add(l));
            context.SaveChanges();

            var zd = new List<ZooDetail>()
            {
                new ZooDetail() {Location = locations[1], Animal = animals[3]},
                new ZooDetail() {Location = locations[2], Animal = animals[0]},
                new ZooDetail() {Location = locations[0], Animal = animals[1]},
                new ZooDetail() {Location = locations[3], Animal = animals[2]},
                new ZooDetail() {Location = locations[4], Animal = animals[4]}
            };

            zd.ForEach(d => context.ZooDetails.Add(d));
            context.SaveChanges();

            context.Roles.AddOrUpdate(
                new IdentityRole("Administrator"),
                new IdentityRole("Member"),
                new IdentityRole("Employee")
                );

            AddUserAndRole(context);


            context.SaveChanges();
        }
    }
}