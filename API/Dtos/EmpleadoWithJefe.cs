using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class EmpleadoWithJefe
{
    public string Nombre { get; set; }
    public string Apellido1 { get; set; }
    public string Apellido2 { get; set; }
    public string Extension { get; set; }
    public string Email { get; set; }
    public string CodigoOficina { get; set; }
    public int? CodigoJefe { get; set; }
    public string Puesto { get; set; }
    public string Jefe {get; set;}
}