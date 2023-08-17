CREATE TABLE [dbo].[T_TipoTrabajador] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Nonbre]      NVARCHAR (200) NULL,
    [Descripcion] NVARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
);

