namespace WebAS.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebAS.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WebAS.Models.ApplicationDbContext";
        }

        protected override void Seed(WebAS.Models.ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            #region Default Roles

            // Create default roles
            if (!(context.Roles.Any(r => r.Name == "Admin")))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!(context.Roles.Any(r => r.Name == "AppAdmin")))
            {
                roleManager.Create(new IdentityRole { Name = "AppAdmin" });
            }

            if (!(context.Roles.Any(r => r.Name == "AppUser")))
            {
                roleManager.Create(new IdentityRole { Name = "AppUser" });
            }

            if (!(context.Roles.Any(r => r.Name == "User")))
            {
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            #endregion Default Roles

            #region Default Users

            // Create default users
            if (!(context.Users.Any(u => u.UserName == "user@webasdemo.net")))
            {

                var userToInsert = new ApplicationUser { UserName = "user@webasdemo.net", Email = "user@webasdemo.net", PhoneNumber = "+35812345678" };
                userManager.Create(userToInsert, "ChangePass!1");

                // Add roles for user
                userManager.AddToRole(userToInsert.Id, "User");
                userManager.AddToRole(userToInsert.Id, "AppUser");
            }

            if (!(context.Users.Any(u => u.UserName == "admin@webasdemo.net")))
            {
                var userToInsert = new ApplicationUser { UserName = "admin@webasdemo.net", Email = "admin@webasdemo.net", PhoneNumber = "+358123456789" };
                userManager.Create(userToInsert, "ChangePass!1");

                // Add  roles for user
                userManager.AddToRole(userToInsert.Id, "Admin");
                userManager.AddToRole(userToInsert.Id, "AppAdmin");
                userManager.AddToRole(userToInsert.Id, "AppUser");
                userManager.AddToRole(userToInsert.Id, "User");
            }

           
            #endregion Default Users

            #region Default locations
            context.Locations.AddOrUpdate(
                p => p.LocationId,
                new Location { LocationId = 1, Latitude = "66.383333", Longitude = "23.666667", Altitude = "0", Title = "title 1", Description = "description 1" },
                new Location { LocationId = 2, Latitude = "66.383333", Longitude = "23.656667", Altitude = "0", Title = "title 2", Description = "description 2" },
                new Location { LocationId = 3, Latitude = "66.383333", Longitude = "23.646667", Altitude = "0", Title = "title 3", Description = "description 3" },
                new Location { LocationId = 4, Latitude = "66.383333", Longitude = "23.636667", Altitude = "0", Title = "title 4", Description = "description 4" },
                new Location { LocationId = 5, Latitude = "66.383333", Longitude = "23.626667", Altitude = "0", Title = "title 5", Description = "description 5" },
                new Location { LocationId = 6, Latitude = "66.383333", Longitude = "23.616667", Altitude = "0", Title = "title 6", Description = "description 6" }
            );
            #endregion Default locations
        }
    }
}
