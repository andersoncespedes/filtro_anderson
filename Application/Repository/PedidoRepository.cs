using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class PedidoRepository : GenericRepository<Pedido>, IPedido
{
    private readonly APIContext _context;
    public PedidoRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Pedido>> NotOnTime (){
        return await _context.Pedido.Where(e => e.FechaEsperada < e.FechaEntrega).ToListAsync();
    }
}