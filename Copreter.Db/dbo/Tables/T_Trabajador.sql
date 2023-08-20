CREATE TABLE [dbo].[T_Trabajador] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Dni]                  INT            NOT NULL,
    [Nombre]               NVARCHAR (200) NOT NULL,
    [Apellido]             NVARCHAR (200) NOT NULL,
    [Celular]              INT            NOT NULL,
    [Id_Tipo_Trabajador]   INT            NOT NULL,
    [Id_Estado_Trabajador] INT            NOT NULL,
    [BORRADO]                 BIT            DEFAULT ((0)) NOT NULL,
    [ID_USUARIO_REGISTRO]     INT            NOT NULL DEFAULT 1,
    [FECHA_REGISTRO]          DATETIME       NOT NULL DEFAULT GETDATE(),
    [FECHA_MODIFICACION]      DATETIME       NULL,
    [ID_USUARIO_MODIFICACION] INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Trabajador_T_EstadoTrabajador] FOREIGN KEY ([Id_Estado_Trabajador]) REFERENCES [dbo].[T_EstadoTrabajador] ([ID]),
    CONSTRAINT [FK_T_Trabajador_T_TipoTrabajador] FOREIGN KEY ([Id_Tipo_Trabajador]) REFERENCES [dbo].[T_TipoTrabajador] ([ID])
);

