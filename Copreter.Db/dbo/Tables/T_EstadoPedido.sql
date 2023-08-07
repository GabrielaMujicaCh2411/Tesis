CREATE TABLE [dbo].[T_EstadoPedido] (
    [id_Estado_Pedido]          INT            IDENTITY (1, 1) NOT NULL,
    [nombre_Estado_Pedido]      NVARCHAR (100) NULL,
    [descripcion_Estado_Pedido] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_T_EstadoPedido] PRIMARY KEY CLUSTERED ([id_Estado_Pedido] ASC)
);

