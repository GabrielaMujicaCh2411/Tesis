CREATE TABLE [dbo].[T_ObraxPartida] (
    [id_Partida] NVARCHAR (50) NOT NULL,
    [id_Obra]    NVARCHAR (50) NOT NULL,
    [metrado]    DECIMAL (18)  NULL,
    [unidad]     NVARCHAR (50) NULL,
    [parcial]    DECIMAL (18)  NULL,
    CONSTRAINT [PK_T_ObraxPartida] PRIMARY KEY CLUSTERED ([id_Partida] ASC, [id_Obra] ASC),
    CONSTRAINT [FK_T_ObraxPartida_T_Obra] FOREIGN KEY ([id_Obra]) REFERENCES [dbo].[T_Obra] ([id_Obra]),
    CONSTRAINT [FK_T_ObraxPartida_T_Partida] FOREIGN KEY ([id_Partida]) REFERENCES [dbo].[T_Partida] ([id_Partida])
);

