using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interface;
using Persistence.Data;

namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly APIContext _context;
    private ICliente _cliente;
    private IDetallePedido _detallePedido;
    private IEmpleado _empleado;
    private IGamaProducto _gama;
    private IOficina _oficina;  
    private IPago _pago ;
    private IPedido _pedido;
    private IProducto _producto;
    public UnitOfWork(APIContext context){
        _context = context;
    }
    public ICliente Clientes {
        get{
             _cliente ??= new ClienteRepository(_context);
             return _cliente;
        }
    }

    public IProducto Productos {
        get{
            _producto ??= new ProductoRepository(_context);
            return _producto;
        }
    }

    public IPedido Pedidos {
        get{
            _pedido ??= new PedidoRepository(_context);
            return _pedido;
        }
    }

    public IOficina Oficinas {
        get{
            _oficina ??= new OficinaRepository(_context);
            return _oficina;
        }
    }

    public IGamaProducto Gamas 
    {
        get{
            _gama ??= new GamaProductoRepository(_context);
            return _gama;
        }
    }

    public IEmpleado Empleados {
        get{
            _empleado ??= new EmpleadoRepository(_context);
            return _empleado;
        }
    }

    public IDetallePedido DetallePedidos 
    {
        get{
            _detallePedido ??= new DetallePedidoRepository(_context);
            return _detallePedido;
        }
    }

    public IPago Pagos {
        get{
            _pago ??= new PagoRepository(_context);
            return _pago;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync(){
        return await _context.SaveChangesAsync();
    }
}