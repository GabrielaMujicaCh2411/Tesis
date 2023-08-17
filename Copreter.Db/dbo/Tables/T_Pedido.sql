CREATE TABLE [dbo].[T_Pedido] (
    [ID]                   INT            IDENTITY (1, 1) NOT NULL,
    [Fecha_Inicio]         DATETIME       NULL,
    [Cantidad_Dias]        INT            NULL,
    [Obra]                 NVARCHAR (MAX) NULL,
    [Empresa]              NVARCHAR (MAX) NULL,
    [Ubicacion]            NVARCHAR (MAX) NULL,
    [Fecha_Entrega]        DATETIME       NULL,
    [Precio_Pedido]        DECIMAL (18)   NULL,
    [Id_Estado_Pedido]     INT            NULL,
    [Id_Usuario]           INT            NULL,
    [Id_Trabajador]        INT            NULL,
    [Id_Unidad]            INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Pedido_T_EstadoPedido] FOREIGN KEY ([id_Estado_Pedido]) REFERENCES [dbo].[T_EstadoPedido] ([ID]),
    CONSTRAINT [FK_T_Pedido_T_Trabajador] FOREIGN KEY ([id_Trabajador]) REFERENCES [dbo].[T_Trabajador] ([ID]),
    CONSTRAINT [FK_T_Pedido_T_Unidad] FOREIGN KEY ([id_Unidad]) REFERENCES [dbo].[T_Unidad] ([ID]),
    CONSTRAINT [FK_T_Pedido_T_Usuario1] FOREIGN KEY ([id_Usuario]) REFERENCES [dbo].[T_Usuario] ([ID])
);

