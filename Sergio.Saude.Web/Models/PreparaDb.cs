using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace Sergio.Saude.Web.Models
{
    public class PreparaDb : DropCreateDatabaseAlways<ApplicationDbContext> /*IDatabaseInitializer<object>*/
    {
        protected override void Seed(ApplicationDbContext contexto)
        {
            try
            {
                CriarUsuario(contexto);
            }
            catch (Exception E)
            {
                
                throw new Exception(E.Message + Environment.NewLine + E.StackTrace);
            }
            base.Seed(contexto);
        }

        private static void CriarUsuario(ApplicationDbContext contexto)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contexto));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(contexto));

            // Popular Papeis

            roleManager.Create(new IdentityRole("Admin"));
            roleManager.Create(new IdentityRole("Medico"));
            roleManager.Create(new IdentityRole("Secretaria"));
           
            

            // Popular Permissões

            // Popular Usuarios
            var adm = new ApplicationUser() { UserName = "teste@gmail.com", Email = "teste@gmail.com" };
            // Atribuir papeis aos usuario/permissões
            if ((userManager.Create(adm, "Sergio@2016")).Succeeded)
            {
                userManager.AddToRole(adm.Id, "Admin");
            }

            var medico = new ApplicationUser() { UserName = "teste1@gmail.com", Email = "teste1@gmail.com" };

            if ((userManager.Create(medico, "teste1@2016")).Succeeded)
            {
                userManager.AddToRole(medico.Id, "Medico");
            }
            var secretaria = new ApplicationUser() { UserName = "teste2@gmail.com", Email = "teste2@gmail.com" };

            if ((userManager.Create(secretaria, "teste2@2016")).Succeeded)
            {
                userManager.AddToRole(secretaria.Id, "Secretaria");
            }

            userManager.Create(
                new ApplicationUser() { UserName = "Sergio@gmail.com", Email = "Sergio@gmail.com" },
                "Sergio@2016");

        }
    }
}