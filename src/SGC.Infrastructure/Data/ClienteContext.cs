using Microsoft.EntityFrameworkCore;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.Data
{
    public class ClienteContext : DbContext
    {
        /// <summary>
        /// Contrutor do Context do Cliente
        /// </summary>
        /// <param name="options"></param>
        public ClienteContext(DbContextOptions<ClienteContext> options ):base (options)
        {

        }

        /// <summary>
        /// (DbSet) Mapear a Classe do Cliente. (Cliente = CRUD)
        /// </summary>
        public DbSet<Cliente> Clientes{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Tb_cliente");
        }
    }
}
