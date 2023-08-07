CREATE TABLE [dbo].[T_EstadoObra] (
    [id_EstadoObra]           INT            IDENTITY (1, 1) NOT NULL,
    [nombre_Estado_Obra]      NVARCHAR (100) NULL,
    [descripcion_Estado_Obra] NVARCHAR (100) NULL,
    CONSTRAINT [PK_T_EstadoObra] PRIMARY KEY CLUSTERED ([id_EstadoObra] ASC)
);

