using Sergio.Saude.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sergio.Saude.Repositorio.Interface;

namespace Sergio.Saude.Repositorio
{
    public class RepositorioCliente : Repositorio<Cliente>
    {
        public RepositorioCliente(IUnitOfWok unitOfWork) : base(unitOfWork)
        {

        }
    }
}
