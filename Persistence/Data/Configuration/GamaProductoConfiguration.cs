using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class GamaProductoConfiguration : IEntityTypeConfiguration<GamaProducto>
{
    public void Configure(EntityTypeBuilder<GamaProducto> builder)
    {
        builder.ToTable("gama_producto");

        builder.Property(e => e.Gama)
        .HasColumnName("gama")
        .HasMaxLength(50);

        builder.Property(e => e.DescripcionTexto)
        .HasColumnName("descripcion_texto")
        .HasColumnType("text");

        builder.Property(e => e.DescripcionHtml)
        .HasColumnName("descripcion_html")
        .HasColumnType("text");

        builder.Property(e => e.Imagen)
        .HasColumnName("imagen")
        .HasMaxLength(250);

        builder.HasKey(e => e.Gama).HasName("PRIMARY");
    }
}