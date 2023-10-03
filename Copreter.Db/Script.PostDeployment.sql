/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


USE [DB-Copreter]
GO


INSERT INTO [dbo].[T_Rol] ([Nombre] ,[Descripcion]) VALUES('Administrador','Administrador del sistema')
INSERT INTO [dbo].[T_Rol] ([Nombre] ,[Descripcion]) VALUES('Cliente','Cliente del sistema')
INSERT INTO [dbo].[T_Rol] ([Nombre] ,[Descripcion]) VALUES('Gerente','Gerente del sistema')
INSERT INTO [dbo].[T_Rol] ([Nombre] ,[Descripcion]) VALUES('Operario','Operario del sistema')
INSERT INTO [dbo].[T_Rol] ([Nombre] ,[Descripcion]) VALUES('Sin Asignar','Pendiente de asignar Rol')
GO

INSERT INTO [dbo].[T_Usuario]  ([Dni]  ,[Nombre] ,[Apellido] ,[Celular] ,[Email], [Direccion])  VALUES(41435887,'Claudia',	'Chuquipiondo',	994010421, 'claudiachuquipiondo@gmail.com',	'SJL')
INSERT INTO [dbo].[T_Usuario]  ([Dni]  ,[Nombre] ,[Apellido] ,[Celular] ,[Email], [Direccion])  VALUES(71296436,'Gabriela', 'Mujica',		947623697, 'gabrielachuquipiondom@gmail.com',	'Jr. Educacion 172 Mz C5 Lt 02 -urb Mariscal Caceres')
INSERT INTO [dbo].[T_Usuario]  ([Dni]  ,[Nombre] ,[Apellido] ,[Celular] ,[Email], [Direccion])  VALUES(71296437,'Karen',	'Quispe',		947563287, 'karenquispe@gmail.com',	'Surco 123')
INSERT INTO [dbo].[T_Usuario]  ([Dni]  ,[Nombre] ,[Apellido] ,[Celular] ,[Email], [Direccion])  VALUES(72972740,'Kevin', 	'Tumay',		921907738, 'kevintumay97@gmail.com',	'SJM')

GO

INSERT INTO [dbo].[T_Acceso] ([Email]  ,[Contrasenya]  ,[Id_Usuario] ,[Id_Rol]) VALUES ('claudiachuquipiondo@gmail.com'	,41435887,	1,	1)
INSERT INTO [dbo].[T_Acceso] ([Email]  ,[Contrasenya]  ,[Id_Usuario] ,[Id_Rol]) VALUES ('gabrielachuquipiondom@gmail.com'	,71296436,	2,	2)
INSERT INTO [dbo].[T_Acceso] ([Email]  ,[Contrasenya]  ,[Id_Usuario] ,[Id_Rol]) VALUES ('karenquispe@gmail.com'			,71296437,	3,	3)
INSERT INTO [dbo].[T_Acceso] ([Email]  ,[Contrasenya]  ,[Id_Usuario] ,[Id_Rol]) VALUES ('kevintumay97@gmail.com'			,72972740,	4,	4)


GO

SET IDENTITY_INSERT [dbo].[T_EstadoCotizacion] ON 

INSERT [dbo].[T_EstadoCotizacion] ([ID], [Nombre], [Descripcion]) VALUES (1, N'en espera', N'cotizacion pendiente a aceptar por cliente')
INSERT [dbo].[T_EstadoCotizacion] ([ID], [Nombre], [Descripcion]) VALUES (2, N'aceptado', N'cotizacion aceptado por cliente')
INSERT [dbo].[T_EstadoCotizacion] ([ID], [Nombre], [Descripcion]) VALUES (3, N'rechazado', N'cotizacion rechazada')
INSERT [dbo].[T_EstadoCotizacion] ([ID], [Nombre], [Descripcion]) VALUES (4, N'facturado', N'primera facturacion')
INSERT [dbo].[T_EstadoCotizacion] ([ID], [Nombre], [Descripcion]) VALUES (5, N'pago', N'cotizacion pagado')
INSERT [dbo].[T_EstadoCotizacion] ([ID], [Nombre], [Descripcion]) VALUES (6, N'facturado', N'segunda facturacion')
INSERT [dbo].[T_EstadoCotizacion] ([ID], [Nombre], [Descripcion]) VALUES (7, N'finalizado', N'cotizacion finalizada')
INSERT [dbo].[T_EstadoCotizacion] ([ID], [Nombre], [Descripcion]) VALUES (8, N'herramienta asignada', N'cotizacion en asignacion de recursos')
INSERT [dbo].[T_EstadoCotizacion] ([ID], [Nombre], [Descripcion]) VALUES (9, N'trabajador asignado', N'cotizacion en asignacion de trabajador')
INSERT [dbo].[T_EstadoCotizacion] ([ID], [Nombre], [Descripcion]) VALUES (10, N'asignados', N'recursos asignados')
SET IDENTITY_INSERT [dbo].[T_EstadoCotizacion] OFF
GO
SET IDENTITY_INSERT [dbo].[T_EstadoObra] ON 

