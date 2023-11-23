using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class GamaProductoRepository : GenericRepository<GamaProducto>, IGamaProducto
{
    private readonly APIContext _context;
    public GamaProductoRepository(APIContext context) : base(context)
    {
        _context = context;
    }
}