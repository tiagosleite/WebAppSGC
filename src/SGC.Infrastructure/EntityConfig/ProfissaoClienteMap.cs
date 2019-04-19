using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EntityConfig
{
    public class ProfissaoClienteMap : IEntityTypeConfiguration<ProfissaoCliente>
    {
        public void Configure(EntityTypeBuilder<ProfissaoCliente> builder)
        {
            #region Configurações de ProfissãoCliente
            //Fluent API
            builder.HasKey(c => c.Id);

            builder
                .HasOne(pc => pc.Cliente)
                .WithMany(c => c.ProfissoesClientes)
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(pc => pc.Profissao)
                .WithMany(c => c.ProfissoesClientes)
                .HasForeignKey(c => c.ProfissaoId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}
