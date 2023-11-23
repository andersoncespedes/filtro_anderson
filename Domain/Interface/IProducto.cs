using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;
public interface IProducto : IGenericRepository<Producto>
{
    Task<IEnumerable<Producto>> GetByTop();
    Task<IEnumerable<Producto>> MoreThan3000();
    Task<Producto> MostSelled();

    Task<IEnumerable<Producto>> NoPed();
}