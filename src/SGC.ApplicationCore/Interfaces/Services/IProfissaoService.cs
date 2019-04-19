using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGC.ApplicationCore.Interfaces.Services
{
    public interface IProfissaoService
    {
        Profissao Adicionar(Profissao entity);
        void Atualizar(Profissao entity);
        IEnumerable<Profissao> ObterTodos();
        Profissao ObterID(int id);
        IEnumerable<Profissao> Buscar(Expression<Func<Profissao, bool>> predicado);
        void Remover(Profissao entity);
    }
}
