using SGC.ApplicationCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGC.Infrastructure.Repository
{
    public class DapperRepository<T> : IRepository<T> where T : class
    {
        public T Adicionar(T entity)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public T ObterID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
