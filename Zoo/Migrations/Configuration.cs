using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Zoo.Models;

namespace Zoo.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(
                    new ApplicationDbContext()));

            for (int i = 0; i < 4; i++)
            {
                var user = new ApplicationUser
                {
                    UserName = string.Format("User{0}", i),
                    Email = string.Format("Email{0}@Example.com", i)
                };
                {
                    user.ZooMemberInfo = new ZooMemberInfo {FirstName = string.Format("FirstName{0}", i)};
                    user.ZooMemberInfo = new ZooMemberInfo {LastName = string.Format("LastName{0}", i)};
                }
                ;
                manager.Create(user, string.Format("Password{0}", i));
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}