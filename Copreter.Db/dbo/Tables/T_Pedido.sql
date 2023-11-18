CREATE TABLE [dbo].[T_Pedido] (
    [ID]                   INT            IDENTITY (1, 1) NOT NULL,
    [Fecha_Inicio]         DATETIME       NOT NULL,
    [Obra]                 NVARCHAR (MAX) NOT NULL,
    [Empresa]              NVARCHAR (MAX) NOT NULL,
    [Ubicacion]            NVARCHAR (MAX) NOT NULL,
    [Id_Estado_Pedido]     INT            NOT NULL,
    [Id_Usuario]           INT            NOT NULL,
    [Id_Trabajador]        INT            NULL,
    [Id_Unidad]            INT            NULL,
    [Cantidad] INT NOT NULL DEFAULT 0, 
    [BORRADO]                 BIT            DEFAULT ((0)) NOT NULL,
    [ID_USUARIO_REGISTRO]     INT            NOT NULL DEFAULT 1,
    [FECHA_REGISTRO]          DATETIME       NOT NULL DEFAULT GETDATE(),
    [FECHA_MODIFICACION]      DATETIME       NULL,
    [ID_USUARIO_MODIFICACION] INT            NULL,
    
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Pedido_T_EstadoPedido] FOREIGN KEY ([id_Estado_Pedido]) REFERENCES [dbo].[T_EstadoPedido] ([ID]),
    CONSTRAINT [FK_T_Pedido_T_Trabajador] FOREIGN KEY ([id_Trabajador]) REFERENCES [dbo].[T_Trabajador] ([ID]),
    CONSTRAINT [FK_T_Pedido_T_Unidad] FOREIGN KEY ([id_Unidad]) REFERENCES [dbo].[T_Unidad] ([ID]),
    CONSTRAINT [FK_T_Pedido_T_Usuario1] FOREIGN KEY ([id_Usuario]) REFERENCES [dbo].[T_Usuario] ([ID])
);

