/****** Object:  Table [dbo].[T_Cita]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Cita](
	[id_Cita] [nvarchar](100) NOT NULL,
	[fecha_Cita] [datetime] NULL,
	[hora_Cita] [nvarchar](50) NULL,
	[id_Obra_Cita] [nvarchar](50) NULL,
	[lugar_Cita] [varchar](500) NULL,
 CONSTRAINT [PK_T_Cita] PRIMARY KEY CLUSTERED 
(
	[id_Cita] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Cliente]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Cliente](
	[dni] [int] NOT NULL,
	[nombre] [nvarchar](100) NULL,
	[apellido] [nvarchar](100) NULL,
	[celular] [int] NULL,
	[correo] [nvarchar](100) NULL,
	[direccion] [nvarchar](500) NULL,
 CONSTRAINT [PK_T_Cliente] PRIMARY KEY CLUSTERED 
(
	[dni] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Cotizacion]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Cotizacion](
	[id_Cotizacion] [nvarchar](200) NOT NULL,
	[fecha] [datetime] NULL,
	[total] [decimal](18, 0) NULL,
	[id_Obra_Cotizacion] [nvarchar](50) NULL,
	[id_Cotizacion_Estado] [int] NULL,
 CONSTRAINT [PK_T_Cotizacion] PRIMARY KEY CLUSTERED 
(
	[id_Cotizacion] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_CotizacionxUnidad]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_CotizacionxUnidad](
	[id_Serie] [nvarchar](100) NOT NULL,
	[id_Cotizacion] [nvarchar](200) NOT NULL,
	[cantidad] [int] NULL,
 CONSTRAINT [PK_T_CotizacionxUnidad] PRIMARY KEY CLUSTERED 
(
	[id_Serie] ASC,
	[id_Cotizacion] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_EstadoCotizacion]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_EstadoCotizacion](
	[id_Estado_Cotizacion] [int] IDENTITY(1,1) NOT NULL,
	[nombre_Estado_Cotizacion] [nvarchar](100) NULL,
	[descripcion_Estado_Cotizacion] [nvarchar](100) NULL,
 CONSTRAINT [PK_T_EstadoCotizacion] PRIMARY KEY CLUSTERED 
(
	[id_Estado_Cotizacion] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_EstadoObra]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_EstadoObra](
	[id_EstadoObra] [int] IDENTITY(1,1) NOT NULL,
	[nombre_Estado_Obra] [nvarchar](100) NULL,
	[descripcion_Estado_Obra] [nvarchar](100) NULL,
 CONSTRAINT [PK_T_EstadoObra] PRIMARY KEY CLUSTERED 
(
	[id_EstadoObra] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_EstadoPedido]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_EstadoPedido](
	[id_Estado_Pedido] [int] IDENTITY(1,1) NOT NULL,
	[nombre_Estado_Pedido] [nvarchar](100) NULL,
	[descripcion_Estado_Pedido] [nvarchar](max) NULL,
 CONSTRAINT [PK_T_EstadoPedido] PRIMARY KEY CLUSTERED 
(
	[id_Estado_Pedido] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_EstadoTrabajador]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_EstadoTrabajador](
	[id_Estado_Trabajador] [int] IDENTITY(1,1) NOT NULL,
	[nombre_Estado_Trabajador] [nvarchar](200) NULL,
	[descripcionEstadoTrabajador] [nvarchar](500) NULL,
 CONSTRAINT [PK_T_EstadoTrabajador] PRIMARY KEY CLUSTERED 
(
	[id_Estado_Trabajador] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_EstadoUnidad]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_EstadoUnidad](
	[id_Estado_Unidad] [int] IDENTITY(1,1) NOT NULL,
	[nombre_Estado_Unidad] [nvarchar](200) NULL,
	[descripcion_Estado_Unidad] [nvarchar](500) NULL,
 CONSTRAINT [PK_T_EstadoUnidad] PRIMARY KEY CLUSTERED 
(
	[id_Estado_Unidad] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Factura]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Factura](
	[id_Factura] [nvarchar](50) NOT NULL,
	[imagen] [varchar](max) NULL,
	[id_Cotizacion_Factura] [nvarchar](200) NULL,
 CONSTRAINT [PK_T_Factura] PRIMARY KEY CLUSTERED 
(
	[id_Factura] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Incidencia]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Incidencia](
	[id_Incidencia] [nvarchar](50) NOT NULL,
	[fecha_Horario] [datetime] NULL,
	[incidencia] [nvarchar](max) NULL,
	[horas_Trabajadas] [int] NULL,
	[id_Pedido_Incidencia] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_Incidencia] PRIMARY KEY CLUSTERED 
(
	[id_Incidencia] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Obra]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Obra](
	[id_Obra] [nvarchar](50) NOT NULL,
	[empresa] [nvarchar](500) NULL,
	[direccion] [nvarchar](500) NULL,
	[nombre_Obra] [nvarchar](500) NULL,
	[imagen] [varchar](max) NULL,
	[fecha_Inicio] [datetime] NULL,
	[duracion_Obra] [int] NULL,
	[id_Usuario_Obra] [nvarchar](100) NULL,
	[id_Obra_Estado] [int] NULL,
 CONSTRAINT [PK_T_Obra] PRIMARY KEY CLUSTERED 
(
	[id_Obra] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_ObraxPartida]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_ObraxPartida](
	[id_Partida] [nvarchar](50) NOT NULL,
	[id_Obra] [nvarchar](50) NOT NULL,
	[metrado] [decimal](18, 0) NULL,
	[unidad] [nvarchar](50) NULL,
	[parcial] [decimal](18, 0) NULL,
 CONSTRAINT [PK_T_ObraxPartida] PRIMARY KEY CLUSTERED 
(
	[id_Partida] ASC,
	[id_Obra] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_OrdenServicio]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_OrdenServicio](
	[id_Orden] [nvarchar](50) NOT NULL,
	[fecha_Orden] [datetime] NULL,
	[liquidacion] [decimal](18, 0) NULL,
	[id_Pedido_Orden] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_OrdenServicio] PRIMARY KEY CLUSTERED 
(
	[id_Orden] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Pago]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Pago](
	[id_Pago] [nvarchar](200) NOT NULL,
	[fecha] [datetime] NULL,
	[pago1] [decimal](18, 0) NULL,
	[pago2] [decimal](18, 0) NULL,
	[id_Cotizacion_Pago] [nvarchar](200) NULL,
 CONSTRAINT [PK_T_Pago] PRIMARY KEY CLUSTERED 
(
	[id_Pago] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Partida]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Partida](
	[id_Partida] [nvarchar](50) NOT NULL,
	[nombre_Partida] [nvarchar](max) NULL,
	[precio_Unidad] [decimal](18, 0) NULL,
	[id_Tipo_Partida] [int] NULL,
 CONSTRAINT [PK_T_Partida] PRIMARY KEY CLUSTERED 
(
	[id_Partida] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Pedido]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Pedido](
	[id_Pedido] [nvarchar](50) NOT NULL,
	[fecha_Inicio] [datetime] NULL,
	[cantidad_Dias] [int] NULL,
	[obra] [nvarchar](max) NULL,
	[empresa] [nvarchar](max) NULL,
	[ubicacion] [nvarchar](max) NULL,
	[fecha_Entrega] [datetime] NULL,
	[precio_Pedido] [decimal](18, 0) NULL,
	[id_Estado_Pedido] [int] NULL,
	[id_Usuario_Pedido] [nvarchar](100) NULL,
	[id_Trabajador_Pedido] [int] NULL,
	[id_Unidad_Pedido] [nvarchar](100) NULL,
 CONSTRAINT [PK_T_Pedido] PRIMARY KEY CLUSTERED 
(
	[id_Pedido] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Rol]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Rol](
	[id_Rol] [int] IDENTITY(1,1) NOT NULL,
	[nombre_Rol] [nvarchar](200) NULL,
	[descripcion_Rol] [nvarchar](500) NULL,
 CONSTRAINT [PK_T_Rol] PRIMARY KEY CLUSTERED 
(
	[id_Rol] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_TipoPartida]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TipoPartida](
	[id_Tipo_Partida] [int] IDENTITY(1,1) NOT NULL,
	[nombre_Tipo_Partida] [nvarchar](200) NULL,
	[descripcion_Tipo_Partida] [nvarchar](500) NULL,
 CONSTRAINT [PK_T_TipoPartida] PRIMARY KEY CLUSTERED 
(
	[id_Tipo_Partida] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_TipoTrabajador]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TipoTrabajador](
	[id_Tipo_Trabajdor] [int] IDENTITY(1,1) NOT NULL,
	[nombre_Tipo_Trabajador] [nvarchar](200) NULL,
	[descripcion_Tipo_Trabajador] [nvarchar](500) NULL,
 CONSTRAINT [PK_T_TipoTrabajador] PRIMARY KEY CLUSTERED 
(
	[id_Tipo_Trabajdor] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_TipoUnidad]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TipoUnidad](
	[id_Tipo_Unidad] [int] IDENTITY(1,1) NOT NULL,
	[nombre_Tipo_Unidad] [nvarchar](200) NULL,
 CONSTRAINT [PK_T_TipoUnidad] PRIMARY KEY CLUSTERED 
(
	[id_Tipo_Unidad] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Trabajador]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Trabajador](
	[dni] [int] NOT NULL,
	[nombre] [nvarchar](200) NULL,
	[apellido] [nvarchar](200) NULL,
	[celular] [int] NULL,
	[id_Tipo_Trabajador] [int] NULL,
	[id_Estado_Trabajador] [int] NULL,
 CONSTRAINT [PK_T_Trabajador] PRIMARY KEY CLUSTERED 
(
	[dni] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_TrabajadorxCotizacion]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TrabajadorxCotizacion](
	[id_Cotizacion] [nvarchar](200) NOT NULL,
	[dni_Trabajador] [int] NOT NULL,
 CONSTRAINT [PK_T_TrabajadorxCotizacion] PRIMARY KEY CLUSTERED 
(
	[id_Cotizacion] ASC,
	[dni_Trabajador] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Unidad]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Unidad](
	[serie] [nvarchar](100) NOT NULL,
	[nombre] [nvarchar](100) NULL,
	[modelo] [nvarchar](100) NULL,
	[marca] [nvarchar](100) NULL,
	[precio] [decimal](18, 0) NULL,
	[cantidad] [int] NULL,
	[descripcion] [nvarchar](500) NULL,
	[caracteristica1] [nvarchar](500) NOT NULL,
	[caracteristica2] [nvarchar](500) NULL,
	[caracteristica3] [nvarchar](500) NULL,
	[id_Tipo_Unidad] [int] NULL,
	[id_Estado_Unidad] [int] NULL,
	[imagen] [varchar](max) NULL,
 CONSTRAINT [PK_T_Unidad] PRIMARY KEY CLUSTERED 
(
	[serie] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Usuario]    Script Date: 13/12/2021 17:00:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Usuario](
	[id_Usuario] [nvarchar](100) NOT NULL,
	[contraseña] [nvarchar](100) NULL,
	[dni_Usuario] [int] NULL,
	[id_Rol_Usuario] [int] NULL,
 CONSTRAINT [PK_T_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_Usuario] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[T_Cita] ([id_Cita], [fecha_Cita], [hora_Cita], [id_Obra_Cita], [lugar_Cita]) VALUES (N'Cita-001-Obra-001', CAST(N'2021-12-16T00:00:00.000' AS DateTime), N'3:00pm', N'Obra-001', N'Surco')
GO
INSERT [dbo].[T_Cliente] ([dni], [nombre], [apellido], [celular], [correo], [direccion]) VALUES (41435887, N'Claudia', N'Chuquipiondo', 994010421, N'claudiachuquipiondo@gmail.com', N'SJL')
INSERT [dbo].[T_Cliente] ([dni], [nombre], [apellido], [celular], [correo], [direccion]) VALUES (71296436, N'Gabriela ', N'Mujica', 947623697, N'gabrielachuquipiondom@gmail.com', N'Jr. Educacion 172 Mz C5 Lt 02 -urb Mariscal Caceres')
INSERT [dbo].[T_Cliente] ([dni], [nombre], [apellido], [celular], [correo], [direccion]) VALUES (71296437, N'Karen', N'Quispe', 947563287, N'karenquispe@gmail.com', N'Surco 123')
INSERT [dbo].[T_Cliente] ([dni], [nombre], [apellido], [celular], [correo], [direccion]) VALUES (72972740, N'Kevin ', N'Tumay', 921907738, N'kevintumay97@gmail.com', N'SJM')
GO
INSERT [dbo].[T_Cotizacion] ([id_Cotizacion], [fecha], [total], [id_Obra_Cotizacion], [id_Cotizacion_Estado]) VALUES (N'Cotizacion-001', CAST(N'2021-12-13T05:12:30.863' AS DateTime), CAST(234 AS Decimal(18, 0)), N'Obra-001', 7)
GO
INSERT [dbo].[T_CotizacionxUnidad] ([id_Serie], [id_Cotizacion], [cantidad]) VALUES (N'Mini-01', N'Cotizacion-001', 1)
GO
SET IDENTITY_INSERT [dbo].[T_EstadoCotizacion] ON 

INSERT [dbo].[T_EstadoCotizacion] ([id_Estado_Cotizacion], [nombre_Estado_Cotizacion], [descripcion_Estado_Cotizacion]) VALUES (1, N'en espera', N'cotizacion pendiente a aceptar por cliente')
INSERT [dbo].[T_EstadoCotizacion] ([id_Estado_Cotizacion], [nombre_Estado_Cotizacion], [descripcion_Estado_Cotizacion]) VALUES (2, N'aceptado', N'cotizacion aceptado por cliente')
INSERT [dbo].[T_EstadoCotizacion] ([id_Estado_Cotizacion], [nombre_Estado_Cotizacion], [descripcion_Estado_Cotizacion]) VALUES (3, N'rechazado', N'cotizacion rechazada')
INSERT [dbo].[T_EstadoCotizacion] ([id_Estado_Cotizacion], [nombre_Estado_Cotizacion], [descripcion_Estado_Cotizacion]) VALUES (4, N'facturado', N'primera facturacion')
INSERT [dbo].[T_EstadoCotizacion] ([id_Estado_Cotizacion], [nombre_Estado_Cotizacion], [descripcion_Estado_Cotizacion]) VALUES (5, N'pago', N'cotizacion pagado')
INSERT [dbo].[T_EstadoCotizacion] ([id_Estado_Cotizacion], [nombre_Estado_Cotizacion], [descripcion_Estado_Cotizacion]) VALUES (6, N'facturado', N'segunda facturacion')
INSERT [dbo].[T_EstadoCotizacion] ([id_Estado_Cotizacion], [nombre_Estado_Cotizacion], [descripcion_Estado_Cotizacion]) VALUES (7, N'finalizado', N'cotizacion finalizada')
INSERT [dbo].[T_EstadoCotizacion] ([id_Estado_Cotizacion], [nombre_Estado_Cotizacion], [descripcion_Estado_Cotizacion]) VALUES (8, N'herramienta asignada', N'cotizacion en asignacion de recursos')
INSERT [dbo].[T_EstadoCotizacion] ([id_Estado_Cotizacion], [nombre_Estado_Cotizacion], [descripcion_Estado_Cotizacion]) VALUES (9, N'trabajador asignado', N'cotizacion en asignacion de trabajador')
INSERT [dbo].[T_EstadoCotizacion] ([id_Estado_Cotizacion], [nombre_Estado_Cotizacion], [descripcion_Estado_Cotizacion]) VALUES (10, N'asignados', N'recursos asignados')
SET IDENTITY_INSERT [dbo].[T_EstadoCotizacion] OFF
GO
SET IDENTITY_INSERT [dbo].[T_EstadoObra] ON 

INSERT [dbo].[T_EstadoObra] ([id_EstadoObra], [nombre_Estado_Obra], [descripcion_Estado_Obra]) VALUES (1, N'pendiente', N'obra pendiente')
INSERT [dbo].[T_EstadoObra] ([id_EstadoObra], [nombre_Estado_Obra], [descripcion_Estado_Obra]) VALUES (2, N'aceptado', N'obra aceptada')
INSERT [dbo].[T_EstadoObra] ([id_EstadoObra], [nombre_Estado_Obra], [descripcion_Estado_Obra]) VALUES (3, N'observada', N'archivo no visualizado')
INSERT [dbo].[T_EstadoObra] ([id_EstadoObra], [nombre_Estado_Obra], [descripcion_Estado_Obra]) VALUES (4, N'citado', N'proceso de cita de la obra ')
INSERT [dbo].[T_EstadoObra] ([id_EstadoObra], [nombre_Estado_Obra], [descripcion_Estado_Obra]) VALUES (5, N'cotizado', N'obra cotizada')
INSERT [dbo].[T_EstadoObra] ([id_EstadoObra], [nombre_Estado_Obra], [descripcion_Estado_Obra]) VALUES (6, N'rechazado', N'obra rechazada')
INSERT [dbo].[T_EstadoObra] ([id_EstadoObra], [nombre_Estado_Obra], [descripcion_Estado_Obra]) VALUES (7, N'facturado', N'obra facturada')
INSERT [dbo].[T_EstadoObra] ([id_EstadoObra], [nombre_Estado_Obra], [descripcion_Estado_Obra]) VALUES (8, N'pago', N'obra en proceso de pago')
INSERT [dbo].[T_EstadoObra] ([id_EstadoObra], [nombre_Estado_Obra], [descripcion_Estado_Obra]) VALUES (9, N'proceso', N'obra en construccion')
INSERT [dbo].[T_EstadoObra] ([id_EstadoObra], [nombre_Estado_Obra], [descripcion_Estado_Obra]) VALUES (10, N'terminado', N'obra construccion terminada')
INSERT [dbo].[T_EstadoObra] ([id_EstadoObra], [nombre_Estado_Obra], [descripcion_Estado_Obra]) VALUES (11, N'finalizado', N'obra finalizada')
SET IDENTITY_INSERT [dbo].[T_EstadoObra] OFF
GO
SET IDENTITY_INSERT [dbo].[T_EstadoPedido] ON 

INSERT [dbo].[T_EstadoPedido] ([id_Estado_Pedido], [nombre_Estado_Pedido], [descripcion_Estado_Pedido]) VALUES (1, N'pendiente', N'pedido en estado de pendiente')
INSERT [dbo].[T_EstadoPedido] ([id_Estado_Pedido], [nombre_Estado_Pedido], [descripcion_Estado_Pedido]) VALUES (2, N'aceptado', N'pedido en estado aceptado')
INSERT [dbo].[T_EstadoPedido] ([id_Estado_Pedido], [nombre_Estado_Pedido], [descripcion_Estado_Pedido]) VALUES (3, N'enviado', N'pedido enviado')
INSERT [dbo].[T_EstadoPedido] ([id_Estado_Pedido], [nombre_Estado_Pedido], [descripcion_Estado_Pedido]) VALUES (4, N'terminado', N'pedido y alquiler acabo')
INSERT [dbo].[T_EstadoPedido] ([id_Estado_Pedido], [nombre_Estado_Pedido], [descripcion_Estado_Pedido]) VALUES (5, N'finalizado', N'todo el proceso terminado')
INSERT [dbo].[T_EstadoPedido] ([id_Estado_Pedido], [nombre_Estado_Pedido], [descripcion_Estado_Pedido]) VALUES (6, N'Rechazado', N'Pedido Rechazado')
SET IDENTITY_INSERT [dbo].[T_EstadoPedido] OFF
GO
SET IDENTITY_INSERT [dbo].[T_EstadoTrabajador] ON 

INSERT [dbo].[T_EstadoTrabajador] ([id_Estado_Trabajador], [nombre_Estado_Trabajador], [descripcionEstadoTrabajador]) VALUES (1, N'Disponible', N'Trabajador disponible')
INSERT [dbo].[T_EstadoTrabajador] ([id_Estado_Trabajador], [nombre_Estado_Trabajador], [descripcionEstadoTrabajador]) VALUES (2, N'No Disponible', N'Trabajador no disponible')
SET IDENTITY_INSERT [dbo].[T_EstadoTrabajador] OFF
GO
SET IDENTITY_INSERT [dbo].[T_EstadoUnidad] ON 

INSERT [dbo].[T_EstadoUnidad] ([id_Estado_Unidad], [nombre_Estado_Unidad], [descripcion_Estado_Unidad]) VALUES (1, N'Disponible', N'Disponibilidad absoluta de la unidad')
INSERT [dbo].[T_EstadoUnidad] ([id_Estado_Unidad], [nombre_Estado_Unidad], [descripcion_Estado_Unidad]) VALUES (2, N'No disponible', N'Unidad no Disponible')
INSERT [dbo].[T_EstadoUnidad] ([id_Estado_Unidad], [nombre_Estado_Unidad], [descripcion_Estado_Unidad]) VALUES (3, N'Mantenimiento', N'Unidad en mantenimiento')
SET IDENTITY_INSERT [dbo].[T_EstadoUnidad] OFF
GO
INSERT [dbo].[T_Factura] ([id_Factura], [imagen], [id_Cotizacion_Factura]) VALUES (N'Factura-001', N'a18c7e89-b76d-4c71-afb3-b3cff2a73d39E001-167 PROMOBRAS - VAL08 - NAPANGA.pdf', N'Cotizacion-001')
INSERT [dbo].[T_Factura] ([id_Factura], [imagen], [id_Cotizacion_Factura]) VALUES (N'Factura-002', N'a6469547-bf5a-4172-8b58-70c157c9467cE001-167 PROMOBRAS - VAL08 - NAPANGA.pdf', N'Cotizacion-001')
GO
INSERT [dbo].[T_Obra] ([id_Obra], [empresa], [direccion], [nombre_Obra], [imagen], [fecha_Inicio], [duracion_Obra], [id_Usuario_Obra], [id_Obra_Estado]) VALUES (N'Obra-001', N'PSY', N'San juan de Miraflores 123', N'Obra de EDificio 1', N'd67a1b93-2dfd-4131-9e8d-056c3a16c194plano.jpeg', CAST(N'2021-12-20T00:00:00.000' AS DateTime), 5, N'karenquispe@gmail.com', 11)
GO
INSERT [dbo].[T_ObraxPartida] ([id_Partida], [id_Obra], [metrado], [unidad], [parcial]) VALUES (N'1.002', N'Obra-001', CAST(2 AS Decimal(18, 0)), N'gbl', CAST(180 AS Decimal(18, 0)))
INSERT [dbo].[T_ObraxPartida] ([id_Partida], [id_Obra], [metrado], [unidad], [parcial]) VALUES (N'2.001', N'Obra-001', CAST(1 AS Decimal(18, 0)), N'gbl', CAST(54 AS Decimal(18, 0)))
GO
INSERT [dbo].[T_Pago] ([id_Pago], [fecha], [pago1], [pago2], [id_Cotizacion_Pago]) VALUES (N'Pago-001-Cotizacion-001', CAST(N'2021-12-13T05:57:20.000' AS DateTime), CAST(117 AS Decimal(18, 0)), CAST(117 AS Decimal(18, 0)), N'Cotizacion-001')
GO
INSERT [dbo].[T_Partida] ([id_Partida], [nombre_Partida], [precio_Unidad], [id_Tipo_Partida]) VALUES (N'1.002', N'Suministros e instalaciones de techos prefabricados', CAST(90 AS Decimal(18, 0)), 1)
INSERT [dbo].[T_Partida] ([id_Partida], [nombre_Partida], [precio_Unidad], [id_Tipo_Partida]) VALUES (N'1.01', N'Acarreo de herramientas y materiales', CAST(121 AS Decimal(18, 0)), 1)
INSERT [dbo].[T_Partida] ([id_Partida], [nombre_Partida], [precio_Unidad], [id_Tipo_Partida]) VALUES (N'1.03', N'Fabricacion e instalacion de molduras en ventanas ', CAST(45 AS Decimal(18, 0)), 1)
INSERT [dbo].[T_Partida] ([id_Partida], [nombre_Partida], [precio_Unidad], [id_Tipo_Partida]) VALUES (N'2.001', N'Encofrados y desencofrados para sobrecrecimiento', CAST(54 AS Decimal(18, 0)), 2)
GO
INSERT [dbo].[T_Pedido] ([id_Pedido], [fecha_Inicio], [cantidad_Dias], [obra], [empresa], [ubicacion], [fecha_Entrega], [precio_Pedido], [id_Estado_Pedido], [id_Usuario_Pedido], [id_Trabajador_Pedido], [id_Unidad_Pedido]) VALUES (N'Pedi-001', CAST(N'2021-12-20T00:00:00.000' AS DateTime), 15, N'EdiObra03', N'Edificar', N'Surco', NULL, CAST(18450 AS Decimal(18, 0)), 3, N'karenquispe@gmail.com', 75878474, N'Mini-01')
INSERT [dbo].[T_Pedido] ([id_Pedido], [fecha_Inicio], [cantidad_Dias], [obra], [empresa], [ubicacion], [fecha_Entrega], [precio_Pedido], [id_Estado_Pedido], [id_Usuario_Pedido], [id_Trabajador_Pedido], [id_Unidad_Pedido]) VALUES (N'Pedi-002', CAST(N'2021-12-27T00:00:00.000' AS DateTime), 5, N'EdiObra04', N'PSY', N'Surco', NULL, CAST(175 AS Decimal(18, 0)), 2, N'karenquispe@gmail.com', NULL, N'COMB-01')
GO
SET IDENTITY_INSERT [dbo].[T_Rol] ON 

INSERT [dbo].[T_Rol] ([id_Rol], [nombre_Rol], [descripcion_Rol]) VALUES (1, N'Administrador', N'Administrador del sistema')
INSERT [dbo].[T_Rol] ([id_Rol], [nombre_Rol], [descripcion_Rol]) VALUES (2, N'Cliente', N'Cliente del sistema')
INSERT [dbo].[T_Rol] ([id_Rol], [nombre_Rol], [descripcion_Rol]) VALUES (3, N'Gerente', N'Gerente del sistema')
INSERT [dbo].[T_Rol] ([id_Rol], [nombre_Rol], [descripcion_Rol]) VALUES (4, N'Operario', N'Operario del sistema')
SET IDENTITY_INSERT [dbo].[T_Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[T_TipoPartida] ON 

INSERT [dbo].[T_TipoPartida] ([id_Tipo_Partida], [nombre_Tipo_Partida], [descripcion_Tipo_Partida]) VALUES (1, N'Sistema Drywall', N'Suministro e instalacion de techo prefabricado con plancha de OSB 18 mm con parantes de acera galvanizado 3 5/8" reforzado en ingreso a recepcion')
INSERT [dbo].[T_TipoPartida] ([id_Tipo_Partida], [nombre_Tipo_Partida], [descripcion_Tipo_Partida]) VALUES (2, N'Encofrados', N'Para las losas')
SET IDENTITY_INSERT [dbo].[T_TipoPartida] OFF
GO
SET IDENTITY_INSERT [dbo].[T_TipoTrabajador] ON 

INSERT [dbo].[T_TipoTrabajador] ([id_Tipo_Trabajdor], [nombre_Tipo_Trabajador], [descripcion_Tipo_Trabajador]) VALUES (1, N'Capataz', N'Persona que dirige y vigila a trabajadores')
INSERT [dbo].[T_TipoTrabajador] ([id_Tipo_Trabajdor], [nombre_Tipo_Trabajador], [descripcion_Tipo_Trabajador]) VALUES (2, N'Ayudante', N'Persona de cargar y descargar materiales de construccion')
INSERT [dbo].[T_TipoTrabajador] ([id_Tipo_Trabajdor], [nombre_Tipo_Trabajador], [descripcion_Tipo_Trabajador]) VALUES (3, N'Operario', N'Persona de tipo manual o esfuerzo')
SET IDENTITY_INSERT [dbo].[T_TipoTrabajador] OFF
GO
SET IDENTITY_INSERT [dbo].[T_TipoUnidad] ON 

INSERT [dbo].[T_TipoUnidad] ([id_Tipo_Unidad], [nombre_Tipo_Unidad]) VALUES (1, N'Maquinaria')
INSERT [dbo].[T_TipoUnidad] ([id_Tipo_Unidad], [nombre_Tipo_Unidad]) VALUES (2, N'Herramienta')
SET IDENTITY_INSERT [dbo].[T_TipoUnidad] OFF
GO
INSERT [dbo].[T_Trabajador] ([dni], [nombre], [apellido], [celular], [id_Tipo_Trabajador], [id_Estado_Trabajador]) VALUES (71458541, N'Elcar', N'Litos', 921745873, 2, 2)
INSERT [dbo].[T_Trabajador] ([dni], [nombre], [apellido], [celular], [id_Tipo_Trabajador], [id_Estado_Trabajador]) VALUES (74847574, N'Eljua', N'Nito', 924785987, 3, 2)
INSERT [dbo].[T_Trabajador] ([dni], [nombre], [apellido], [celular], [id_Tipo_Trabajador], [id_Estado_Trabajador]) VALUES (75878474, N'Mario', N'Bros', 952958787, 3, 1)
GO
INSERT [dbo].[T_TrabajadorxCotizacion] ([id_Cotizacion], [dni_Trabajador]) VALUES (N'Cotizacion-001', 71458541)
INSERT [dbo].[T_TrabajadorxCotizacion] ([id_Cotizacion], [dni_Trabajador]) VALUES (N'Cotizacion-001', 74847574)
GO
INSERT [dbo].[T_Unidad] ([serie], [nombre], [modelo], [marca], [precio], [cantidad], [descripcion], [caracteristica1], [caracteristica2], [caracteristica3], [id_Tipo_Unidad], [id_Estado_Unidad], [imagen]) VALUES (N'COMB-01', N'Comba', N'160Z', N'Irimo', CAST(35 AS Decimal(18, 0)), 2, N'Comba nueva', N'Peso(Kg): 0.1', N'Dimensiones: 25 x 10 cm', N'Material: Acero forjado', 2, 1, N'77277a60-5650-48c3-87b1-2e23ed7a22c41128900.jpg')
INSERT [dbo].[T_Unidad] ([serie], [nombre], [modelo], [marca], [precio], [cantidad], [descripcion], [caracteristica1], [caracteristica2], [caracteristica3], [id_Tipo_Unidad], [id_Estado_Unidad], [imagen]) VALUES (N'MAR-01', N'Martillo', N'MA-20', N'Truper', CAST(28 AS Decimal(18, 0)), 3, N'Martillo Uña Curva', N'Cabeza: 20 Oz', N'Mango: 14" (36 cm)', N'Boca: 1-1/4"', 2, 1, N'ee9e232e-68c0-438c-9226-f888a88c9b9bD_NQ_NP_669430-MLU29470204421_022019-O.jpg')
INSERT [dbo].[T_Unidad] ([serie], [nombre], [modelo], [marca], [precio], [cantidad], [descripcion], [caracteristica1], [caracteristica2], [caracteristica3], [id_Tipo_Unidad], [id_Estado_Unidad], [imagen]) VALUES (N'Mini-01', N'Minicargador', N'216B3', N'Cat', CAST(1230 AS Decimal(18, 0)), 1, N'Minicargador nuevo', N'Peso en orden de trabajo: 2581 kg', N'Velocidad de desplazamiento (avance o retroceso): 12.7 km/h', N'Modelo de motor: Cat C2.2', 1, 1, N'efa444a0-c469-4d54-8d75-8278c6e470fcCM20190926-d30ea-dd374.jpg')
GO
INSERT [dbo].[T_Usuario] ([id_Usuario], [contraseña], [dni_Usuario], [id_Rol_Usuario]) VALUES (N'claudiachuquipiondo@gmail.com', N'41435887', 41435887, 3)
INSERT [dbo].[T_Usuario] ([id_Usuario], [contraseña], [dni_Usuario], [id_Rol_Usuario]) VALUES (N'gabrielachuquipiondom@gmail.com', N'71296436', 71296436, 1)
INSERT [dbo].[T_Usuario] ([id_Usuario], [contraseña], [dni_Usuario], [id_Rol_Usuario]) VALUES (N'karenquispe@gmail.com', N'71296437', 71296437, 2)
INSERT [dbo].[T_Usuario] ([id_Usuario], [contraseña], [dni_Usuario], [id_Rol_Usuario]) VALUES (N'kevintumay97@gmail.com', N'72972740', 72972740, 4)
GO
ALTER TABLE [dbo].[T_Cita]  WITH CHECK ADD  CONSTRAINT [FK_T_Cita_T_Obra] FOREIGN KEY([id_Obra_Cita])
REFERENCES [dbo].[T_Obra] ([id_Obra])
GO
ALTER TABLE [dbo].[T_Cita] CHECK CONSTRAINT [FK_T_Cita_T_Obra]
GO
ALTER TABLE [dbo].[T_Cotizacion]  WITH CHECK ADD  CONSTRAINT [FK_T_Cotizacion_T_EstadoCotizacion] FOREIGN KEY([id_Cotizacion_Estado])
REFERENCES [dbo].[T_EstadoCotizacion] ([id_Estado_Cotizacion])
GO
ALTER TABLE [dbo].[T_Cotizacion] CHECK CONSTRAINT [FK_T_Cotizacion_T_EstadoCotizacion]
GO
ALTER TABLE [dbo].[T_Cotizacion]  WITH CHECK ADD  CONSTRAINT [FK_T_Cotizacion_T_Obra] FOREIGN KEY([id_Obra_Cotizacion])
REFERENCES [dbo].[T_Obra] ([id_Obra])
GO
ALTER TABLE [dbo].[T_Cotizacion] CHECK CONSTRAINT [FK_T_Cotizacion_T_Obra]
GO
ALTER TABLE [dbo].[T_CotizacionxUnidad]  WITH CHECK ADD  CONSTRAINT [FK_T_CotizacionxUnidad_T_Cotizacion] FOREIGN KEY([id_Cotizacion])
REFERENCES [dbo].[T_Cotizacion] ([id_Cotizacion])
GO
ALTER TABLE [dbo].[T_CotizacionxUnidad] CHECK CONSTRAINT [FK_T_CotizacionxUnidad_T_Cotizacion]
GO
ALTER TABLE [dbo].[T_CotizacionxUnidad]  WITH CHECK ADD  CONSTRAINT [FK_T_CotizacionxUnidad_T_Unidad] FOREIGN KEY([id_Serie])
REFERENCES [dbo].[T_Unidad] ([serie])
GO
ALTER TABLE [dbo].[T_CotizacionxUnidad] CHECK CONSTRAINT [FK_T_CotizacionxUnidad_T_Unidad]
GO
ALTER TABLE [dbo].[T_Factura]  WITH CHECK ADD  CONSTRAINT [FK_T_Factura_T_Cotizacion] FOREIGN KEY([id_Cotizacion_Factura])
REFERENCES [dbo].[T_Cotizacion] ([id_Cotizacion])
GO
ALTER TABLE [dbo].[T_Factura] CHECK CONSTRAINT [FK_T_Factura_T_Cotizacion]
GO
ALTER TABLE [dbo].[T_Incidencia]  WITH CHECK ADD  CONSTRAINT [FK_T_Incidencia_T_Pedido] FOREIGN KEY([id_Pedido_Incidencia])
REFERENCES [dbo].[T_Pedido] ([id_Pedido])
GO
ALTER TABLE [dbo].[T_Incidencia] CHECK CONSTRAINT [FK_T_Incidencia_T_Pedido]
GO
ALTER TABLE [dbo].[T_Obra]  WITH CHECK ADD  CONSTRAINT [FK_T_Obra_T_EstadoObra] FOREIGN KEY([id_Obra_Estado])
REFERENCES [dbo].[T_EstadoObra] ([id_EstadoObra])
GO
ALTER TABLE [dbo].[T_Obra] CHECK CONSTRAINT [FK_T_Obra_T_EstadoObra]
GO
ALTER TABLE [dbo].[T_Obra]  WITH CHECK ADD  CONSTRAINT [FK_T_Obra_T_Usuario] FOREIGN KEY([id_Usuario_Obra])
REFERENCES [dbo].[T_Usuario] ([id_Usuario])
GO
ALTER TABLE [dbo].[T_Obra] CHECK CONSTRAINT [FK_T_Obra_T_Usuario]
GO
ALTER TABLE [dbo].[T_ObraxPartida]  WITH CHECK ADD  CONSTRAINT [FK_T_ObraxPartida_T_Obra] FOREIGN KEY([id_Obra])
REFERENCES [dbo].[T_Obra] ([id_Obra])
GO
ALTER TABLE [dbo].[T_ObraxPartida] CHECK CONSTRAINT [FK_T_ObraxPartida_T_Obra]
GO
ALTER TABLE [dbo].[T_ObraxPartida]  WITH CHECK ADD  CONSTRAINT [FK_T_ObraxPartida_T_Partida] FOREIGN KEY([id_Partida])
REFERENCES [dbo].[T_Partida] ([id_Partida])
GO
ALTER TABLE [dbo].[T_ObraxPartida] CHECK CONSTRAINT [FK_T_ObraxPartida_T_Partida]
GO
ALTER TABLE [dbo].[T_OrdenServicio]  WITH CHECK ADD  CONSTRAINT [FK_T_OrdenServicio_T_Pedido] FOREIGN KEY([id_Pedido_Orden])
REFERENCES [dbo].[T_Pedido] ([id_Pedido])
GO
ALTER TABLE [dbo].[T_OrdenServicio] CHECK CONSTRAINT [FK_T_OrdenServicio_T_Pedido]
GO
ALTER TABLE [dbo].[T_Pago]  WITH CHECK ADD  CONSTRAINT [FK_T_Pago_T_Cotizacion] FOREIGN KEY([id_Cotizacion_Pago])
REFERENCES [dbo].[T_Cotizacion] ([id_Cotizacion])
GO
ALTER TABLE [dbo].[T_Pago] CHECK CONSTRAINT [FK_T_Pago_T_Cotizacion]
GO
ALTER TABLE [dbo].[T_Partida]  WITH CHECK ADD  CONSTRAINT [FK_T_Partida_T_TipoPartida] FOREIGN KEY([id_Tipo_Partida])
REFERENCES [dbo].[T_TipoPartida] ([id_Tipo_Partida])
GO
ALTER TABLE [dbo].[T_Partida] CHECK CONSTRAINT [FK_T_Partida_T_TipoPartida]
GO
ALTER TABLE [dbo].[T_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_T_Pedido_T_EstadoPedido] FOREIGN KEY([id_Estado_Pedido])
REFERENCES [dbo].[T_EstadoPedido] ([id_Estado_Pedido])
GO
ALTER TABLE [dbo].[T_Pedido] CHECK CONSTRAINT [FK_T_Pedido_T_EstadoPedido]
GO
ALTER TABLE [dbo].[T_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_T_Pedido_T_Trabajador] FOREIGN KEY([id_Trabajador_Pedido])
REFERENCES [dbo].[T_Trabajador] ([dni])
GO
ALTER TABLE [dbo].[T_Pedido] CHECK CONSTRAINT [FK_T_Pedido_T_Trabajador]
GO
ALTER TABLE [dbo].[T_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_T_Pedido_T_Unidad] FOREIGN KEY([id_Unidad_Pedido])
REFERENCES [dbo].[T_Unidad] ([serie])
GO
ALTER TABLE [dbo].[T_Pedido] CHECK CONSTRAINT [FK_T_Pedido_T_Unidad]
GO
ALTER TABLE [dbo].[T_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_T_Pedido_T_Usuario1] FOREIGN KEY([id_Usuario_Pedido])
REFERENCES [dbo].[T_Usuario] ([id_Usuario])
GO
ALTER TABLE [dbo].[T_Pedido] CHECK CONSTRAINT [FK_T_Pedido_T_Usuario1]
GO
ALTER TABLE [dbo].[T_Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_T_Trabajador_T_EstadoTrabajador] FOREIGN KEY([id_Estado_Trabajador])
REFERENCES [dbo].[T_EstadoTrabajador] ([id_Estado_Trabajador])
GO
ALTER TABLE [dbo].[T_Trabajador] CHECK CONSTRAINT [FK_T_Trabajador_T_EstadoTrabajador]
GO
ALTER TABLE [dbo].[T_Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_T_Trabajador_T_TipoTrabajador] FOREIGN KEY([id_Tipo_Trabajador])
REFERENCES [dbo].[T_TipoTrabajador] ([id_Tipo_Trabajdor])
GO
ALTER TABLE [dbo].[T_Trabajador] CHECK CONSTRAINT [FK_T_Trabajador_T_TipoTrabajador]
GO
ALTER TABLE [dbo].[T_TrabajadorxCotizacion]  WITH CHECK ADD  CONSTRAINT [FK_T_TrabajadorxCotizacion_T_Cotizacion] FOREIGN KEY([id_Cotizacion])
REFERENCES [dbo].[T_Cotizacion] ([id_Cotizacion])
GO
ALTER TABLE [dbo].[T_TrabajadorxCotizacion] CHECK CONSTRAINT [FK_T_TrabajadorxCotizacion_T_Cotizacion]
GO
ALTER TABLE [dbo].[T_TrabajadorxCotizacion]  WITH CHECK ADD  CONSTRAINT [FK_T_TrabajadorxCotizacion_T_Trabajador] FOREIGN KEY([dni_Trabajador])
REFERENCES [dbo].[T_Trabajador] ([dni])
GO
ALTER TABLE [dbo].[T_TrabajadorxCotizacion] CHECK CONSTRAINT [FK_T_TrabajadorxCotizacion_T_Trabajador]
GO
ALTER TABLE [dbo].[T_Unidad]  WITH CHECK ADD  CONSTRAINT [FK_T_Unidad_T_EstadoUnidad] FOREIGN KEY([id_Estado_Unidad])
REFERENCES [dbo].[T_EstadoUnidad] ([id_Estado_Unidad])
GO
ALTER TABLE [dbo].[T_Unidad] CHECK CONSTRAINT [FK_T_Unidad_T_EstadoUnidad]
GO
ALTER TABLE [dbo].[T_Unidad]  WITH CHECK ADD  CONSTRAINT [FK_T_Unidad_T_TipoUnidad] FOREIGN KEY([id_Tipo_Unidad])
REFERENCES [dbo].[T_TipoUnidad] ([id_Tipo_Unidad])
GO
ALTER TABLE [dbo].[T_Unidad] CHECK CONSTRAINT [FK_T_Unidad_T_TipoUnidad]
GO
ALTER TABLE [dbo].[T_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_T_Usuario_T_Cliente] FOREIGN KEY([dni_Usuario])
REFERENCES [dbo].[T_Cliente] ([dni])
GO
ALTER TABLE [dbo].[T_Usuario] CHECK CONSTRAINT [FK_T_Usuario_T_Cliente]
GO
ALTER TABLE [dbo].[T_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_T_Usuario_T_Rol] FOREIGN KEY([id_Rol_Usuario])
REFERENCES [dbo].[T_Rol] ([id_Rol])
GO
ALTER TABLE [dbo].[T_Usuario] CHECK CONSTRAINT [FK_T_Usuario_T_Rol]
GO
/****** Object:  Trigger [dbo].[trg_Cita_Pendiente]    Script Date: 13/12/2021 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create trigger [dbo].[trg_Cita_Pendiente]
on [dbo].[T_Cita]
after insert
as
BEGIN
    set nocount on;
    declare
    @idObra nvarchar(50)
 

    select @idObra = id_Obra_Cita
    from inserted

    declare
    @obraid nvarchar(50)
   

    set @obraid=@idObra

    begin

       update T_Obra set id_Obra_Estado=4  where id_Obra = @obraid;
	end
	end
GO
ALTER TABLE [dbo].[T_Cita] ENABLE TRIGGER [trg_Cita_Pendiente]
GO
/****** Object:  Trigger [dbo].[trg_Usuario_Create]    Script Date: 13/12/2021 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[trg_Usuario_Create]
on [dbo].[T_Cliente]
after insert
as
BEGIN
    set nocount on;
    declare
	@dni int,
    @correo nvarchar(100)
	
	

    select @correo = correo,@dni = dni
    from inserted

    declare
    @usuario nvarchar(100),
    @contraseña  nvarchar(100)

    set @usuario=@correo
    set @contraseña = @dni

    begin
        insert into T_Usuario values(@usuario,@contraseña,@contraseña,2 )
    end
END
GO
ALTER TABLE [dbo].[T_Cliente] ENABLE TRIGGER [trg_Usuario_Create]
GO
/****** Object:  Trigger [dbo].[trg_Obra_Cotizado]    Script Date: 13/12/2021 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create trigger [dbo].[trg_Obra_Cotizado]
on [dbo].[T_Cotizacion]
after insert
as
BEGIN
    set nocount on;
    declare
    @idObra nvarchar(50)
 

    select @idObra = id_Obra_Cotizacion
    from inserted

    declare
    @obraid nvarchar(50)
   

    set @obraid=@idObra

    begin

       update T_Obra set id_Obra_Estado=5  where id_Obra = @obraid;
	end
	end
GO
ALTER TABLE [dbo].[T_Cotizacion] ENABLE TRIGGER [trg_Obra_Cotizado]
GO
/****** Object:  Trigger [dbo].[trg_Obra_Facturado]    Script Date: 13/12/2021 17:00:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create trigger [dbo].[trg_Obra_Facturado]
on [dbo].[T_Cotizacion]
for update
as
   set nocount on;
    declare
    @idCotizacion nvarchar(200),
	@estado int
 

    select @idCotizacion = (select o.id_Obra_Cotizacion from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion), @estado=(select o.id_Cotizacion_Estado from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion)
    from inserted

    declare
    @cotizacionid nvarchar(50),
	@estadoi int
   

    set @cotizacionid=@idCotizacion
	set @estadoi=@estado

    begin
		if @estadoi =4
	    update T_Obra set id_Obra_Estado=7  where id_Obra = @cotizacionid;
	end
	
GO
ALTER TABLE [dbo].[T_Cotizacion] ENABLE TRIGGER [trg_Obra_Facturado]
GO
/****** Object:  Trigger [dbo].[trg_Obra_Finalizada]    Script Date: 13/12/2021 17:00:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create trigger [dbo].[trg_Obra_Finalizada]
on [dbo].[T_Cotizacion]
for update
as
   set nocount on;
    declare
    @idCotizacion nvarchar(200),
	@estado int
 

    select @idCotizacion = (select o.id_Obra_Cotizacion from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion), @estado=(select o.id_Cotizacion_Estado from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion)
    from inserted

    declare
    @cotizacionid nvarchar(50),
	@estadoi int
   

    set @cotizacionid=@idCotizacion
	set @estadoi=@estado

    begin
		if @estadoi =7
	    update T_Obra set id_Obra_Estado=11  where id_Obra = @cotizacionid;
	end
GO
ALTER TABLE [dbo].[T_Cotizacion] ENABLE TRIGGER [trg_Obra_Finalizada]
GO
/****** Object:  Trigger [dbo].[trg_Obra_Pagado]    Script Date: 13/12/2021 17:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create trigger [dbo].[trg_Obra_Pagado]
on [dbo].[T_Cotizacion]
for update
as
   set nocount on;
    declare
    @idCotizacion nvarchar(200),
	@estado int
 

    select @idCotizacion = (select o.id_Obra_Cotizacion from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion), @estado=(select o.id_Cotizacion_Estado from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion)
    from inserted

    declare
    @cotizacionid nvarchar(50),
	@estadoi int
   

    set @cotizacionid=@idCotizacion
	set @estadoi=@estado

    begin
		if @estadoi =5
	    update T_Obra set id_Obra_Estado=8  where id_Obra = @cotizacionid;
	end
GO
ALTER TABLE [dbo].[T_Cotizacion] ENABLE TRIGGER [trg_Obra_Pagado]
GO
/****** Object:  Trigger [dbo].[trg_Obra_Proceso]    Script Date: 13/12/2021 17:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create trigger [dbo].[trg_Obra_Proceso]
on [dbo].[T_Cotizacion]
for update
as
   set nocount on;
    declare
    @idCotizacion nvarchar(200),
	@estado int
 

    select @idCotizacion = (select o.id_Obra_Cotizacion from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion), @estado=(select o.id_Cotizacion_Estado from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion)
    from inserted

    declare
    @cotizacionid nvarchar(50),
	@estadoi int
   

    set @cotizacionid=@idCotizacion
	set @estadoi=@estado

    begin
		if @estadoi =10
	    update T_Obra set id_Obra_Estado=9  where id_Obra = @cotizacionid;
	end
	
GO
ALTER TABLE [dbo].[T_Cotizacion] ENABLE TRIGGER [trg_Obra_Proceso]
GO
/****** Object:  Trigger [dbo].[trg_asignar_herramienta]    Script Date: 13/12/2021 17:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create trigger [dbo].[trg_asignar_herramienta]
on [dbo].[T_CotizacionxUnidad]
after insert
as
   set nocount on;
    declare
    @idCotizacion nvarchar(200),
	@idserie nvarchar(100),
	@cantidad int
 

    select @idCotizacion = id_Cotizacion,@idserie=id_Serie,@cantidad=cantidad
    from inserted

    declare
    @cotizacionid nvarchar(50),
	@serieid  nvarchar(100),
	@cant int,
	@i int,
	@i2 int
   

    set @cotizacionid=@idCotizacion
	set @serieid=@idserie
	set @cant= @cantidad

    begin
		set @i= (select cantidad from T_Unidad where serie=@serieid);
	    update T_Cotizacion set id_Cotizacion_Estado=8  where id_Cotizacion = @cotizacionid;
		update T_Cotizacion set id_Cotizacion_Estado=10  where id_Cotizacion = @cotizacionid;
		update T_Unidad set cantidad=@i-@cant where serie=@serieid;

		set @i2= (select cantidad from T_Unidad where serie=@serieid);
		
		if @i2 =0
		update T_Unidad set id_Estado_Unidad=2 where serie=@serieid;

	end
	
GO
ALTER TABLE [dbo].[T_CotizacionxUnidad] ENABLE TRIGGER [trg_asignar_herramienta]
GO
/****** Object:  Trigger [dbo].[trg_Cotizacion_Facturado]    Script Date: 13/12/2021 17:00:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create trigger [dbo].[trg_Cotizacion_Facturado]
on [dbo].[T_Factura]
after insert
as
BEGIN
    set nocount on;
    declare
    @idCotizacion nvarchar(200),
	@idFactura nvarchar(200)
 

    select @idCotizacion = id_Cotizacion_Factura
    from inserted

    declare
    @cotizacionid nvarchar(200),
	 @facturaid nvarchar(200),
	@i int
   

    set @cotizacionid=@idCotizacion
	set @facturaid=@idFactura

    begin
		set @i= (select count(*) from T_Factura where id_Cotizacion_Factura  =@idCotizacion);

		if @i=1
       update T_Cotizacion set id_Cotizacion_Estado=4  where id_Cotizacion = @cotizacionid;

	   if @i=2
       update T_Cotizacion set id_Cotizacion_Estado=6  where id_Cotizacion = @cotizacionid;
	end
	end

GO
ALTER TABLE [dbo].[T_Factura] ENABLE TRIGGER [trg_Cotizacion_Facturado]
GO
/****** Object:  Trigger [dbo].[trg_Obra_Aceptado]    Script Date: 13/12/2021 17:00:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create trigger [dbo].[trg_Obra_Aceptado]
on [dbo].[T_Obra]
for update
as
   set nocount on;
    declare
    @idObra nvarchar(50),
	@estado int
 

    select @idObra = (select o.id_Obra from T_Obra as o inner join inserted as s on o.id_Obra=s.id_Obra), @estado=(select o.id_Obra_Estado from T_Obra as o inner join inserted as s on o.id_Obra=s.id_Obra)
    from inserted

    declare
    @obraid nvarchar(50),
	@estadoi int
   

    set @obraid=@idObra
	set @estadoi=@estado

    begin
		if @estadoi =2
	    update T_Cotizacion set id_Cotizacion_Estado=2  where id_Obra_Cotizacion = @obraid;
	end
	
GO
ALTER TABLE [dbo].[T_Obra] ENABLE TRIGGER [trg_Obra_Aceptado]
GO
/****** Object:  Trigger [dbo].[trg_Obra_Rechazada]    Script Date: 13/12/2021 17:00:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create trigger [dbo].[trg_Obra_Rechazada]
on [dbo].[T_Obra]
for update
as
   set nocount on;
    declare
    @idObra nvarchar(50),
	@estado int
 

    select @idObra = (select o.id_Obra from T_Obra as o inner join inserted as s on o.id_Obra=s.id_Obra), @estado=(select o.id_Obra_Estado from T_Obra as o inner join inserted as s on o.id_Obra=s.id_Obra)
    from inserted

    declare
    @obraid nvarchar(50),
	@estadoi int
   

    set @obraid=@idObra
	set @estadoi=@estado

    begin
		if @estadoi =6
	    update T_Cotizacion set id_Cotizacion_Estado=3  where id_Obra_Cotizacion = @obraid;
	end
	
GO
ALTER TABLE [dbo].[T_Obra] ENABLE TRIGGER [trg_Obra_Rechazada]
GO
/****** Object:  Trigger [dbo].[trg_Cotizacion_Pagado]    Script Date: 13/12/2021 17:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create trigger [dbo].[trg_Cotizacion_Pagado]
on [dbo].[T_Pago]
after insert
as
BEGIN
    set nocount on;
    declare
    @idCotizacion nvarchar(200)
 

    select @idCotizacion = id_Cotizacion_Pago
    from inserted

    declare
    @cotizacionid nvarchar(200)
   

    set @cotizacionid=@idCotizacion

    begin

       update T_Cotizacion set id_Cotizacion_Estado=5  where id_Cotizacion = @cotizacionid;
	end
	end
GO
ALTER TABLE [dbo].[T_Pago] ENABLE TRIGGER [trg_Cotizacion_Pagado]
GO
/****** Object:  Trigger [dbo].[trg_Pago_2]    Script Date: 13/12/2021 17:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create trigger [dbo].[trg_Pago_2]
on [dbo].[T_Pago]
for update
as
   set nocount on;
    declare
    @idCotizacion nvarchar(200),
	@pago2 decimal(18,0)
 
    select @idCotizacion = (select o.id_Cotizacion from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion_Pago), @pago2=(select o.pago2 from T_Pago as o inner join inserted as s on o.id_Pago=s.id_Pago)
    from inserted

    declare
    @cotizacionid nvarchar(50),
	@2pago decimal(18,0)
   

    set @cotizacionid=@idCotizacion
	set @2pago=@pago2

    begin
		if @pago2 > 0
	    update T_Cotizacion set id_Cotizacion_Estado=7  where id_Cotizacion = @cotizacionid;
	end
GO
ALTER TABLE [dbo].[T_Pago] ENABLE TRIGGER [trg_Pago_2]
GO
/****** Object:  Trigger [dbo].[trg_asignar_trabajador]    Script Date: 13/12/2021 17:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create trigger [dbo].[trg_asignar_trabajador]
on [dbo].[T_TrabajadorxCotizacion]
after insert
as
   set nocount on;
    declare
    @idCotizacion nvarchar(200),
	@idtrabajador int
 

    select @idCotizacion = id_Cotizacion,@idtrabajador=dni_Trabajador
    from inserted

    declare
    @cotizacionid nvarchar(50),
	@trabajadorid int
   

    set @cotizacionid=@idCotizacion
	set @trabajadorid=@idtrabajador

    begin
	    update T_Cotizacion set id_Cotizacion_Estado=9  where id_Cotizacion = @cotizacionid;
		update T_Trabajador set id_Estado_Trabajador=2 where dni=@trabajadorid

	end
GO
ALTER TABLE [dbo].[T_TrabajadorxCotizacion] ENABLE TRIGGER [trg_asignar_trabajador]
GO
