CREATE TABLE [dbo].[T_TipoUnidad] (
    [id_Tipo_Unidad]     INT            IDENTITY (1, 1) NOT NULL,
    [nombre_Tipo_Unidad] NVARCHAR (200) NULL,
    CONSTRAINT [PK_T_TipoUnidad] PRIMARY KEY CLUSTERED ([id_Tipo_Unidad] ASC)
);

