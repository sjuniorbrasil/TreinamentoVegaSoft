﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Sergio.Saude.Dominio;

namespace Sergio.Saude.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Cidade { get; set; }

        public int? ClienteId { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("ClienteId", this.ClienteId.ToString()));
            userIdentity.AddClaim(new Claim("Cidade", this.Cidade.ToString()));
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
      

        public ApplicationDbContext()
            : base("SaudeWebContexto", throwIfV1Schema: false)
        {
            Database.SetInitializer(new PreparaDb());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       




        //public System.Data.Entity.DbSet<Sergio.Saude.Web.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}