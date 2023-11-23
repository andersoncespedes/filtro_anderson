using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("pedido");

        builder.Property(e => e.Id)
        .HasColumnName("codigo_pedido");

        builder.Property(e => e.FechaPedido)
        .HasColumnName("fecha_pedido");

        builder.Property(e => e.FechaEsperada)
        .HasColumnName("fecha_esperada");

        builder.Property(e => e.FechaEntrega)
        .HasColumnName("fecha_entrega");

        builder.Property(e => e.Estado)
        .HasColumnName("estado")
        .HasMaxLength(15);

        builder.Property(e => e.Comentarios)
        .HasColumnName("comentarios")
        .HasColumnType("text");

        builder.Property(e => e.CodigoCliente)
        .HasColumnName("codigo_cliente");

        builder.HasOne(e => e.Cliente)
        .WithMany(e => e.Pedidos)
        .HasForeignKey(e => e.CodigoCliente);

        builder.HasMany(e => e.Productos)
        .WithMany(e => e.Pedidos)
        .UsingEntity<DetallePedido>(
            j => j.HasOne(e => e.Producto)
                .WithMany(e => e.DetallePedidos)
                .HasForeignKey(e => e.CodigoProducto),

            j => j.HasOne(e => e.Pedido)
            .WithMany(e => e.DetallePedidos)
            .HasForeignKey(e => e.CodigoPedido),

            j => {
                j.ToTable("detalle_pedido");
                j.Property(e => e.Cantidad)
                .HasColumnName("cantidad");

                j.Property(e => e.PrecioUnidad)
                .HasColumnName("precio_unidad")
                .HasPrecision(15,2);

                j.Property(e => e.NumeroLinea)
                .HasColumnName("numero_linea")
                .HasColumnType("SMALLINT");

                j.HasKey(e => new {e.CodigoPedido, e.CodigoProducto});
            }
        );
    }
}