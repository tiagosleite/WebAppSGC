using SGC.ApplicationCore.Entity;
using SGC.ApplicationCore.Interfaces.Repository;
using SGC.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGC.ApplicationCore.Services
{
    public class ProfissaoService : IProfissaoService
    {
        private readonly IProfissaoRepository _clienteRepository;
        public ProfissaoService(IProfissaoRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Profissao Adicionar(Profissao entity)
        {
            //TODO: Adicionar Regra de Negocio antes de Adicionar no DB.
            if (entity.Nome != string.Empty)
            {
                return _clienteRepository.Adicionar(entity);
            }
            return null;
        }

        public void Atualizar(Profissao entity)
        {
            _clienteRepository.Atualizar(entity);
        }

        public IEnumerable<Profissao> Buscar(Expression<Func<Profissao, bool>> predicado)
        {
            return _clienteRepository.Buscar(predicado);
        }

        public Profissao ObterID(int id)
        {
            return _clienteRepository.ObterID(id);
        }

        public IEnumerable<Profissao> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public void Remover(Profissao entity)
        {
            _clienteRepository.Remover(entity);
        }
    }
}
