### Devuelve un listado con el código de pedido, código de cliente, fecha esperada y fecha de entrega de los pedidos que no han sido entregados a tiempo.
```
http://localhost:5096/api/pedido/notontime
```
### Codigo
```
  public async Task<IEnumerable<Pedido>> NotOnTime (){
        return await _context.Pedido.Where(e => e.FechaEsperada < e.FechaEntrega).ToListAsync();
    }
```
### Explicacion
el codigo busca en la entidad pedido una fecha esperada que sea menor a la fecha entrega y lo devuelve como una lista

### Devuelve el nombre de los clientes que no hayan hecho pagos y el nombre de sus representantes junto con la ciudad de la oficina a la que pertenece el representante.
```
http://localhost:5096/api/cliente/GetNoPaid
```
### Codigo
```
public async Task<IEnumerable<Cliente>> GetNoPagos(){
        return await _context.Clientes
        .Include(e => e.Pagos)
        .Include(e => e.Empleado)
        .ThenInclude(e => e.Oficina)
        .Where(e => e.Pagos.Count == 0).ToListAsync();
    }
```
### Explicacion
el codigo busca en la entidad cliente, usando el metodo where para buscar el cliente cuya candidad de pagos sea igual a cero y luego lo mapeo en un dto para dar el resultado esperado

### Devuelve las oficinas donde no trabajan ninguno de los empleados que hayan sido los representantes de ventas de algún cliente que haya realizado la compra de algún producto de la gama Frutales.
```
http://localhost:5096/api/oficina/NoFrutales
```
### Codigo
```
 public async Task<IEnumerable<Oficina>> GetNoFrutales(){
        return await _context.Oficinas
        .Include(e => e.Empleados)
        .ThenInclude(e => e.Clientes)
        .ThenInclude(e => e.Pedidos)
        .ThenInclude(e => e.Productos)
        .Where(e => !e.Empleados.SelectMany(e => e.Clientes).SelectMany(e => e.Pedidos).SelectMany(e => e.Productos).Where(e => e.Gama.ToLower() == "frutales").Any())
        .ToListAsync();
    }
```
### Explicacion
el codigo busca en la entidad oficina incluyendo cada una de las entidades relacionadas hasta producto donde verifica la existencia de productos con esa gama y los filtra con el metodo any
### Devuelve un listado de los 20 productos más vendidos y el número total de unidades que se han vendido de cada uno. El listado deberá estar ordenado por el número total de unidades vendidas.
```
http://localhost:5096/api/producto/GetMoreTop
```
### Codigo
```
 public async Task<IEnumerable<Producto>> GetByTop(){
        return await _context.Productos
        .Include(e => e.DetallePedidos)
        .OrderByDescending(e => e.DetallePedidos.Select(e => e.Cantidad).Sum())
        .Take(20)
        .ToListAsync();
    }
```
### Explicacion
Usamos la entidad Productos e incluimos detallespedidos, luego los ordenamos de forma descendiente con el metodo orderByDescending usando como expresion una suma de la seleccion de la cantidad por producto y tomando solo 20 de ellos con el metodo Take
### Lista las ventas totales de los productos que hayan facturado más de 3000 euros. Se mostrará el nombre, unidades vendidas, total facturado y total facturado con impuestos (21% IVA).
```
http://localhost:5096/api/producto/GetMoreThan3000
```
### Codigo
```
 public async Task<IEnumerable<Producto>> MoreThan3000(){
        return await _context.Productos
        .Include(e => e.DetallePedidos)
        .Where(e => e.DetallePedidos.Select(e => e.PrecioUnidad).Sum() >= 3000)
        .ToListAsync();
    }
```
### Explicacion
Usamos la entidad Productos e incluimos detallespedidos, luego buscamos usando el metodo Where usando la suma del preciounidad que se encuentra en detallePedidos, con la logica de que su suma en cada elemento sea mayor a 3000
### Devuelve el nombre del producto del que se han vendido más unidades. (Tenga en cuenta que tendrá que calcular cuál es el número total de unidades que se han vendido de cada producto a partir de los datos de la tabla detalle_pedido)
```
http://localhost:5096/api/producto/MostSelled
```
### Codigo 
```
public async Task<Producto> MostSelled(){
        return await _context.Productos
        .Include(e => e.DetallePedidos)
        .OrderByDescending(e => e.DetallePedidos.Select(e => e.Cantidad).Sum())
        .FirstAsync();
    }
```
### Explicacion
Se llama a la lista de productos e incluyendo DetallePedidos y la ordenamos con la suma de la cantidad en DetallePedidos y seleccionando el primero en la lista.

### Devuelve el listado de clientes indicando el nombre del cliente y cuántos pedidos ha realizado. Tenga en cuenta que pueden existir clientes que no han realizado ningún pedido.
```
http://localhost:5096/api/cliente/GetByPed
```
### Codigo
```
public override async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes.Include(e => e.Pedidos)
        .Include(e => e.Empleado)
        .ThenInclude(e => e.Oficina)
        .ToListAsync();
    }
```
### Explicacion 
Se sobreescribe el metodo generico de GetAllAsync para que incluyan los pedidos y lo que sigue seria mapearlo para que suma la cantidad de pedidos que pertenecen a ese cliente

### Devuelve el listado de clientes donde aparezca el nombre del cliente, el nombre y primer apellido de su representante de ventas y la ciudad donde está su oficina.
```
http://localhost:5096/api/cliente/GetWithEmp
```
### Codigo 
```
public override async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes.Include(e => e.Pedidos)
        .Include(e => e.Empleado)
        .ThenInclude(e => e.Oficina)
        .ToListAsync();
    }
```
### Explicacion 
Como la logica de arriba usamos el mismo metodo y solo mapeamos el resultado para que de lo esperado
### Devuelve un listado con los datos de los empleados que no tienen clientes asociados y el nombre de su jefe asociado.
```
http://localhost:5096/api/empleado/NoClients
```
### Codigo 
```
 public async Task<IEnumerable<Empleado>> GetWithNoClients(){
        return await _context.Empleados
        .Include(e => e.Jefe)
        .Where(e => e.Clientes.Count() == 0).ToListAsync();
    }
```
### Explicacion 
LLamamos a los empleados e incluimos a si mismo con el seudonimo de jefe, usando el metodo Where seleccionamos solo los que tengan asignados 0 clientes y mapeamos con un dto
### Devuelve un listado de los productos que nunca han aparecido en un pedido. El resultado debe mostrar el nombre, la descripción y la imagen del producto.
```
http://localhost:5096/api/producto/NoPedProd
```
### Codigo 
```
 public async Task<IEnumerable<Producto>> NoPed(){
        return await _context.Productos
        .Include(e => e.DetallePedidos)
        .Include(e => e.GamaProducto)
        .Where(e => e.Pedidos.Count() == 0)
        .ToListAsync();
    }
```
### Explicacion 
LLamamos a los Productos e incluimos a detallesPedidos y a GamaProducto y con el metodo Where solo seleccionamos aquellos Productos que tengan asignados 0 pedidos
