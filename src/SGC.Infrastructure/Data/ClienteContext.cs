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
            modelBuilder.Entity<Endereco>().ToTable("Endereco");
            modelBuilder.Entity<Profissao>().ToTable("Profissao");
            modelBuilder.Entity<ProfissaoCliente>().ToTable("ProfissaoCliente");

            #region Configurações de Clientes
            //Entidade Cliente 

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.ClienteId);

            //Fluent API
            modelBuilder.Entity<Cliente>()
                .HasMany(cont => cont.Contato)
                .WithOne(cont => cont.Cliente)
                .HasForeignKey(cont => cont.ClienteId)
                .HasPrincipalKey(cont => cont.ClienteId);

            modelBuilder.Entity<Cliente>().Property(e => e.CPF)
              .HasColumnType("varchar(11)")
              .IsRequired();

            modelBuilder.Entity<Cliente>().Property(e => e.Nome)
              .HasColumnType("varchar(200)")
              .IsRequired();
            #endregion

            #region Configurações de Contatos
            //Entidade Contato

            //Fluent API
            modelBuilder.Entity<Contato>()
                .HasOne(c => c.Cliente)
                .WithMany(c => c.Contato)
                .HasForeignKey(c => c.ClienteId)
                .HasPrincipalKey(c => c.ClienteId);

            modelBuilder.Entity<Contato>().Property(c => c.Nome)
              .HasColumnType("varchar(200)")
              .IsRequired();

            modelBuilder.Entity<Contato>().Property(c => c.Email)
              .HasColumnType("varchar(100)")
              .IsRequired();

            modelBuilder.Entity<Contato>().Property(c => c.Telefone)
             .HasColumnType("varchar(15)");
            #endregion

            #region Configurações de Profissão
            // Entidade Profissão.
            modelBuilder.Entity<Profissao>().Property(p => p.Nome)
                .HasColumnType("varchar(400)")
                .IsRequired();

            modelBuilder.Entity<Profissao>().Property(p => p.CBO)
                .HasColumnType("varchar(10)")
                .IsRequired();

            modelBuilder.Entity<Profissao>().Property(p => p.Descricao)
                .HasColumnType("varchar(1000)")
                .IsRequired();
            #endregion

            #region Configurações de Endereço
            // Entidade Endereço.
            modelBuilder.Entity<Endereco>().Property(end => end.Bairro)
                .HasColumnType("varchar(200)")
                .IsRequired();

            modelBuilder.Entity<Endereco>().Property(end => end.CEP)
                .HasColumnType("varchar(15)")
                .IsRequired();

            modelBuilder.Entity<Endereco>().Property(end => end.Logadouro)
                .HasColumnType("varchar(200)")
                .IsRequired();

            modelBuilder.Entity<Endereco>().Property(end => end.Referencia)
                .HasColumnType("varchar(400)");
            #endregion

            #region Configurações de ProfissãoCliente

            //Fluent API
            modelBuilder.Entity<ProfissaoCliente>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<ProfissaoCliente>()
                .HasOne(pc => pc.Cliente)
                .WithMany(c => c.ProfissoesClientes)
                .HasForeignKey(c => c.ClienteId);

            modelBuilder.Entity<ProfissaoCliente>()
                .HasOne(pc => pc.Profissao)
                .WithMany(c => c.ProfissoesClientes)
                .HasForeignKey(c => c.ProfissaoId);

            #endregion

            #region Configurações de Menu

            modelBuilder.Entity<Menu>()
                .HasMany(m => m.SubMenu)
                .WithOne()
                .HasForeignKey(m=> m.MenuId);

            #endregion
        }
    }
}
