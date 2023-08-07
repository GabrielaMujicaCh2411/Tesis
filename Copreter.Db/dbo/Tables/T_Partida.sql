CREATE TABLE [dbo].[T_Partida] (
    [id_Partida]      NVARCHAR (50)  NOT NULL,
    [nombre_Partida]  NVARCHAR (MAX) NULL,
    [precio_Unidad]   DECIMAL (18)   NULL,
    [id_Tipo_Partida] INT            NULL,
    CONSTRAINT [PK_T_Partida] PRIMARY KEY CLUSTERED ([id_Partida] ASC),
    CONSTRAINT [FK_T_Partida_T_TipoPartida] FOREIGN KEY ([id_Tipo_Partida]) REFERENCES [dbo].[T_TipoPartida] ([id_Tipo_Partida])
);

