CREATE TABLE [dbo].[T_Partida] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]                    NVARCHAR (MAX) NOT NULL,
    [Precio_Unidad]             DECIMAL (18)   NOT NULL,
    [Id_Tipo_Partida]           INT            NOT NULL,
        [BORRADO]                 BIT            DEFAULT ((0)) NOT NULL,
    [ID_USUARIO_REGISTRO]     INT            NOT NULL DEFAULT 1,
    [FECHA_REGISTRO]          DATETIME       NOT NULL DEFAULT GETDATE(),
    [FECHA_MODIFICACION]      DATETIME       NULL,
    [ID_USUARIO_MODIFICACION] INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Partida_T_TipoPartida] FOREIGN KEY ([id_Tipo_Partida]) REFERENCES [dbo].[T_TipoPartida] ([ID])
);

