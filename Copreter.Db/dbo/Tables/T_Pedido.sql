CREATE TABLE [dbo].[T_Pedido] (
    [id_Pedido]            NVARCHAR (50)  NOT NULL,
    [fecha_Inicio]         DATETIME       NULL,
    [cantidad_Dias]        INT            NULL,
    [obra]                 NVARCHAR (MAX) NULL,
    [empresa]              NVARCHAR (MAX) NULL,
    [ubicacion]            NVARCHAR (MAX) NULL,
    [fecha_Entrega]        DATETIME       NULL,
    [precio_Pedido]        DECIMAL (18)   NULL,
    [id_Estado_Pedido]     INT            NULL,
    [id_Usuario_Pedido]    NVARCHAR (100) NULL,
    [id_Trabajador_Pedido] INT            NULL,
    [id_Unidad_Pedido]     NVARCHAR (100) NULL,
    CONSTRAINT [PK_T_Pedido] PRIMARY KEY CLUSTERED ([id_Pedido] ASC),
    CONSTRAINT [FK_T_Pedido_T_EstadoPedido] FOREIGN KEY ([id_Estado_Pedido]) REFERENCES [dbo].[T_EstadoPedido] ([id_Estado_Pedido]),
    CONSTRAINT [FK_T_Pedido_T_Trabajador] FOREIGN KEY ([id_Trabajador_Pedido]) REFERENCES [dbo].[T_Trabajador] ([dni]),
    CONSTRAINT [FK_T_Pedido_T_Unidad] FOREIGN KEY ([id_Unidad_Pedido]) REFERENCES [dbo].[T_Unidad] ([serie]),
    CONSTRAINT [FK_T_Pedido_T_Usuario1] FOREIGN KEY ([id_Usuario_Pedido]) REFERENCES [dbo].[T_Usuario] ([id_Usuario])
);

