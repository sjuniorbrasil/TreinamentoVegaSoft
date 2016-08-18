using Sergio.Saude.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sergio.Saude.Repositorio.Interface;

namespace Sergio.Saude.Repositorio
{
    public class RepositorioFuncionario : Repositorio<Funcionario>
    {
        public RepositorioFuncionario(IUnitOfWok unitOfWork) : base(unitOfWork)
        {

        }

        ////public IQueryable<Funcionario> ObterAtivo()
        ////{
        ////    return Context.Where(x => x.Nome.ativo)
        ////}
    }
}
