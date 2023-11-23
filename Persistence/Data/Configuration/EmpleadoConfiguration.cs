using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("empleado");
        builder.Property(e => e.Id)
        .HasColumnName("codigo_empleado")
        .IsRequired();

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasMaxLength(50);

        builder.Property(e => e.Apellido1)
        .HasColumnName("apellido1")
        .HasMaxLength(50);

        builder.Property(e => e.Apellido2)
         .HasColumnName("apellido2")
        .HasMaxLength(50);

        builder.Property(e => e.Extension)
        .HasColumnName("extension")
        .HasMaxLength(10);

        builder.Property(e => e.Email)
        .HasColumnName("email")
        .HasMaxLength(100);

        builder.Property(e => e.CodigoOficina)
        .HasColumnName("codigo_oficina")
        .HasMaxLength(10);

        builder.Property(e => e.CodigoJefe)
        .HasColumnName("codigo_jefe");

        builder.Property(e => e.Puesto)
        .HasColumnName("puesto")
        .HasMaxLength(50);

        builder.HasOne(e => e.Oficina)
        .WithMany(e => e.Empleados)
        .HasForeignKey(e => e.CodigoOficina);

        builder.HasOne(e => e.Jefe)
        .WithMany(e => e.Empleados)
        .HasForeignKey(e => e.CodigoJefe);
    }
}