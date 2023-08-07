CREATE TABLE [dbo].[T_TipoTrabajador] (
    [id_Tipo_Trabajdor]           INT            IDENTITY (1, 1) NOT NULL,
    [nombre_Tipo_Trabajador]      NVARCHAR (200) NULL,
    [descripcion_Tipo_Trabajador] NVARCHAR (500) NULL,
    CONSTRAINT [PK_T_TipoTrabajador] PRIMARY KEY CLUSTERED ([id_Tipo_Trabajdor] ASC)
);

