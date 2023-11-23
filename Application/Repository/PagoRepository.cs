using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class PagoRepository : GenericRepository<Pago>, IPago
{
    private readonly APIContext _context;
    public PagoRepository(APIContext context) : base(context)
    {
        _context = context;
    }
}