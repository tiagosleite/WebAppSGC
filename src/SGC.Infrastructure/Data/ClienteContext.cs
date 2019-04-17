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
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        {

        }

        /// <summary>
        /// (DbSet) Mapear a Classe do Cliente. (Cliente = CRUD)
        /// </summary>
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Contato>().ToTable("Contato");



            #region Configurações de Clientes
            //Entidade Cliente 
            modelBuilder.Entity<Cliente>().Property(e => e.CPF)
              .HasColumnType("varchar(11)")
              .IsRequired();

            modelBuilder.Entity<Cliente>().Property(e => e.Nome)
              .HasColumnType("varchar(200)")
              .IsRequired();
            #endregion

            #region Configurações de Contatos
            //Entidade Contato
            modelBuilder.Entity<Contato>().Property(e => e.Nome)
              .HasColumnType("varchar(200)")
              .IsRequired();

            modelBuilder.Entity<Contato>().Property(e => e.Email)
              .HasColumnType("varchar(100)")
              .IsRequired();

            modelBuilder.Entity<Contato>().Property(e => e.Telefone)
             .HasColumnType("varchar(15)");
            #endregion
        }
    }
}
