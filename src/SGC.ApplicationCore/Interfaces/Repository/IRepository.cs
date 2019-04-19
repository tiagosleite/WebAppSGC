﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGC.ApplicationCore.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        T Adicionar(T entity);
        void Atualizar(T entity);
        IEnumerable<T> ObterTodos();
        T ObterID(int id);
        IEnumerable<T> Buscar(Expression<Func<T,bool>>predicado);
        void Remover(T entity);       
    }
}
