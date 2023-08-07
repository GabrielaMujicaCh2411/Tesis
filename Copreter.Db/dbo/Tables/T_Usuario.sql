CREATE TABLE [dbo].[T_Usuario] (
    [id_Usuario]     NVARCHAR (100) NOT NULL,
    [contraseña]     NVARCHAR (100) NULL,
    [dni_Usuario]    INT            NULL,
    [id_Rol_Usuario] INT            NULL,
    CONSTRAINT [PK_T_Usuario] PRIMARY KEY CLUSTERED ([id_Usuario] ASC),
    CONSTRAINT [FK_T_Usuario_T_Cliente] FOREIGN KEY ([dni_Usuario]) REFERENCES [dbo].[T_Cliente] ([dni]),
    CONSTRAINT [FK_T_Usuario_T_Rol] FOREIGN KEY ([id_Rol_Usuario]) REFERENCES [dbo].[T_Rol] ([id_Rol])
);

