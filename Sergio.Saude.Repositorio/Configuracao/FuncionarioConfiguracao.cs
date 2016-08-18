using Sergio.Saude.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sergio.Saude.Repositorio.Configuracao
{
    public class FuncionarioConfiguracao : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfiguracao()
        {
            HasKey(m => m.Id);

            Property(m => m.Nome).IsRequired().HasMaxLength(100);

            //HasRequired(f => f.cliente).WithMany().HasForeignKey(f => f.Id);
        }
    }
}
