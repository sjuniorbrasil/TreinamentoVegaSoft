using Sergio.Saude.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sergio.Saude.Repositorio.Configuracao
{
    public class MedicoConfiguracao : EntityTypeConfiguration<Medico>
    {
        public MedicoConfiguracao()
        {
            HasKey(m => m.Id);

            Property(m => m.Nome).IsRequired().HasMaxLength(100);
        }
    }
}
