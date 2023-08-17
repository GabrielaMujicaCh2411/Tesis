CREATE TABLE [dbo].[T_Partida] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]                    NVARCHAR (MAX) NULL,
    [precio_Unidad]             DECIMAL (18)   NULL,
    [Id_Tipo_Partida]           INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Partida_T_TipoPartida] FOREIGN KEY ([id_Tipo_Partida]) REFERENCES [dbo].[T_TipoPartida] ([ID])
);

