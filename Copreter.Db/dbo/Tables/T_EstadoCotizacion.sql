CREATE TABLE [dbo].[T_EstadoCotizacion] (
    [id_Estado_Cotizacion]          INT            IDENTITY (1, 1) NOT NULL,
    [nombre_Estado_Cotizacion]      NVARCHAR (100) NULL,
    [descripcion_Estado_Cotizacion] NVARCHAR (100) NULL,
    CONSTRAINT [PK_T_EstadoCotizacion] PRIMARY KEY CLUSTERED ([id_Estado_Cotizacion] ASC)
);