INSERT [dbo].[T_EstadoObra] ([Id], [Nombre], [Descripcion]) VALUES (1, N'pendiente', N'obra pendiente')
INSERT [dbo].[T_EstadoObra] ([Id], [Nombre], [Descripcion]) VALUES (2, N'aceptado', N'obra aceptada')
INSERT [dbo].[T_EstadoObra] ([Id], [Nombre], [Descripcion]) VALUES (3, N'observada', N'archivo no visualizado')
INSERT [dbo].[T_EstadoObra] ([Id], [Nombre], [Descripcion]) VALUES (4, N'citado', N'proceso de cita de la obra ')
INSERT [dbo].[T_EstadoObra] ([Id], [Nombre], [Descripcion]) VALUES (5, N'cotizado', N'obra cotizada')
INSERT [dbo].[T_EstadoObra] ([Id], [Nombre], [Descripcion]) VALUES (6, N'rechazado', N'obra rechazada')
INSERT [dbo].[T_EstadoObra] ([Id], [Nombre], [Descripcion]) VALUES (7, N'facturado', N'obra facturada')
INSERT [dbo].[T_EstadoObra] ([Id], [Nombre], [Descripcion]) VALUES (8, N'pago', N'obra en proceso de pago')
INSERT [dbo].[T_EstadoObra] ([Id], [Nombre], [Descripcion]) VALUES (9, N'proceso', N'obra en construccion')
INSERT [dbo].[T_EstadoObra] ([Id], [Nombre], [Descripcion]) VALUES (10, N'terminado', N'obra construccion terminada')
INSERT [dbo].[T_EstadoObra] ([Id], [Nombre], [Descripcion]) VALUES (11, N'finalizado', N'obra finalizada')
SET IDENTITY_INSERT [dbo].[T_EstadoObra] OFF
GO
SET IDENTITY_INSERT [dbo].[T_EstadoPedido] ON 

INSERT [dbo].[T_EstadoPedido] ([Id], [Nombre], [Descripcion]) VALUES (1, N'pendiente', N'pedido en estado de pendiente')
INSERT [dbo].[T_EstadoPedido] ([Id], [Nombre], [Descripcion]) VALUES (2, N'aceptado', N'pedido en estado aceptado')
INSERT [dbo].[T_EstadoPedido] ([Id], [Nombre], [Descripcion]) VALUES (3, N'enviado', N'pedido enviado')
INSERT [dbo].[T_EstadoPedido] ([Id], [Nombre], [Descripcion]) VALUES (4, N'terminado', N'pedido y alquiler acabo')
INSERT [dbo].[T_EstadoPedido] ([Id], [Nombre], [Descripcion]) VALUES (5, N'finalizado', N'todo el proceso terminado')
INSERT [dbo].[T_EstadoPedido] ([Id], [Nombre], [Descripcion]) VALUES (6, N'Rechazado', N'Pedido Rechazado')
INSERT [dbo].[T_EstadoPedido] ([Id], [Nombre], [Descripcion]) VALUES (7, N'Pendiente Devolucion', N'Pedido pendiente de devolver')
INSERT [dbo].[T_EstadoPedido] ([Id], [Nombre], [Descripcion]) VALUES (8, N'Devuelto', N'Pedido devuelto')
SET IDENTITY_INSERT [dbo].[T_EstadoPedido] OFF
GO
SET IDENTITY_INSERT [dbo].[T_EstadoTrabajador] ON 

INSERT [dbo].[T_EstadoTrabajador] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Disponible', N'Trabajador disponible')
INSERT [dbo].[T_EstadoTrabajador] ([Id], [Nombre], [Descripcion]) VALUES (2, N'No Disponible', N'Trabajador no disponible')
SET IDENTITY_INSERT [dbo].[T_EstadoTrabajador] OFF
GO
SET IDENTITY_INSERT [dbo].[T_EstadoUnidad] ON 

INSERT [dbo].[T_EstadoUnidad] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Disponible', N'Disponibilidad absoluta de la unidad')
INSERT [dbo].[T_EstadoUnidad] ([Id], [Nombre], [Descripcion]) VALUES (2, N'No disponible', N'Unidad no Disponible')
INSERT [dbo].[T_EstadoUnidad] ([Id], [Nombre], [Descripcion]) VALUES (3, N'Mantenimiento', N'Unidad en mantenimiento')
SET IDENTITY_INSERT [dbo].[T_EstadoUnidad] OFF

GO
SET IDENTITY_INSERT [dbo].[T_TipoPartida] ON 

INSERT [dbo].[T_TipoPartida] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Sistema Drywall', N'Suministro e instalacion de techo prefabricado con plancha de OSB 18 mm con parantes de acera galvanizado 3 5/8" reforzado en ingreso a recepcion')
INSERT [dbo].[T_TipoPartida] ([Id], [Nombre], [Descripcion]) VALUES (2, N'Encofrados', N'Para las losas')
SET IDENTITY_INSERT [dbo].[T_TipoPartida] OFF
GO
SET IDENTITY_INSERT [dbo].[T_TipoTrabajador] ON 

INSERT [dbo].[T_TipoTrabajador] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Capataz', N'Persona que dirige y vigila a trabajadores')
INSERT [dbo].[T_TipoTrabajador] ([Id], [Nombre], [Descripcion]) VALUES (2, N'Ayudante', N'Persona de cargar y descargar materiales de construccion')
INSERT [dbo].[T_TipoTrabajador] ([Id], [Nombre], [Descripcion]) VALUES (3, N'Operario', N'Persona de tipo manual o esfuerzo')
SET IDENTITY_INSERT [dbo].[T_TipoTrabajador] OFF
GO
SET IDENTITY_INSERT [dbo].[T_TipoUnidad] ON 

INSERT [dbo].[T_TipoUnidad] ([Id], [Nombre]) VALUES (1, N'Maquinaria')
INSERT [dbo].[T_TipoUnidad] ([Id], [Nombre]) VALUES (2, N'Herramienta')
SET IDENTITY_INSERT [dbo].[T_TipoUnidad] OFF
GO

INSERT [dbo].[T_Trabajador] ([dni], [nombre], [apellido], [celular], [id_Tipo_Trabajador], [id_Estado_Trabajador]) VALUES (44700264, N'Daniel', N'Lopez', 924554873, 1,1)
INSERT [dbo].[T_Trabajador] ([dni], [nombre], [apellido], [celular], [id_Tipo_Trabajador], [id_Estado_Trabajador]) VALUES (44575075, N'Juan', N'Arteaga', 924566873, 1,1)
INSERT [dbo].[T_Trabajador] ([dni], [nombre], [apellido], [celular], [id_Tipo_Trabajador], [id_Estado_Trabajador]) VALUES (44057504, N'Luis', N'Alayo', 921745873, 2,1)
INSERT [dbo].[T_Trabajador] ([dni], [nombre], [apellido], [celular], [id_Tipo_Trabajador], [id_Estado_Trabajador]) VALUES (71458541, N'Elcar', N'Litos', 921745873, 2,1)
INSERT [dbo].[T_Trabajador] ([dni], [nombre], [apellido], [celular], [id_Tipo_Trabajador], [id_Estado_Trabajador]) VALUES (74847574, N'Eljua', N'Nito', 924785987, 3, 1)
INSERT [dbo].[T_Trabajador] ([dni], [nombre], [apellido], [celular], [id_Tipo_Trabajador], [id_Estado_Trabajador]) VALUES (75878474, N'Mario', N'Bros', 952958787, 3, 1)
GO

GO
INSERT [dbo].[T_Unidad] ([serie], [nombre], [modelo], [marca], [precio], [cantidad],[CantidadDisponible], [descripcion], [caracteristica1], [caracteristica2], [caracteristica3], [id_Tipo_Unidad], [id_Estado_Unidad], [imagen]) VALUES (N'COMB-01', N'Comba', N'160Z', N'Irimo', CAST(35 AS Decimal(18, 0)), 5, 4, N'Comba nueva', N'Peso(Kg): 0.1', N'Dimensiones: 25 x 10 cm', N'Material: Acero forjado', 2, 1, N'77277a60-5650-48c3-87b1-2e23ed7a22c41128900.jpg')
INSERT [dbo].[T_Unidad] ([serie], [nombre], [modelo], [marca], [precio], [cantidad],[CantidadDisponible], [descripcion], [caracteristica1], [caracteristica2], [caracteristica3], [id_Tipo_Unidad], [id_Estado_Unidad], [imagen]) VALUES (N'MAR-01', N'Martillo', N'MA-20', N'Truper', CAST(28 AS Decimal(18, 0)), 6, 5,  N'Martillo Uña Curva', N'Cabeza: 20 Oz', N'Mango: 14" (36 cm)', N'Boca: 1-1/4"', 2, 1, N'ee9e232e-68c0-438c-9226-f888a88c9b9bD_NQ_NP_669430-MLU29470204421_022019-O.jpg')
INSERT [dbo].[T_Unidad] ([serie], [nombre], [modelo], [marca], [precio], [cantidad],[CantidadDisponible], [descripcion], [caracteristica1], [caracteristica2], [caracteristica3], [id_Tipo_Unidad], [id_Estado_Unidad], [imagen]) VALUES (N'Mini-01', N'Minicargador', N'216B3', N'Cat', CAST(1230 AS Decimal(18, 0)), 7, 6,  N'Minicargador nuevo', N'Peso en orden de trabajo: 2581 kg', N'Velocidad de desplazamiento (avance o retroceso): 12.7 km/h', N'Modelo de motor: Cat C2.2', 1, 1, N'efa444a0-c469-4d54-8d75-8278c6e470fcCM20190926-d30ea-dd374.jpg')
GO

INSERT [dbo].[T_Pedido] ([fecha_Inicio], [cantidad_Dias], [obra], [empresa], [ubicacion], [fecha_Entrega], [precio_Pedido], [id_Estado_Pedido], [id_Usuario], [id_Trabajador], [id_Unidad],[Cantidad]) VALUES (CAST(N'2021-12-20T00:00:00.000' AS DateTime), 15, N'EdiObra03', N'Edificar', N'Surco', NULL, CAST(18450 AS Decimal(18, 0)), 3,1, 1, 1,1)
INSERT [dbo].[T_Pedido] ([fecha_Inicio], [cantidad_Dias], [obra], [empresa], [ubicacion], [fecha_Entrega], [precio_Pedido], [id_Estado_Pedido], [id_Usuario], [id_Trabajador], [id_Unidad],[Cantidad]) VALUES (CAST(N'2021-12-27T00:00:00.000' AS DateTime), 5, N'EdiObra04', N'PSY', N'Surco', NULL, CAST(175 AS Decimal(18, 0)), 2, 2, NULL, 2,1)
INSERT [dbo].[T_Pedido] ([fecha_Inicio], [cantidad_Dias], [obra], [empresa], [ubicacion], [fecha_Entrega], [precio_Pedido], [id_Estado_Pedido], [id_Usuario], [id_Trabajador], [id_Unidad],[Cantidad]) VALUES (CAST(N'2023-08-07T00:00:00.000' AS DateTime), 10, N'Ts', N'teet', N'tete', NULL, CAST(12300 AS Decimal(18, 0)), 1, 1, NULL, 3,1)
GO

INSERT [dbo].[T_Obra] ([empresa], [direccion], [nombre_Obra], [imagen], [fecha_Inicio], [duracion_Obra], [id_Usuario], [id_Estado_Obra]) VALUES (N'PSY', N'San juan de Miraflores 123', N'Obra de EDificio 1', N'd67a1b93-2dfd-4131-9e8d-056c3a16c194plano.jpeg', CAST(N'2021-12-20T00:00:00.000' AS DateTime), 5, 1, 11)
GO

INSERT [dbo].[T_Partida] ([nombre], [precio_Unidad], [id_Tipo_Partida]) VALUES (N'Suministros e instalaciones de techos prefabricados', CAST(90 AS Decimal(18, 0)), 1)
INSERT [dbo].[T_Partida] ([nombre], [precio_Unidad], [id_Tipo_Partida]) VALUES (N'Acarreo de herramientas y materiales', CAST(121 AS Decimal(18, 0)), 1)
INSERT [dbo].[T_Partida] ([nombre], [precio_Unidad], [id_Tipo_Partida]) VALUES (N'Fabricacion e instalacion de molduras en ventanas ', CAST(45 AS Decimal(18, 0)), 1)
INSERT [dbo].[T_Partida] ([nombre], [precio_Unidad], [id_Tipo_Partida]) VALUES (N'Encofrados y desencofrados para sobrecrecimiento', CAST(54 AS Decimal(18, 0)), 2)
GO

INSERT [dbo].[T_ObraxPartida] ([id_Partida], [id_Obra], [metrado], [unidad], [parcial]) VALUES (1, 1, CAST(2 AS Decimal(18, 0)), N'gbl', CAST(180 AS Decimal(18, 0)))
INSERT [dbo].[T_ObraxPartida] ([id_Partida], [id_Obra], [metrado], [unidad], [parcial]) VALUES (2, 1, CAST(1 AS Decimal(18, 0)), N'gbl', CAST(54 AS Decimal(18, 0)))
GO

INSERT [dbo].[T_Cotizacion] ([fecha], [total], [id_Obra], [id_EstadoCotizacion]) VALUES (CAST(N'2021-12-13T05:12:30.863' AS DateTime), CAST(234 AS Decimal(18, 0)), 1, 7)
GO

INSERT [dbo].[T_CotizacionxUnidad] ([Id_Unidad], [id_Cotizacion], [cantidad]) VALUES (1, 1, 1)
GO