CREATE TABLE [dbo].[T_Usuario] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Email]                     NVARCHAR (100) NOT NULL,
    [Contrasenya]               NVARCHAR (100) NULL,
    [Dni]                       INT            NULL,
    [Id_Rol]                    INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Usuario_T_Rol] FOREIGN KEY ([Id_Rol]) REFERENCES [dbo].[T_Rol] ([ID])
);

