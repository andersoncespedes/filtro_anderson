using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class ClienteRepository : GenericRepository<Cliente>, ICliente
{
    private readonly APIContext _context;
    public ClienteRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Cliente>> GetNoPagos(){
        return await _context.Clientes
        .Include(e => e.Pagos)
        .Include(e => e.Empleado)
        .ThenInclude(e => e.Oficina)
        .Where(e => e.Pagos.Count == 0).ToListAsync();
    }
    public override async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes.Include(e => e.Pedidos)
        .Include(e => e.Empleado)
        .ThenInclude(e => e.Oficina)
        .ToListAsync();
    }
}