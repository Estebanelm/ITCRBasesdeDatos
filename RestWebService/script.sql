USE [master]
GO
/****** Object:  Database [L3MDB]    Script Date: 4/18/2017 7:07:35 PM ******/
CREATE DATABASE [L3MDB]
 CONTAINMENT = NONE
GO
ALTER DATABASE [L3MDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [L3MDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [L3MDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [L3MDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [L3MDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [L3MDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [L3MDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [L3MDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [L3MDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [L3MDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [L3MDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [L3MDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [L3MDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [L3MDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [L3MDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [L3MDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [L3MDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [L3MDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [L3MDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [L3MDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [L3MDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [L3MDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [L3MDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [L3MDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [L3MDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [L3MDB] SET  MULTI_USER 
GO
ALTER DATABASE [L3MDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [L3MDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [L3MDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [L3MDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [L3MDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [L3MDB] SET QUERY_STORE = OFF
GO
USE [L3MDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [L3MDB]
GO
/****** Object:  User [IIS APPPOOL\DefaultAppPool]    Script Date: 4/18/2017 7:07:36 PM ******/
CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_datareader] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 4/18/2017 7:07:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[ID] [int] NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Codigo_producto] [int] NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Compra]    Script Date: 4/18/2017 7:07:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[Codigo] [int] NOT NULL,
	[Cedula_proveedor] [int] NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Foto] [nvarchar](50) NOT NULL,
	[Fecha_registro] [nvarchar](10) NOT NULL,
	[Fecha_real] [nvarchar](10) NOT NULL,
	[Codigo_sucursal] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 4/18/2017 7:07:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[Nombre] [nvarchar](50) NOT NULL,
	[Pri_Apellido] [nvarchar](50) NOT NULL,
	[Seg_Apellido] [nvarchar](50) NULL,
	[Cedula] [int] NOT NULL,
	[Fecha_inicio] [nvarchar](10) NOT NULL,
	[Salario_por_hora] [money] NOT NULL,
	[Fecha_nacimiento] [nvarchar](10) NOT NULL,
	[Codigo_sucursal] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Horas]    Script Date: 4/18/2017 7:07:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horas](
	[ID_semana] [nvarchar](20) NOT NULL,
	[Horas_ordinarias] [int] NULL,
	[Horas_extras] [int] NULL,
	[Ced_empleado] [int] NOT NULL,
 CONSTRAINT [PK_Horas] PRIMARY KEY CLUSTERED 
(
	[ID_semana] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Producto]    Script Date: 4/18/2017 7:07:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Exento] [bit] NOT NULL,
	[Codigo_barras] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Impuesto] [int] NOT NULL,
	[Precio_compra] [money] NOT NULL,
	[Descuento] [int] NOT NULL,
	[Codigo_sucursal] [nvarchar](50) NOT NULL,
	[Cantidad] [int] NULL,
	[Precio_venta] [money] NOT NULL,
	[Cedula_proveedor] [int] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Codigo_barras] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Productos_en_compra]    Script Date: 4/18/2017 7:07:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos_en_compra](
	[Codigo_producto] [int] NOT NULL,
	[Codigo_compra] [int] NOT NULL,
	[Cantidad] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Productos_en_venta]    Script Date: 4/18/2017 7:07:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos_en_venta](
	[Codigo_producto] [int] NOT NULL,
	[Precio_individual] [money] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Codigo_venta] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 4/18/2017 7:07:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[Cedula] [int] NOT NULL,
	[Tipo] [nvarchar](13) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 4/18/2017 7:07:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Ced_empleado] [int] NULL,
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 4/18/2017 7:07:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal](
	[Codigo] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Direccion] [nvarchar](50) NOT NULL,
	[Ced_administrador] [int] NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Venta]    Script Date: 4/18/2017 7:07:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[Codigo] [int] NOT NULL,
	[Descuento] [int] NULL,
	[Precio_total] [money] NOT NULL,
	[Codigo_sucursal] [nvarchar](50) NOT NULL,
	[Cedula_cajero] [int] NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Productoquepertenece] FOREIGN KEY([Codigo_producto])
REFERENCES [dbo].[Producto] ([Codigo_barras])
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK_Productoquepertenece]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Proveedordecompra] FOREIGN KEY([Cedula_proveedor])
REFERENCES [dbo].[Proveedor] ([Cedula])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Proveedordecompra]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Sucursalquelarealiza] FOREIGN KEY([Codigo_sucursal])
REFERENCES [dbo].[Sucursal] ([Codigo])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Sucursalquelarealiza]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_SucursalTrabajo] FOREIGN KEY([Codigo_sucursal])
REFERENCES [dbo].[Sucursal] ([Codigo])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_SucursalTrabajo]
GO
ALTER TABLE [dbo].[Horas]  WITH CHECK ADD  CONSTRAINT [FK_Realizadaspor] FOREIGN KEY([Ced_empleado])
REFERENCES [dbo].[Empleado] ([Cedula])
GO
ALTER TABLE [dbo].[Horas] CHECK CONSTRAINT [FK_Realizadaspor]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Proveedor] FOREIGN KEY([Cedula_proveedor])
REFERENCES [dbo].[Proveedor] ([Cedula])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Proveedor]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Sucursalquelocontiene] FOREIGN KEY([Codigo_sucursal])
REFERENCES [dbo].[Sucursal] ([Codigo])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Sucursalquelocontiene]
GO
ALTER TABLE [dbo].[Productos_en_compra]  WITH CHECK ADD  CONSTRAINT [FK_Codigodecompra] FOREIGN KEY([Codigo_compra])
REFERENCES [dbo].[Compra] ([Codigo])
GO
ALTER TABLE [dbo].[Productos_en_compra] CHECK CONSTRAINT [FK_Codigodecompra]
GO
ALTER TABLE [dbo].[Productos_en_compra]  WITH CHECK ADD  CONSTRAINT [FK_Productocomprado] FOREIGN KEY([Codigo_producto])
REFERENCES [dbo].[Producto] ([Codigo_barras])
GO
ALTER TABLE [dbo].[Productos_en_compra] CHECK CONSTRAINT [FK_Productocomprado]
GO
ALTER TABLE [dbo].[Productos_en_venta]  WITH CHECK ADD  CONSTRAINT [FK_Codigodeventa] FOREIGN KEY([Codigo_venta])
REFERENCES [dbo].[Venta] ([Codigo])
GO
ALTER TABLE [dbo].[Productos_en_venta] CHECK CONSTRAINT [FK_Codigodeventa]
GO
ALTER TABLE [dbo].[Productos_en_venta]  WITH CHECK ADD  CONSTRAINT [FK_Productovendido] FOREIGN KEY([Codigo_producto])
REFERENCES [dbo].[Producto] ([Codigo_barras])
GO
ALTER TABLE [dbo].[Productos_en_venta] CHECK CONSTRAINT [FK_Productovendido]
GO
ALTER TABLE [dbo].[Rol]  WITH CHECK ADD  CONSTRAINT [FK_Empleadoasignado] FOREIGN KEY([Ced_empleado])
REFERENCES [dbo].[Empleado] ([Cedula])
GO
ALTER TABLE [dbo].[Rol] CHECK CONSTRAINT [FK_Empleadoasignado]
GO
ALTER TABLE [dbo].[Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Administradopor] FOREIGN KEY([Ced_administrador])
REFERENCES [dbo].[Empleado] ([Cedula])
GO
ALTER TABLE [dbo].[Sucursal] CHECK CONSTRAINT [FK_Administradopor]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Cajeroquevende] FOREIGN KEY([Cedula_cajero])
REFERENCES [dbo].[Empleado] ([Cedula])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Cajeroquevende]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Sucursaldondeserealiza] FOREIGN KEY([Codigo_sucursal])
REFERENCES [dbo].[Sucursal] ([Codigo])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Sucursaldondeserealiza]
GO
USE [master]
GO
ALTER DATABASE [L3MDB] SET  READ_WRITE 
GO
