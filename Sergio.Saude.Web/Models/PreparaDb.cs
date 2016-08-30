using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using Sergio.Saude.Repositorio;
using Sergio.Saude.Repositorio.Contexto;
using Sergio.Saude.Web.Models;
using Sergio.Saude.Dominio;
using System.Collections.Generic;

namespace Sergio.Saude.Web.Models
{
    
    //public class PreparaDb : DropCreateDatabaseAlways<ApplicationDbContext>
    public class PreparaDb : CreateDatabaseIfNotExists<ApplicationDbContext>/*IDatabaseInitializer<object>*/
    {
        SaudeWebDbContexto db = new SaudeWebDbContexto();

        protected override void Seed(ApplicationDbContext contexto)
        {
            try
            {
                CriarUsuario(contexto);
                //CarregaBancoSistema(db);
                CarregarMedicos(db);
            }
            catch (Exception E)
            {
                
                throw new Exception(E.Message + Environment.NewLine + E.StackTrace);
            }
            base.Seed(contexto);
        }

        private void CarregarMedicos(SaudeWebDbContexto db)
        {

            List<Medico> medicos = new List<Medico>();
            for (int i = 0; i < 1000; i++)
            {
                Medico medico = new Medico();

                medico.Nome = Faker.Name.NomeCompleto();
                medico.Email = Faker.Internet.Email();
                medico.Crm = Faker.RandomNumber.Next(10000).ToString();

                medicos.Add(medico);


                

            }
            medicos.ForEach(m => db.Medicos.Add(m));//cada registro é um item da coleção
            db.Commit();
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

        private static void CarregaBancoSistema(SaudeWebDbContexto contextoSaudeWeb)
        {          
            Dados dados = new Dados();

            var clientes = dados.ListaCliente();
          

            var medicos = dados.ListaMedicos();
            contextoSaudeWeb.Commit();
            var funcionarios = dados.ListaFuncionario();
            contextoSaudeWeb.Commit();
            medicos.ForEach(m => contextoSaudeWeb.Medicos.Add(m));//cada registro é um item da coleção
            contextoSaudeWeb.Commit();
            clientes.ForEach(m => contextoSaudeWeb.Clientes.Add(m));
            contextoSaudeWeb.Commit();
            funcionarios.ForEach(m => contextoSaudeWeb.Funcionarios.Add(m));
            contextoSaudeWeb.SaveChanges();
            
        }
    }
}