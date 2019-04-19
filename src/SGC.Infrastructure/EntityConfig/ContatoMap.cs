using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EntityConfig
{
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {

        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            #region Configurações de Contatos
            //Entidade Contato

            //Fluent API
            builder
                .HasOne(c => c.Cliente)
                .WithMany(c => c.Contato)
                .HasForeignKey(c => c.ClienteId)
                .HasPrincipalKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.Nome)
              .HasColumnType("varchar(200)")
              .IsRequired();

            builder.Property(c => c.Email)
              .HasColumnType("varchar(100)")
              .IsRequired();

            builder.Property(c => c.Telefone)
             .HasColumnType("varchar(15)");
            #endregion
        }
    }
}
