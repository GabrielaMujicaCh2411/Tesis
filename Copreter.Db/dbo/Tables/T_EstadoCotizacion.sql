CREATE TABLE [dbo].[T_EstadoCotizacion] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]      NVARCHAR (100) NULL,
    [Descripcion] NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
);

