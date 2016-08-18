using Sergio.Saude.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using Sergio.Saude.Repositorio.Contexto;

namespace Sergio.Saude.Repositorio
{
    public abstract class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {

        private readonly IUnitOfWok _unitOfWork;
        private readonly DbSet<TEntity> _context;

        public Repositorio(IUnitOfWok unitOfWork)
        {
            _context = ((SaudeWebDbContexto)unitOfWork).Set<TEntity>();
            _unitOfWork = unitOfWork;
                  
        }        

        public IUnitOfWok UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        public DbSet<TEntity> Context
        {
            get
            {
                return _context;
            }
        }

        public TEntity Atualizar(TEntity entity)
        {
            ((SaudeWebDbContexto)_unitOfWork).Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Excluir(TEntity entity)
        {
            _context.Remove(entity);
        }

        public TEntity Inserir(TEntity entity)
        {
            try
            {
                _context.Add(entity);
                ((SaudeWebDbContexto)_unitOfWork).Entry(entity).State = EntityState.Added;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return entity;
        }

        public TEntity Obter(Expression<Func<TEntity, bool>> filter)
        {
            return _context.FirstOrDefault(filter);
        }

        public IQueryable<TEntity> ObterTodos()
        {
            return _context;
        }
    }
}
