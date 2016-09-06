using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using Sergio.Saude.Repositorio;
using Sergio.Saude.Repositorio.Contexto;
using Sergio.Saude.Web.Models;
using Sergio.Saude.Dominio;
using System.Collections.Generic;
using Prosige_SaudeOc.Models;

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
                CarregarExames(db);
                CriarUsuario(contexto);
                //CarregaBancoSistema(db);
                CarregarMedicos(db);
                CarregaConsulta(db);
               CarregarConsultaExame(db);
                
            }
            catch (Exception E)
            {
                
                throw new Exception(E.Message + Environment.NewLine + E.StackTrace);
            }
            base.Seed(contexto);
        }

        private void CarregarExames(SaudeWebDbContexto db)
        {
            List<Exame> exames = new List<Exame> {

                new Exame { Descricao = "Audiometria" , Valor = 50.00m },
                new Exame { Descricao = "Visão" , Valor = 10.00m },
                new Exame { Descricao = "Fisico" , Valor = 90.00m },
                new Exame { Descricao = "Cardiaco" , Valor = 20.00m },
                
            };
            exames.ForEach(x => db.Exames.Add(x));
            db.Commit();
        }
        private void CarregarConsultaExame(SaudeWebDbContexto db)
        {
            List<ConsultaExame> CarregarconsultaExame = new List<ConsultaExame>
            {
                new ConsultaExame { ConsultaId = 1, ExameId = 1, DataEmissao = new DateTime(2016,10,25), DataColeta = new DateTime(2016,10,25), MedicoId = 1 , SituacaoExame = 1, Valor = 10.00m,  },
                new ConsultaExame { ConsultaId = 1, ExameId = 2, DataEmissao = new DateTime(2016,10,25), DataColeta = new DateTime(2016,10,25), MedicoId = 1 , SituacaoExame = 1, Valor = 20.00m  },
                new ConsultaExame { ConsultaId = 2, ExameId = 3, DataEmissao = new DateTime(2016,10,25), DataColeta = new DateTime(2016,10,25), MedicoId = 1 , SituacaoExame = 1, Valor = 50.00m  },
                new ConsultaExame { ConsultaId = 2, ExameId = 4, DataEmissao = new DateTime(2016,10,25), DataColeta = new DateTime(2016,10,25), MedicoId = 1 , SituacaoExame = 1, Valor = 60.00m  },
                new ConsultaExame { ConsultaId = 3, ExameId = 2, DataEmissao = new DateTime(2016,10,25), DataColeta = new DateTime(2016,10,25), MedicoId = 1 , SituacaoExame = 1, Valor = 70.00m  },
                new ConsultaExame { ConsultaId = 3, ExameId = 1, DataEmissao = new DateTime(2016,10,25), DataColeta = new DateTime(2016,10,25), MedicoId = 1 , SituacaoExame = 1, Valor = 90.00m  },
                new ConsultaExame { ConsultaId = 4, ExameId = 1, DataEmissao = new DateTime(2016,10,25), DataColeta = new DateTime(2016,10,25), MedicoId = 1 , SituacaoExame = 1, Valor = 10.00m  },
                new ConsultaExame { ConsultaId = 4, ExameId = 4, DataEmissao = new DateTime(2016,10,25), DataColeta = new DateTime(2016,10,25), MedicoId = 1 , SituacaoExame = 1, Valor = 80.00m  },
                new ConsultaExame { ConsultaId = 4, ExameId = 3, DataEmissao = new DateTime(2016,10,25), DataColeta = new DateTime(2016,10,25), MedicoId = 1 , SituacaoExame = 1, Valor = 90.00m  },
                new ConsultaExame { ConsultaId = 4, ExameId = 2, DataEmissao = new DateTime(2016,10,25), DataColeta = new DateTime(2016,10,25), MedicoId = 1 , SituacaoExame = 1, Valor = 50.00m  },

            };
            CarregarconsultaExame.ForEach(x => db.ConsultaExames.Add(x));
            db.Commit();
        }
        private void CarregaConsulta(SaudeWebDbContexto db)
        {
            List<Consulta> consulta = new List<Consulta>
            {
               new Consulta { ClienteId = 1, DataAgendado = new DateTime(2016,10,03), DataConsulta = new DateTime(2016,10,25), FuncionarioId = 1, Id = 1, SituacaoAgenda = 1, ValorConsulta = 100.00m, SituacaoConsulta = 1 },
               new Consulta { ClienteId = 2, DataAgendado = new DateTime(2016,10,05), DataConsulta = new DateTime(2016,10,20), FuncionarioId = 1, Id = 1, SituacaoAgenda = 1, ValorConsulta = 100.00m, SituacaoConsulta = 1 },
               new Consulta { ClienteId = 10, DataAgendado = new DateTime(2016,10,15), DataConsulta = new DateTime(2016,10,25), FuncionarioId = 2, Id = 1, SituacaoAgenda = 1, ValorConsulta = 100.00m, SituacaoConsulta = 1 },
               new Consulta { ClienteId = 21, DataAgendado = new DateTime(2016,10,25), DataConsulta = new DateTime(2016,10,20), FuncionarioId = 2, Id = 1, SituacaoAgenda = 1, ValorConsulta = 100.00m, SituacaoConsulta = 1 },
               new Consulta { ClienteId = 101, DataAgendado = new DateTime(2016,10,25), DataConsulta = new DateTime(2016,10,15), FuncionarioId = 3, Id = 1, SituacaoAgenda = 1, ValorConsulta = 100.00m, SituacaoConsulta = 1 },

            };
            consulta.ForEach(x => db.Consultas.Add(x));
            db.Commit();
        }

        private void CarregarMedicos(SaudeWebDbContexto db)
        {

            List<Medico> medicos = new List<Medico>();
            for (int i = 0; i < 20; i++)
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
            var adm = new ApplicationUser() { UserName = "teste@gmail.com", Email = "teste@gmail.com", Cidade = "1" };
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