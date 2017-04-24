--select * from Empleado;
--select * from Rol;
--select * from Sucursal;
--select * from Categoria;
--select * from Producto;
--select * from Horas;
--select * from Productos_en_compra;
--select * from Productos_en_venta;
--select * from producto;
--select * from compra;
--select * from Venta;
--select * from proveedor
--update horas set ID_semana='17.14'
--select * from horas
--select getdate ()
--select * from Productos_en_venta
--select SUM(Precio_individual) from Productos_en_venta where Codigo_venta=2
--select * from venta
--select * from empleado
--update Producto set Cantidad=100 where Codigo_barras=123456 AND Codigo_sucursal='SJ45'
--delete from Venta where Codigo=2
--select * from productos_en_venta
--SELECT Descuento, Impuesto FROM Producto WHERE Codigo_sucursal='SJ45'
--SELECT Compra.Fecha_real, Proveedor.Nombre, Compra.Descripcion, Compra.Precio_total
--FROM Compra
--LEFT JOIN Proveedor ON Compra.Cedula_proveedor = Proveedor.Cedula where Compra.Codigo_sucursal='SJ45' AND Fecha_real>'2017-03-20' order by compra.Fecha_real asc;

select * from horas
select * from compra
select * from proveedor