using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
    public class ProductMasIvaDto
    {
    public string Nombre {get; set;}
    public int UnidadesVendidas {get; set;} 
    public double Total {get; set;} 
    public double TotalIva {get; set;}

    }