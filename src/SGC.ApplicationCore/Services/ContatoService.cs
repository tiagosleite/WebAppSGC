using SGC.ApplicationCore.Entity;
using SGC.ApplicationCore.Interfaces.Repository;
using SGC.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGC.ApplicationCore.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _clienteRepository;
        public ContatoService(IContatoRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Contato Adicionar(Contato entity)
        {
            //TODO: Adicionar Regra de Negocio antes de Adicionar no DB.
            if (entity.Nome != string.Empty)
            {
                return _clienteRepository.Adicionar(entity);
            }
            return null;
        }

        public void Atualizar(Contato entity)
        {
            _clienteRepository.Atualizar(entity);
        }

        public IEnumerable<Contato> Buscar(Expression<Func<Contato, bool>> predicado)
        {
            return _clienteRepository.Buscar(predicado);
        }

        public Contato ObterID(int id)
        {
            return _clienteRepository.ObterID(id);
        }

        public IEnumerable<Contato> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public void Remover(Contato entity)
        {
            _clienteRepository.Remover(entity);
        }
    }
}
