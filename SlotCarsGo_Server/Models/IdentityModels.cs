﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SlotCarsGo_Server.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string ImageName { get; set; }



        //object id = Membership.GetUser().ProviderUserKey


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SlotCarsGo_Server.Models.RaceSession> RaceSessions { get; set; }

        public System.Data.Entity.DbSet<SlotCarsGo_Server.Models.Car> Cars { get; set; }

        public System.Data.Entity.DbSet<SlotCarsGo_Server.Models.Driver> Drivers { get; set; }

        public System.Data.Entity.DbSet<SlotCarsGo_Server.Models.DriverResult> DriverResults { get; set; }

        public System.Data.Entity.DbSet<SlotCarsGo_Server.Models.Track> Tracks { get; set; }

        public System.Data.Entity.DbSet<SlotCarsGo_Server.Models.RaceType> RaceTypes { get; set; }

        public System.Data.Entity.DbSet<SlotCarsGo_Server.Models.LapTime> LapTimes { get; set; }

// Already exists as Users        public System.Data.Entity.DbSet<SlotCarsGo_Server.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}