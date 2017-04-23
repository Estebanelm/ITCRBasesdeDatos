--insert into rol (Nombre, Descripcion, Ced_empleado) values ('Administrador', 'Administra sucursales', 1110);
--alter table venta alter column Cedula_cajero [int] NULL;
--delete from Categoria
--insert into Categoria (Descripcion) values ('frutas')
--insert into Categoria (Descripcion) values ('verduras')
--insert into Categoria (Descripcion) values ('carnes')
--drop table Categoria
--alter table venta add [Activo] [bit] Default 1
--drop table horas
--insert into Horas (ID_semana,Horas_ordinarias,Horas_extras,Ced_empleado) values ('17-14',45,10,115250560)
--alter table productos_en_compra alter column Codigo_producto [int] NULL;
--alter table productos_en_venta alter column Codigo_producto [int] NULL;
--update Productos_en_compra set Codigo_producto=NULL where Codigo_compra=1
--update Productos_en_venta set Codigo_producto=NULL where Codigo_venta=1

--alter table Producto add constraint PK_ProductoSucursal PRIMARY KEY ([Codigo_barras] ASC, [Codigo_sucursal] ASC) ON [PRIMARY]
--drop table Producto

--Insert into Productos_en_compra (Codigo_producto,Codigo_compra,Cantidad) values (123456, 1, 3)
--insert into Productos_en_venta (Codigo_producto,Precio_individual,Cantidad,Codigo_venta) values (123456, 1500.00, 4, 2)

--insert into Sucursal (Codigo,Nombre,Telefono,Direccion) values ('SJ01','San Jose Central', 24987564, 'Frente al Mercado Central')
--insert into Sucursal (Codigo,Nombre,Telefono,Direccion) values ('SJ02','Tibas', 45698765, 'En Tibas, a la par del estadio')
--insert into Sucursal (Codigo,Nombre,Telefono,Direccion) values ('SJ03','Desamparados', 46985746, 'Desamparados, diagonal a la mucap')
--insert into Sucursal (Codigo,Nombre,Telefono,Direccion) values ('AJ02','Alajuela Centro', 78965874, 'Frente al CityMall')
--insert into Sucursal (Codigo,Nombre,Telefono,Direccion) values ('AJ03','San Carlos', 74521875, 'Esquina Oeste del Hospital')
--insert into Sucursal (Codigo,Nombre,Telefono,Direccion) values ('AJ04','Palmares', 47851265, 'Dentro del Centro Comercial Pancha, local 32')
--insert into Sucursal (Codigo,Nombre,Telefono,Direccion) values ('HD01','Heredia Central', 65874125, 'Heredia Centro, al lado de la Muni')
--insert into Sucursal (Codigo,Nombre,Telefono,Direccion) values ('HD03','Santo Domingo', 98567424, 'Santo Domingo, frente al cole')

