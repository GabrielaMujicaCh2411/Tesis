CREATE TABLE [dbo].[T_ObraxPartida] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [id_Partida] NVARCHAR (50) NOT NULL,
    [id_Obra]    NVARCHAR (50) NOT NULL,
    [metrado]    DECIMAL (18)  NULL,
    [unidad]     NVARCHAR (50) NULL,
    [parcial]    DECIMAL (18)  NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_ObraxPartida_T_Obra] FOREIGN KEY ([id_Obra]) REFERENCES [dbo].[T_Obra] ([ID]),
    CONSTRAINT [FK_T_ObraxPartida_T_Partida] FOREIGN KEY ([id_Partida]) REFERENCES [dbo].[T_Partida] ([ID])
);

