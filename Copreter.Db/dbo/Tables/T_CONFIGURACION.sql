CREATE TABLE [dbo].[T_Configuracion]
(
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]                    NVARCHAR(50) NOT NULL, 
    [Valor]                     NVARCHAR(MAX)            NOT NULL,
    [BORRADO]                   BIT            DEFAULT ((0)) NOT NULL,
    [ID_USUARIO_REGISTRO]       INT            NOT NULL DEFAULT 1,
    [FECHA_REGISTRO]            DATETIME       NOT NULL DEFAULT GETDATE(),
    [FECHA_MODIFICACION]        DATETIME       NULL,
    [ID_USUARIO_MODIFICACION] INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
)
