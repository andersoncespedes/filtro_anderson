using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class OficinaConfiguration : IEntityTypeConfiguration<Oficina>
{
    public void Configure(EntityTypeBuilder<Oficina> builder)
    {
        builder.ToTable("oficina");

        builder.Property(e => e.CodigoOficina)
        .HasColumnName("codigo_oficina")
        .HasMaxLength(10)
        .IsRequired();

        builder.HasKey(e => e.CodigoOficina).HasName("PRIMARY");

        builder.Property(e => e.Ciudad)
        .HasColumnName("ciudad")
        .HasMaxLength(30);
        builder.Property(e => e.Pais)
        .HasColumnName("pais")
        .HasMaxLength(50);
        builder.Property(e => e.Region)
        .HasMaxLength(50)
        .HasColumnName("region");

        builder.Property(e => e.CodigoPostal)
        .HasMaxLength(10)
        .HasColumnName("codigo_postal");

        builder.Property(e => e.Telefono)
        .HasColumnName("telefono")
        .HasMaxLength(20);

        builder.Property(e => e.LineaDireccion1)
        .HasColumnName("linea_direccion1")
        .HasMaxLength(50);
        builder.Property(e => e.LineaDireccion2)
        .HasColumnName("linea_direccion2")
        .HasMaxLength(50);
    }
}