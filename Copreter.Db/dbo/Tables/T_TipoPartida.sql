﻿CREATE TABLE [dbo].[T_TipoPartida] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]      NVARCHAR (200) NULL,
    [Descripcion] NVARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
);

