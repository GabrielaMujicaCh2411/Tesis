CREATE TABLE [dbo].[T_TipoPartida] (
    [id_Tipo_Partida]          INT            IDENTITY (1, 1) NOT NULL,
    [nombre_Tipo_Partida]      NVARCHAR (200) NULL,
    [descripcion_Tipo_Partida] NVARCHAR (500) NULL,
    CONSTRAINT [PK_T_TipoPartida] PRIMARY KEY CLUSTERED ([id_Tipo_Partida] ASC)
);

