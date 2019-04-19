using Microsoft.EntityFrameworkCore;
using SGC.ApplicationCore.Interfaces.Repository;
using SGC.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SGC.Infrastructure.Repository
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        protected readonly ClienteContext _dbcontext;
        public EFRepository(ClienteContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public virtual T Adicionar(T entity)
        {
            _dbcontext.Set<T>().Add(entity);
            _dbcontext.SaveChanges();
            return entity;
        }

        public virtual void Atualizar(T entity)
        {
            _dbcontext.Entry(entity).State = EntityState.Modified;
            _dbcontext.SaveChanges();
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> predicado)
        {

            return _dbcontext.Set<T>().Where(predicado);
        }

        public virtual T ObterID(int id)
        {
            return _dbcontext.Set<T>().Find(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return _dbcontext.Set<T>().AsEnumerable();
        }

        public void Remover(T entity)
        {
            _dbcontext.Set<T>().Remove(entity);
            _dbcontext.SaveChanges();
        }
    }
}
