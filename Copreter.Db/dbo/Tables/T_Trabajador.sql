CREATE TABLE [dbo].[T_Trabajador] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [dni]                  INT            NOT NULL,
    [nombre]               NVARCHAR (200) NULL,
    [apellido]             NVARCHAR (200) NULL,
    [celular]              INT            NULL,
    [id_Tipo_Trabajador]   INT            NULL,
    [id_Estado_Trabajador] INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Trabajador_T_EstadoTrabajador] FOREIGN KEY ([id_Estado_Trabajador]) REFERENCES [dbo].[T_EstadoTrabajador] ([id_Estado_Trabajador]),
    CONSTRAINT [FK_T_Trabajador_T_TipoTrabajador] FOREIGN KEY ([id_Tipo_Trabajador]) REFERENCES [dbo].[T_TipoTrabajador] ([id_Tipo_Trabajdor])
);

