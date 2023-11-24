## Devuelve un listado con el código de pedido, código de cliente, fecha esperada y fecha de entrega de los pedidos que no han sido entregados a tiempo.
```
http://localhost:5096/api/pedido/notontime
```
## Codigo
```
public async Task<IEnumerable<Pedido>> NotOnTime (){
        return await _context.Pedido.Where(e => e.FechaEsperada < e.FechaEntrega).ToListAsync();
    }
```
## Devuelve un listado con el código de pedido, código de cliente, fecha esperada y fecha de entrega de los pedidos que no han sido entregados a tiempo.
```
http://localhost:5096/api/cliente/GetNoPaid
```
## Devuelve el nombre de los clientes que no hayan hecho pagos y el nombre de sus representantes junto con la ciudad de la oficina a la que pertenece el representante.
```
http://localhost:5096/api/oficina/NoFrutales
```
## Devuelve las oficinas donde no trabajan ninguno de los empleados que hayan sido los representantes de ventas de algún cliente que haya realizado la compra de algún producto de la gama Frutales.
```
http://localhost:5096/api/producto/GetMoreTop
```
## Devuelve un listado de los 20 productos más vendidos y el número total de unidades que se han vendido de cada uno. El listado deberá estar ordenado por el número total de unidades vendidas.
```
http://localhost:5096/api/producto/GetMoreThan3000
```
## Lista las ventas totales de los productos que hayan facturado más de 3000 euros. Se mostrará el nombre, unidades vendidas, total facturado y total facturado con impuestos (21% IVA).
```
http://localhost:5096/api/producto/MostSelled
```
## Devuelve el listado de clientes indicando el nombre del cliente y cuántos pedidos ha realizado. Tenga en cuenta que pueden existir clientes que no han realizado ningún pedido.
```
http://localhost:5096/api/cliente/GetByPed
```
## Devuelve el listado de clientes donde aparezca el nombre del cliente, el nombre y primer apellido de su representante de ventas y la ciudad donde está su oficina.
```
http://localhost:5096/api/cliente/GetWithEmp
```
## Devuelve un listado con los datos de los empleados que no tienen clientes asociados y el nombre de su jefe asociado.
```
http://localhost:5096/api/empleado/NoClients
```
## Devuelve un listado de los productos que nunca han aparecido en un pedido. El resultado debe mostrar el nombre, la descripción y la imagen del producto.
```
http://localhost:5096/api/producto/NoPedProd
```

