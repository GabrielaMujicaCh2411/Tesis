CREATE TABLE [dbo].[T_ObraxPartida] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Id_Partida] INT NOT NULL,
    [Id_Obra]    INT NOT NULL,
    [Metrado]    DECIMAL (18)  NOT NULL,
    [Unidad]     NVARCHAR (50) NOT NULL,
    [Parcial]    DECIMAL (18)  NOT NULL,
        [BORRADO]                 BIT            DEFAULT ((0)) NOT NULL,
    [ID_USUARIO_REGISTRO]     INT            NOT NULL DEFAULT 1,
    [FECHA_REGISTRO]          DATETIME       NOT NULL DEFAULT GETDATE(),
    [FECHA_MODIFICACION]      DATETIME       NULL,
    [ID_USUARIO_MODIFICACION] INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_ObraxPartida_T_Obra] FOREIGN KEY ([id_Obra]) REFERENCES [dbo].[T_Obra] ([ID]),
    CONSTRAINT [FK_T_ObraxPartida_T_Partida] FOREIGN KEY ([id_Partida]) REFERENCES [dbo].[T_Partida] ([ID])
);

