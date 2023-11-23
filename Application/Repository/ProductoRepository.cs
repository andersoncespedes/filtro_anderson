using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    private readonly APIContext _context;
    public ProductoRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Producto>> GetByTop(){
        return await _context.Productos
        .Include(e => e.DetallePedidos)
        .OrderByDescending(e => e.DetallePedidos.Select(e => e.Cantidad).Sum())
        .Take(20)
        .ToListAsync();
    }
      public async Task<IEnumerable<Producto>> MoreThan3000(){
        return await _context.Productos
        .Include(e => e.DetallePedidos)
        .Where(e => e.DetallePedidos.Select(e => e.PrecioUnidad).Sum() >= 3000)
        .ToListAsync();
    }
    public async Task<Producto> MostSelled(){
        return await _context.Productos
        .Include(e => e.DetallePedidos)
        .OrderByDescending(e => e.DetallePedidos.Select(e => e.Cantidad).Sum())
        .FirstAsync();
    }
     public async Task<IEnumerable<Producto>> NoPed(){
        return await _context.Productos
        .Include(e => e.DetallePedidos)
        .Include(e => e.GamaProducto)
        .Where(e => e.Pedidos.Count() == 0)
        .ToListAsync();
    }
}