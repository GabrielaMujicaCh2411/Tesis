﻿CREATE TABLE [dbo].[T_TipoTrabajador] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Nonbre]      NVARCHAR (200) NULL,
    [Descripcion] NVARCHAR (MAX) NULL,
        [BORRADO]                 BIT            DEFAULT ((0)) NOT NULL,
    [ID_USUARIO_REGISTRO]     INT            NOT NULL DEFAULT 1,
    [FECHA_REGISTRO]          DATETIME       NOT NULL DEFAULT GETDATE(),
    [FECHA_MODIFICACION]      DATETIME       NULL,
    [ID_USUARIO_MODIFICACION] INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
);

