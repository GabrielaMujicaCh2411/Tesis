CREATE TABLE [dbo].[T_Unidad] (
    [serie]            NVARCHAR (100) NOT NULL,
    [nombre]           NVARCHAR (100) NULL,
    [modelo]           NVARCHAR (100) NULL,
    [marca]            NVARCHAR (100) NULL,
    [precio]           DECIMAL (18)   NULL,
    [cantidad]         INT            NULL,
    [descripcion]      NVARCHAR (500) NULL,
    [caracteristica1]  NVARCHAR (500) NOT NULL,
    [caracteristica2]  NVARCHAR (500) NULL,
    [caracteristica3]  NVARCHAR (500) NULL,
    [id_Tipo_Unidad]   INT            NULL,
    [id_Estado_Unidad] INT            NULL,
    [imagen]           VARCHAR (MAX)  NULL,
    CONSTRAINT [PK_T_Unidad] PRIMARY KEY CLUSTERED ([serie] ASC),
    CONSTRAINT [FK_T_Unidad_T_EstadoUnidad] FOREIGN KEY ([id_Estado_Unidad]) REFERENCES [dbo].[T_EstadoUnidad] ([id_Estado_Unidad]),
    CONSTRAINT [FK_T_Unidad_T_TipoUnidad] FOREIGN KEY ([id_Tipo_Unidad]) REFERENCES [dbo].[T_TipoUnidad] ([id_Tipo_Unidad])
);

