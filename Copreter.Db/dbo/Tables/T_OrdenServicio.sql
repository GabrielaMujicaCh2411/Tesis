CREATE TABLE [dbo].[T_OrdenServicio] (
    [id_Orden]        NVARCHAR (50) NOT NULL,
    [fecha_Orden]     DATETIME      NULL,
    [liquidacion]     DECIMAL (18)  NULL,
    [id_Pedido_Orden] NVARCHAR (50) NULL,
    CONSTRAINT [PK_T_OrdenServicio] PRIMARY KEY CLUSTERED ([id_Orden] ASC),
    CONSTRAINT [FK_T_OrdenServicio_T_Pedido] FOREIGN KEY ([id_Pedido_Orden]) REFERENCES [dbo].[T_Pedido] ([id_Pedido])
);

