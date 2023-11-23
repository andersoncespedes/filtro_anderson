using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("producto");
        builder.Property(e => e.CodigoProducto)
        .HasColumnName("codigo_producto")
        .HasMaxLength(15);

        builder.HasKey(e => e.CodigoProducto).HasName("PRIMARY");
        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasMaxLength(70);

        builder.Property(e => e.Gama)
        .HasColumnName("gama")
        .HasMaxLength(50);

        builder.Property(e => e.Dimensiones)
        .HasColumnName("dimensiones")
        .HasMaxLength(25);

        builder.Property(e => e.Proveedor)
        .HasColumnName("proveedor")
        .HasMaxLength(50);

        builder.Property(e => e.Descripcion)
        .HasColumnName("descripcion")
        .HasColumnType("text");

        builder.Property(e => e.CantidadEnStock)
        .HasColumnName("cantidad_en_stock")
        .HasColumnType("smallint");

        builder.Property(e => e.PrecioVenta)
        .HasColumnName("precio_venta")
        .HasPrecision(15,2);

        builder.Property(e => e.PrecioProveedor)
        .HasColumnName("precio_proveedor")
        .HasPrecision(15, 2);

        builder.HasOne(e => e.GamaProducto)
        .WithMany(e => e.Productos)
        .HasForeignKey(e => e.Gama);
    }
}