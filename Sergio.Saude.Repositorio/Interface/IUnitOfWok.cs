using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sergio.Saude.Repositorio.Interface
{
    public interface IUnitOfWok
    {
        int Commit();

        void Rollback();

    }
}
