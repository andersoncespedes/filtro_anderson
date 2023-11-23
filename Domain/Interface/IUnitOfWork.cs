using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interface;
    public interface IUnitOfWork
    {
        ICliente Clientes { get; }
        IProducto Productos {get; }
        IPedido Pedidos {get;}
        IOficina Oficinas {get;}
        IGamaProducto Gamas {get;}
        IEmpleado Empleados {get;}
        IDetallePedido DetallePedidos {get;}
        IPago Pagos {get;}
        Task<int> SaveAsync();

    }