using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sergio.Saude.Dominio.Contexto
{
    public class SaudeWebDbContexto: DbContext
    {
        DbSet<Funcionario> Funcionarios { get; set; }

        DbSet<Medico> Medicos { get; set; }
        DbSet<Cliente> Clientes { get; set; }

        public SaudeWebDbContexto() : base("SaudeWebContexto")
        {
         
                 
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.ReflectedType != null && p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey());

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(150));
            //base.OnModelCreating(modelBuilder);
        }
    }
}
