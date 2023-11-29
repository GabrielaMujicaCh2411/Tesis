CREATE TABLE [dbo].[T_Pedido_OrdenServicio]
(
    [ID]                   INT            IDENTITY (1, 1) NOT NULL,
	[Id_Pedido]			   INT            NOT NULL ,
    [Imagen]          VARCHAR (MAX)  NULL,
	[BORRADO]                 BIT            DEFAULT ((0)) NOT NULL,
    [ID_USUARIO_REGISTRO]     INT            NOT NULL DEFAULT 1,
    [FECHA_REGISTRO]          DATETIME       NOT NULL DEFAULT GETDATE(),
    [FECHA_MODIFICACION]      DATETIME       NULL,
    [ID_USUARIO_MODIFICACION] INT            NULL,
	PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_T_Pedido_OrdenServicio_T_Pedido] FOREIGN KEY ([Id_Pedido]) REFERENCES [dbo].[T_Pedido] ([ID]),
)
