using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities; 
    public class DetallePedido
    {
        public int CodigoPedido { get; set; }
        public Pedido Pedido {get; set;}
        public string CodigoProducto {get; set;}
        public Producto Producto {get; set;}
        public int Cantidad {get; set;}
        public double PrecioUnidad {get; set;}
        public short NumeroLinea {get; set;}
    }