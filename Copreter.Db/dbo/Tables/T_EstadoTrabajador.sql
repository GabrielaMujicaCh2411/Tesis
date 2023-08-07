CREATE TABLE [dbo].[T_EstadoTrabajador] (
    [id_Estado_Trabajador]        INT            IDENTITY (1, 1) NOT NULL,
    [nombre_Estado_Trabajador]    NVARCHAR (200) NULL,
    [descripcionEstadoTrabajador] NVARCHAR (500) NULL,
    CONSTRAINT [PK_T_EstadoTrabajador] PRIMARY KEY CLUSTERED ([id_Estado_Trabajador] ASC)
);

