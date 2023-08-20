CREATE TABLE [dbo].[T_Incidencia] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Fecha]                 DATETIME       NOT NULL,
    [Incidencia]            NVARCHAR (MAX) NOT NULL,
    [Horas_Trabajadas]      INT            NOT NULL,
    [Id_Pedido]             INT            NOT NULL,
        [BORRADO]                 BIT            DEFAULT ((0)) NOT NULL,
    [ID_USUARIO_REGISTRO]     INT            NOT NULL DEFAULT 1,
    [FECHA_REGISTRO]          DATETIME       NOT NULL DEFAULT GETDATE(),
    [FECHA_MODIFICACION]      DATETIME       NULL,
    [ID_USUARIO_MODIFICACION] INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Incidencia_T_Pedido] FOREIGN KEY ([id_Pedido]) REFERENCES [dbo].[T_Pedido] ([ID])
);

