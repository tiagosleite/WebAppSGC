using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EntityConfig
{
    class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            #region Configurações de Endereço
            // Entidade Endereço.
            builder.Property(end => end.Bairro)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(end => end.CEP)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(end => end.Logadouro)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(end => end.Referencia)
                .HasColumnType("varchar(400)");
            #endregion
        }
    }
}
