CREATE TABLE [dbo].[T_Incidencia] (
    [id_Incidencia]        NVARCHAR (50)  NOT NULL,
    [fecha_Horario]        DATETIME       NULL,
    [incidencia]           NVARCHAR (MAX) NULL,
    [horas_Trabajadas]     INT            NULL,
    [id_Pedido_Incidencia] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_T_Incidencia] PRIMARY KEY CLUSTERED ([id_Incidencia] ASC),
    CONSTRAINT [FK_T_Incidencia_T_Pedido] FOREIGN KEY ([id_Pedido_Incidencia]) REFERENCES [dbo].[T_Pedido] ([id_Pedido])
);

