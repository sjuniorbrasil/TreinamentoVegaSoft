using Prosige_SaudeOc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sergio.Saude.Repositorio.Configuracao
{
    public class ConsultaExameConfiguracao:  EntityTypeConfiguration<ConsultaExame>
    {
        public ConsultaExameConfiguracao()
        {
            ToTable("ConsultaExames");
            HasKey(m => m.ConsultaExameId);
            


        }

    }
}
