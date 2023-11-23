using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Pago
{
     public int CodigoCliente {get; set;}
    public string FormaPago {get; set;}  
    public Cliente Cliente {get; set;}
    public string IdTransaccion {get; set;}
    public DateOnly FechaPago {get; set;}
    public double Total {get; set;}
}