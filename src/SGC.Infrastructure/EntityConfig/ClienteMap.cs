using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EntityConfig
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            #region Configurações de Clientes  

            builder.HasKey(c => c.ClienteId);

            //Fluent API
            builder
                .HasMany(cont => cont.Contato)
                .WithOne(cont => cont.Cliente)
                .HasForeignKey(cont => cont.ClienteId)
                .HasPrincipalKey(cont => cont.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Endereco)
                .WithOne(x => x.Clientes)
                .HasForeignKey<Endereco>(x => x.ClienteId);

            builder.Property(e => e.CPF)
              .HasColumnType("varchar(11)")
              .IsRequired();

            builder.Property(e => e.Nome)
              .HasColumnType("varchar(200)")
              .IsRequired();
            #endregion
        }
    }
}
