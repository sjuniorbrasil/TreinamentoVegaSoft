using Sergio.Saude.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sergio.Saude.Repositorio.Interface
{
    public interface IRepositorio<TEntity> where TEntity: class
    {
        TEntity Inserir(TEntity entity);
        TEntity Atualizar(TEntity entity);
        void Excluir(TEntity entity);
        TEntity Obter(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> ObterTodos();
        IUnitOfWok UnitOfWork { get; }
    }
}
