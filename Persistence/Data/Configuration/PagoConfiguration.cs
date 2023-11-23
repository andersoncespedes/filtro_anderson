using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class PagoConfiguration : IEntityTypeConfiguration<Pago>
{
    public void Configure(EntityTypeBuilder<Pago> builder)
    {
        builder.ToTable("pago");

        builder.Property(e => e.FormaPago)
        .HasColumnName("forma_pago")
        .HasMaxLength(40);

        builder.Property(e => e.CodigoCliente)
        .HasColumnName("codigo_cliente");

        builder.Property(e => e.IdTransaccion)
                        .HasColumnName("id_transaccion")
                        .HasColumnOrder(2)
                        .HasMaxLength(50);

        builder.Property(e => e.FechaPago)
        .HasColumnName("fecha_pago");

        builder.Property(e => e.Total)
        .HasColumnName("total")
        .HasColumnType("decimal")
        .HasPrecision(15, 2);

        builder.HasOne(e => e.Cliente)
        .WithMany(e => e.Pagos)
        .HasForeignKey(e => e.CodigoCliente);

        builder.HasKey(e => e.IdTransaccion).HasName("PRIMARY");
    }
}