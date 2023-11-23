using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;
    public interface IPedido : IGenericRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> NotOnTime ();
    }