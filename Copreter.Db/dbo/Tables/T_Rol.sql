CREATE TABLE [dbo].[T_Rol] (
    [id_Rol]          INT            IDENTITY (1, 1) NOT NULL,
    [nombre_Rol]      NVARCHAR (200) NULL,
    [descripcion_Rol] NVARCHAR (500) NULL,
    CONSTRAINT [PK_T_Rol] PRIMARY KEY CLUSTERED ([id_Rol] ASC)
);

