USE [master]
GO
/****** Object:  Database [ConcesionarioBase]    Script Date: 25/11/2023 7:32:57 p. m. ******/
CREATE DATABASE [ConcesionarioBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ConcesionarioBase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ConcesionarioBase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ConcesionarioBase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ConcesionarioBase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ConcesionarioBase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ConcesionarioBase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ConcesionarioBase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET ARITHABORT OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ConcesionarioBase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ConcesionarioBase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ConcesionarioBase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ConcesionarioBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ConcesionarioBase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ConcesionarioBase] SET  MULTI_USER 
GO
ALTER DATABASE [ConcesionarioBase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ConcesionarioBase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ConcesionarioBase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ConcesionarioBase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ConcesionarioBase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ConcesionarioBase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ConcesionarioBase] SET QUERY_STORE = OFF
GO
USE [ConcesionarioBase]
GO
/****** Object:  Table [dbo].[AUTOS]    Script Date: 25/11/2023 7:32:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUTOS](
	[Nombre_Auto] [varchar](50) NOT NULL,
	[Precio_Compra] [int] NULL,
	[Modelo] [varchar](20) NULL,
	[Categoria] [varchar](20) NULL,
	[Motor] [varchar](30) NULL,
	[Potencia] [varchar](20) NULL,
	[Valvulas] [varchar](30) NULL,
	[Asientos] [varchar](20) NULL,
	[Sistema_Combustible] [varchar](20) NULL,
	[Tipo_Transmision] [varchar](30) NULL,
	[ID_Auto] [varchar](5) NULL,
	[Precio_Venta] [int] NULL,
 CONSTRAINT [PK__AUTOS__6F8F41069EB27F63] PRIMARY KEY CLUSTERED 
(
	[Nombre_Auto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENTES]    Script Date: 25/11/2023 7:32:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTES](
	[Id_Cliente] [varchar](5) NULL,
	[N_Identificacion] [int] NOT NULL,
	[Nombre_Completo] [varchar](50) NULL,
	[Fecha_Nacimiento] [date] NULL,
	[Genero] [varchar](10) NULL,
	[Direccion] [varchar](20) NULL,
	[Telefono] [varchar](11) NULL,
	[Trabaja] [varchar](2) NULL,
	[Cargo] [varchar](20) NULL,
	[Presupuesto] [int] NULL,
	[Ingresos_Mensuales] [int] NULL,
	[Fecha_Registro] [date] NULL,
	[Licencia] [varchar](2) NULL,
	[Usuario] [varchar](50) NULL,
	[Contraseña] [varchar](50) NULL,
	[Autos_Comprados] [int] NULL,
	[Correo_Electronico] [varchar](60) NULL,
 CONSTRAINT [PK__CLIENTES__0D1D94C00B729518] PRIMARY KEY CLUSTERED 
(
	[N_Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPLEADOS]    Script Date: 25/11/2023 7:32:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLEADOS](
	[ID_Empleado] [varchar](10) NOT NULL,
	[N_identificacion] [varchar](10) NULL,
	[Nombre_Completo] [varchar](40) NULL,
	[Fecha_Ingreso] [date] NULL,
	[Pago_Mes] [int] NULL,
	[Monto_Comision] [int] NULL,
	[Cargo] [varchar](9) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FINANZAS]    Script Date: 25/11/2023 7:32:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FINANZAS](
	[Tipo] [varchar](17) NULL,
	[Fecha_Ingreso] [date] NULL,
	[Monto_Ingresos] [int] NULL,
	[Fecha_Gasto] [date] NULL,
	[Monto_Gastos] [int] NULL,
	[Nombre_Auto] [varchar](40) NULL,
	[Monto_Total] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INVENTARIO]    Script Date: 25/11/2023 7:32:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INVENTARIO](
	[Fecha_Compra] [date] NULL,
	[Matricula] [varchar](10) NOT NULL,
	[Nombre_Auto] [varchar](40) NULL,
	[Precio_Venta] [int] NULL,
	[Modelo] [varchar](20) NULL,
	[Categoria] [varchar](20) NULL,
	[Motor] [varchar](40) NULL,
	[Potencia] [varchar](20) NULL,
	[Valvulas] [varchar](30) NULL,
	[Asientos] [varchar](20) NULL,
	[Sistema_Combustible] [varchar](20) NULL,
	[Tipo_Transmision] [varchar](20) NULL,
	[Id_Auto] [varchar](5) NULL,
 CONSTRAINT [PK__INVENTAR__0FB9FB4E64340E4D] PRIMARY KEY CLUSTERED 
(
	[Matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VENTAS]    Script Date: 25/11/2023 7:32:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VENTAS](
	[Id_Cliente] [varchar](5) NULL,
	[Comprador] [varchar](50) NULL,
	[Nombre_Vendedor] [varchar](50) NULL,
	[Fecha_Vendido] [date] NULL,
	[Precio_Vendido] [int] NULL,
	[Id_Auto] [varchar](5) NULL,
	[Matricula] [varchar](10) NULL,
	[Nombre_Auto] [varchar](50) NULL,
	[Categoria] [varchar](20) NULL,
	[Motor] [varchar](40) NULL,
	[Potencia] [varchar](40) NULL,
	[Sistema_Combustible] [varchar](50) NULL,
	[Tipo_Transmision] [varchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'BMW Serie 8 Convertible', 67613, N'2023', N'Convertibles', N'Turbo Premium V-8 4.4L', N'617 HP', N'DOHC(4 válvulas por cilindro)', N'4', N'Gasolina', N'Automática con OD', N'A01', 72300)
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'Captiva Turbo', 23101, N'2023', N'Camionetas', N'Motor Turbo de 1.5L', N'147 HP', N'DOHC(4 válvulas por cilindro)', N'5', N'Gasolina', N'Automática CVT', N'A02', 25000)
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'Chevrolet Bolt EUV', 41238, N'2023', N'Electricos', N'Motor eléctrico', N'200 HP', N'No tiene', N'5', N'Eléctrico', N'Directa', N'A03', 47229)
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'Chevrolet Camaro', 54423, N'2023', N'Deportivos', N'Motor Turbo de 2.0L', N'275 HP', N'DOHC(4 válvulas por cilindro)', N'2', N'Gasolina', N'Manual', N'A04', 60000)
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'Corvette Stingray', 176124, N'2023', N'Deportivos', N'Motor V8 6.2L', N'495 HP', N'DOHC(4 válvulas por cilindro)', N'2', N'Gasolina', N'Automatica', N'A05', 183234)
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'Ford Explorer ST', 58967, N'2023', N'Performance', N'Motor EcoBoost 3.0L', N'400 HP', N'DOHC (4 válvulas por cilindro)', N'6', N'Gasolina', N'Automatico', N'A06', 63001)
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'Ford Ranger Raptor', 81895, N'2023', N'Performance', N'Motor EcoBoost 3.0L', N'405 HP', N'DOHC (4 válvulas por cilindro)', N'5', N'Gasolina', N'Automatico', N'A07', 84102)
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'Hyundai IONIQ 5', 57297, N'2023', N'Electricos', N'Motor eléctrico', N'225 HP', N'No tiene', N'5', N'Eléctrico', N'Directa', N'A08', 61230)
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'Kicks Exclusive', 20298, N'2024', N'Camionetas', N'Motor Turbo de 1.6 L', N'122 HP', N'DOHC(4 válvulas por cilindro)', N'4', N'Gasolina', N'Variable Continua', N'A09', 22000)
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'Kona Electric', 30145, N'2022', N'Electricos', N'Motor eléctrico', N'201 HP', N'No tiene', N'5', N'Eléctrico', N'Directa', N'A010', 32194)
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'Mazda MX-30 EV', 32784, N'2023', N'Electricos', N'Motor eléctrico', N'143 HP', N'No tiene', N'5', N'Eléctrico', N'Directa', N'A011', 35974)
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'Mazda MX-5', 13534, N'2023', N'Convertibles', N'Motor Premium de 1.6L', N'181 HP', N'DOHC(4 válvulas por cilindro)', N'2', N'Gasolina', N'Manual', N'A012', 16784)
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'Mercedes AMG GT', 101274, N'2021', N'Deportivos', N' Motor AMG V8 de 4.0L', N'630 HP', N'DOHC(4 válvulas por cilindro)', N'4', N'Gasolina', N'Automatica', N'A013', 107832)
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'Mustang Mach 1', 71845, N'2024', N'Performance', N' Motor V8 de 5.0L', N'470 HP', N'DOHC (4 válvulas por cilindro)', N'4', N'Gasolina', N'Manual', N'A014', 74879)
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'Range Rover Evoque', 84242, N'2017', N'Convertible', N'Motor Turbo de 2.0L', N'240 HP', N'DOHC(4 válvulas por cilindro)', N'5', N'Gasolina', N'Automatica', N'A015', 94200)
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'Tracker Turbo', 23964, N'2023', N'Camionetas', N'Motor Turbo de 1.2L', N'130 HP', N'DOHC(4 válvulas por cilindro)', N'5', N'Gasolina', N'Automatica', N'A016', 27500)
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'Tracker Turbo RS', 21284, N'2024', N'Camionetas', N'Motor Turbo de 1.2L', N'132 HP', N'DOHC(4 válvulas por cilindro)', N'4', N'Gasolina', N'Automatica', N'A017', 26092)
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio_Compra], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision], [ID_Auto], [Precio_Venta]) VALUES (N'Traverse RS', 30932, N'2023', N'Camionetas', N'Motor EcoBoos de 3.6L V6', N'310 HP', N'DOHC(4 válvulas por cilindro)', N'5', N'Gasolina', N'Automatica', N'A018', 32500)
GO
USE [master]
GO
ALTER DATABASE [ConcesionarioBase] SET  READ_WRITE 
GO
