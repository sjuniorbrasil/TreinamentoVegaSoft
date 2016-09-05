using Sergio.Saude.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sergio.Saude.Repositorio.Configuracao
{
    public class ConsultaConfiguracao : EntityTypeConfiguration<Funcionario>
    {
        public ConsultaConfiguracao()
        {
            ToTable("Consultas");
            HasKey(m => m.Id);

           
        }
            
    }
}
