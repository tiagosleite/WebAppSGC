using SGC.ApplicationCore.Entity;
using SGC.ApplicationCore.Interfaces.Repository;
using SGC.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGC.Infrastructure.Repository
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ClienteContext dbContext):base(dbContext)
        {            
        }

        //public override Cliente Adicionar(Cliente entity)
        //{
        //    string ValidarResultado = string.Empty;
        //    //TODO: Implementação especifica    para adicionar um Cliente
        //    //para sobrescrita do método - polimorfismo.
        //    _dbcontext.Set<Cliente>().Add(entity);
        //    _dbcontext.SaveChanges();
        //    return entity;
        //}

        public Cliente ObterPorProfissao(int ID)
        {
            return Buscar(x=>x.ProfissoesClientes.Any(p=>p.ClienteId == ID)).FirstOrDefault();
        }
    }
}
