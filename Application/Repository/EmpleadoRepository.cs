using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
{
    private readonly APIContext _context;
    public EmpleadoRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Empleado>> GetWithNoClients(){
        return await _context.Empleados
        .Include(e => e.Jefe)
        .Where(e => e.Clientes.Count() == 0).ToListAsync();
    }
}