using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;
    public class APIContext : DbContext 
    {
        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<DetallePedido> DetallePedidos {get; set;}
        public DbSet<Empleado> Empleados {get; set;}
        public DbSet<GamaProducto> GamaProductos {get; set;}
        public DbSet<Oficina> Oficinas {get; set;}
        public DbSet<Pago> Pagos {get; set;}
        public DbSet<Pedido> Pedido {get; set;}
        public DbSet<Producto> Productos {get; set;}
        public APIContext(DbContextOptions<APIContext> options) : base(options){

        }
        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }