﻿CREATE TABLE [dbo].[T_Pedido_Solicitud]
(
    [ID]                   INT            IDENTITY (1, 1) NOT NULL,
	[Id_Pedido]			   INT            NOT NULL ,
	[Cantidad_Dias]        INT            NOT NULL,
    [Precio_Unidad]        DECIMAL (18,2)   NOT NULL,
	[Precio_SubTotal]       DECIMAL (18,2)   NOT NULL,
	[Igv]					DECIMAL (18,2)   NOT NULL,
	[Igv_Calculado]                   DECIMAL (18,2)   NOT NULL,
	[Precio_Total]			DECIMAL (18,2)   NOT NULL,
	[Fecha_Entrega]			DATETIME       NULL,
	[Fecha_Devolucion]		DATETIME       NULL,
	[BORRADO]                 BIT            DEFAULT ((0)) NOT NULL,
    [ID_USUARIO_REGISTRO]     INT            NOT NULL DEFAULT 1,
    [FECHA_REGISTRO]          DATETIME       NOT NULL DEFAULT GETDATE(),
    [FECHA_MODIFICACION]      DATETIME       NULL,
    [ID_USUARIO_MODIFICACION] INT            NULL,
	PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_T_Pedido_Solicitud_T_Pedido] FOREIGN KEY ([Id_Pedido]) REFERENCES [dbo].[T_Pedido] ([ID]),
)
