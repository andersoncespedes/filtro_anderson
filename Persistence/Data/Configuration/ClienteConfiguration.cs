using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("cliente");
        builder.Property(e => e.Id)
        .IsRequired()
        .HasColumnName("codigo_cliente");

        builder.Property(e => e.NombreCliente)
        .HasColumnName("nombre_cliente")
        .HasMaxLength(50);

        builder.Property(e => e.NombreContacto)
        .HasColumnName("nombre_contacto")
        .HasMaxLength(30);

        builder.Property(e => e.ApellidoContacto)
        .HasColumnName("apellido_contacto")
        .HasMaxLength(30);

        builder.Property(e => e.Telefono)
        .HasColumnName("telefono")
        .HasMaxLength(15);

        builder.Property(e => e.Fax)
        .HasColumnName("fax")
        .HasMaxLength(15);

        builder.Property(e => e.LineaDireccion1)
        .HasMaxLength(50)
        .HasColumnName("linea_direccion1");

        builder.Property(e => e.LineaDireccion2)
        .HasMaxLength(50)
        .HasColumnName("linea_direccion2");

        builder.Property(e => e.Ciudad)
        .HasColumnName("ciudad")
        .HasMaxLength(50);

        builder.Property(e => e.Region)
        .HasColumnName("region")
        .HasMaxLength(50);

        builder.Property(e => e.Pais)
        .HasColumnName("pais")
        .HasMaxLength(50);

        builder.Property(e => e.CodigoPostal)
        .HasMaxLength(10)
        .HasColumnName("codigo_postal");

        builder.Property(e => e.CodigoEmpleadoRepVentas)
        .HasColumnName("codigo_empleado_rep_ventas");
        builder.Property(e => e.LimiteCredito)
        .HasColumnName("limite_credito")
        .HasPrecision(15,2);


        builder.HasOne(e => e.Empleado)
        .WithMany(e => e.Clientes)
        .HasForeignKey(e => e.CodigoEmpleadoRepVentas);
    }
}