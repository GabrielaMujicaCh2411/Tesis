CREATE TABLE [dbo].[T_Incidencia] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [fecha_Horario]        DATETIME       NULL,
    [incidencia]           NVARCHAR (MAX) NULL,
    [horas_Trabajadas]     INT            NULL,
    [id_Pedido]            INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Incidencia_T_Pedido] FOREIGN KEY ([id_Pedido]) REFERENCES [dbo].[T_Pedido] ([ID])
);

