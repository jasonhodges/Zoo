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

        //Reference located at azure.microsoft.com/en-us/documentation/articles.web-sites.dotnet-deploy-aspnet-mvc-app-membership-oauth-sql-database/
        bool AddUserAndRole(Zoo.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "zoomaster@zoo.com",
            };
            ir = um.Create(user, "P@ssword!");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }

        
        protected override void Seed(ApplicationDbContext context)
        {

            

            AddUserAndRole(context);
           

            //for (int i = 0; i < 4; i++)
            //{
            //    var user = new ApplicationUser
            //    {
            //        UserName = string.Format("User{0}", i),
            //        Email = string.Format("Email{0}@Example.com", i)
            //    };
            //    {
            //        user.ZooMemberInfo = new ZooMemberInfo {FirstName = string.Format("FirstName{0}", i)};
            //        user.ZooMemberInfo = new ZooMemberInfo {LastName = string.Format("LastName{0}", i)};
            //    }
            //    ;
            //    manager.Create(user, string.Format("Password{0}", i));
            //}
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