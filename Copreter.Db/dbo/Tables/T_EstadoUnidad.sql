CREATE TABLE [dbo].[T_EstadoUnidad] (
    [id_Estado_Unidad]          INT            IDENTITY (1, 1) NOT NULL,
    [nombre_Estado_Unidad]      NVARCHAR (200) NULL,
    [descripcion_Estado_Unidad] NVARCHAR (500) NULL,
    CONSTRAINT [PK_T_EstadoUnidad] PRIMARY KEY CLUSTERED ([id_Estado_Unidad] ASC)
);

