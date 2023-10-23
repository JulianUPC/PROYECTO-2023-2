USE [master]
GO
/****** Object:  Database [ConcesionarioBase]    Script Date: 22/10/2023 9:35:55 p. m. ******/
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
/****** Object:  Table [dbo].[AUTOS]    Script Date: 22/10/2023 9:35:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUTOS](
	[Nombre_Auto] [varchar](50) NOT NULL,
	[Precio] [int] NULL,
	[Modelo] [varchar](20) NULL,
	[Categoria] [varchar](20) NULL,
	[Motor] [varchar](30) NULL,
	[Potencia] [varchar](20) NULL,
	[Valvulas] [varchar](30) NULL,
	[Asientos] [varchar](20) NULL,
	[Sistema_Combustible] [varchar](20) NULL,
	[Tipo_Transmision] [varchar](30) NULL,
 CONSTRAINT [PK__AUTOS__6F8F41069EB27F63] PRIMARY KEY CLUSTERED 
(
	[Nombre_Auto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENTES]    Script Date: 22/10/2023 9:35:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTES](
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
PRIMARY KEY CLUSTERED 
(
	[N_Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPLEADOS]    Script Date: 22/10/2023 9:35:56 p. m. ******/
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
PRIMARY KEY CLUSTERED 
(
	[ID_Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FINANCIERO]    Script Date: 22/10/2023 9:35:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FINANCIERO](
	[Tipo] [varchar](10) NULL,
	[Fecha_Ingreso] [date] NULL,
	[Monto_Ingresos] [int] NULL,
	[Fecha_Gasto] [date] NULL,
	[Monto_Gastos] [int] NULL,
	[Nombre_Auto] [varchar](40) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INVENTARIO]    Script Date: 22/10/2023 9:35:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INVENTARIO](
	[Fecha_Compra] [date] NULL,
	[Matricula] [varchar](10) NOT NULL,
	[Nombre_Auto] [varchar](20) NULL,
	[Precio] [int] NULL,
	[Marca] [varchar](20) NULL,
	[Modelo] [varchar](20) NULL,
	[Categoria] [varchar](20) NULL,
	[Motor] [varchar](20) NULL,
	[Potencia] [varchar](20) NULL,
	[Valvulas] [varchar](30) NULL,
	[Asientos] [varchar](20) NULL,
	[Sistema_Combustible] [varchar](20) NULL,
	[Tipo_Transmision] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'BMW Serie 8 Convertible', 79605, N'2023', N'Convertibles', N'Turbo Premium V-8 4.4L', N'617 HP', N'DOHC(4 válvulas por cilindro)', N'4', N'Gasolina', N'Automática con OD')
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'Captiva Turbo', 29109, N'2023', N'Camionetas', N'1.5L Turbo', N'147 HP', N'DOHC(4 válvulas por cilindro)', N'5', N'Gasolina', N'Automática CVT')
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'Chevrolet Bolt EUV', 46948, N'2023', N'Electricos', N' Motor eléctrico', N'200 HP', N'No tiene', N'5', N'Eléctrico', N'Directa')
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'Chevrolet Camaro', 60473, N'2023', N'Deportivos', N'Motor Turbo de 2.0L', N'275 HP', N'DOHC(4 válvulas por cilindro)', N'2', N'Gasolina', N'Manual')
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'Corvette Stingray', 199711, N'2023', N'Deportivos', N'Motor V8 6.2L', N'495 HP', N'DOHC(4 válvulas por cilindro)', N'2', N'Gasolina', N'Automatica')
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'Ford Explorer ST', 68055, N'2023', N'Performance', N' Motor EcoBoost 3.0L', N'400 HP', N'DOHC (4 válvulas por cilindro)', N'6', N'Gasolina', N'Automatico')
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'Ford Ranger Raptor', 87925, N'2023', N'Performance', N' Motor EcoBoost 3.0L', N'405 HP', N'DOHC (4 válvulas por cilindro)', N'5', N'Gasolina', N'Automatico')
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'Hyundai IONIQ 5', 61036, N'2023', N'Electricos', N' Motor eléctrico', N'225 HP', N'No tiene', N'5', N'Eléctrico', N'Directa')
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'Kicks Exclusive', 23123, N'2024', N'Camionetas', N'1.6 L', N'122 HP', N'DOHC(4 válvulas por cilindro)', N'4', N'Gasolina', N'Variable Continua')
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'Kona Electric', 34037, N'2022', N'Electricos', N' Motor eléctrico', N'201 HP', N'No tiene', N'5', N'Eléctrico', N'Directa')
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'Mazda MX-30 EV', 35142, N'2023', N'Electricos', N' Motor eléctrico', N'143 HP', N'No tiene', N'5', N'Eléctrico', N'Directa')
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'Mazda MX-5', 17214, N'2023', N'Convertibles', N'gasolina Premium 1.6L', N'181 HP', N'DOHC(4 válvulas por cilindro)', N'2', N'Gasolina', N'Manual')
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'Mercedes AMG GT', 105640, N'2021', N'Deportivos', N' Motor AMG V8 de 4.0L', N'630 HP', N'DOHC(4 válvulas por cilindro)', N'4', N'Gasolina', N'Automatica')
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'Mustang Mach 1', 75067, N'2024', N'Performance', N' Motor V8 de 5.0L', N'470 HP', N'DOHC (4 válvulas por cilindro)', N'4', N'Gasolina', N'Manual')
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'Range Rover Evoque', 33006, N'2017', N'Convertible', N'Motor Turbo de 2.0L', N'240 HP', N'DOHC(4 válvulas por cilindro)', N'5', N'Gasolina', N'Automatica')
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'Tracker Turbo', 26235, N'2023', N'Camionetas', N'1.2L', N'130 HP', N'DOHC(4 válvulas por cilindro)', N'5', N'Gasolina', N'Automatica')
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'Tracker Turbo RS', 25181, N'2024', N'Camionetas', N'1.2L', N'132 HP', N'DOHC(4 válvulas por cilindro)', N'4', N'Gasolina', N'Automatica')
INSERT [dbo].[AUTOS] ([Nombre_Auto], [Precio], [Modelo], [Categoria], [Motor], [Potencia], [Valvulas], [Asientos], [Sistema_Combustible], [Tipo_Transmision]) VALUES (N'Traverse RS', 34391, N'2023', N'Camionetas', N'3.6L V6', N'310 HP', N'DOHC(4 válvulas por cilindro)', N'5', N'Gasolina', N'Automatica')
GO
INSERT [dbo].[EMPLEADOS] ([ID_Empleado], [N_identificacion], [Nombre_Completo], [Fecha_Ingreso], [Pago_Mes], [Monto_Comision]) VALUES (N'101', N'1003266311', N'Jose Martinez', CAST(N'2023-10-22' AS Date), 2000, 0)
INSERT [dbo].[EMPLEADOS] ([ID_Empleado], [N_identificacion], [Nombre_Completo], [Fecha_Ingreso], [Pago_Mes], [Monto_Comision]) VALUES (N'103', N'1003266313', N'Maria Zuñiga', CAST(N'2023-10-22' AS Date), 2000, 0)
GO
USE [master]
GO
ALTER DATABASE [ConcesionarioBase] SET  READ_WRITE 
GO
