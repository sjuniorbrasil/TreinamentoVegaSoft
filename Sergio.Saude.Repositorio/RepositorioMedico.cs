using Sergio.Saude.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sergio.Saude.Repositorio.Interface;

namespace Sergio.Saude.Repositorio
{
    public class RepositorioMedico : Repositorio<Medico>
    {
        public RepositorioMedico(IUnitOfWok unitOfWork) : base(unitOfWork)
        {

        }
    }
}
