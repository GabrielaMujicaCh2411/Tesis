CREATE TABLE [dbo].[T_Acceso] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Id_Usuario]                INT NOT NULL, 
    [Id_Rol]                    INT            NOT NULL,
    [Email]                     NVARCHAR (100) NOT NULL,
    [Contrasenya]               NVARCHAR (100) NOT NULL,
    [BORRADO]                   BIT            DEFAULT ((0)) NOT NULL,
    [ID_USUARIO_REGISTRO]       INT            NOT NULL DEFAULT 1,
    [FECHA_REGISTRO]            DATETIME       NOT NULL DEFAULT GETDATE(),
    [FECHA_MODIFICACION]        DATETIME       NULL,
    [ID_USUARIO_MODIFICACION] INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Acceso_T_Rol] FOREIGN KEY ([Id_Rol]) REFERENCES [dbo].[T_Rol] ([ID]), 
    CONSTRAINT [FK_T_Acceso_To_Usuario] FOREIGN KEY ([Id_Usuario]) REFERENCES [T_Usuario]([ID])
);

