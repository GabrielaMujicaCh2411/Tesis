CREATE TABLE [dbo].[T_EstadoPedido] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]      NVARCHAR (100) NULL,
    [Descripcion] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
);

