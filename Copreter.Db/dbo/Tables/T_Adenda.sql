CREATE TABLE [dbo].[T_Adenda]
(
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Id_Pedido]   INT  NOT NULL,
    [Imagen]          VARCHAR (MAX)  NULL,
    [BORRADO]                 BIT            DEFAULT ((0)) NOT NULL,
    [ID_USUARIO_REGISTRO]     INT            NOT NULL DEFAULT 1,
    [FECHA_REGISTRO]          DATETIME       NOT NULL DEFAULT GETDATE(),
    [FECHA_MODIFICACION]      DATETIME       NULL,
    [ID_USUARIO_MODIFICACION] INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_T_Adenda_To_Orden] FOREIGN KEY ([Id_Pedido]) REFERENCES [T_Pedido]([ID]),
)
