using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Pedido : BaseEntity 
{
    public DateOnly ? FechaPedido {get; set;}
    public DateOnly ? FechaEsperada {get; set;}
    public  DateOnly ? FechaEntrega {get;set;}
    public string Estado {get; set;}
    public string ? Comentarios {get; set;}
    public int ? CodigoCliente {get; set;}
    public Cliente Cliente {get; set;}
    public ICollection<DetallePedido> DetallePedidos {get; set;}
    public ICollection<Producto> Productos {get; set;}
}