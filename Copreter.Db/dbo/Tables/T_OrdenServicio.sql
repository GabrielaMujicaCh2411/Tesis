CREATE TABLE [dbo].[T_OrdenServicio] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [fecha_Orden]           DATETIME      NULL,
    [liquidacion]           DECIMAL (18)  NULL,
    [Id_Pedido]             INT,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_OrdenServicio_T_Pedido] FOREIGN KEY ([id_Pedido]) REFERENCES [dbo].[T_Pedido] ([ID])
);

