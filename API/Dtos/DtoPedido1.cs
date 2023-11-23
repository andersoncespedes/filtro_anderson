using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class DtoPedido1
{
    public int Id {get; set;}
    public DateOnly? FechaPedido { get; set; }
    public DateOnly? FechaEntrega { get; set; }
    public int? CodigoCliente { get; set; }
}