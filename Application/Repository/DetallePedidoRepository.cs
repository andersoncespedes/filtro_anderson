using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class DetallePedidoRepository : GenericRepository<DetallePedido>, IDetallePedido
{
    private readonly APIContext _context;
    public DetallePedidoRepository(APIContext context) : base(context){
        _context = context;
    }

}