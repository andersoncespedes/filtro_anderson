using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class OficinaRepository : GenericRepository<Oficina>, IOficina
{
    private readonly APIContext _context;
    public OficinaRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Oficina>> GetNoFrutales(){
        return await _context.Oficinas
        .Include(e => e.Empleados)
        .ThenInclude(e => e.Clientes)
        .ThenInclude(e => e.Pedidos)
        .ThenInclude(e => e.Productos)
        .Where(e => !e.Empleados.SelectMany(e => e.Clientes).SelectMany(e => e.Pedidos).SelectMany(e => e.Productos).Where(e => e.Gama.ToLower() == "frutales").Any())
        .ToListAsync();
    }
}