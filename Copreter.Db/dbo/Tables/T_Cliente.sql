CREATE TABLE [dbo].[T_Cliente] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Dni]       INT            NOT NULL,
    [Nombre]    NVARCHAR (100) NOT NULL,
    [Apellido]  NVARCHAR (100) NOT NULL,
    [Celular]   INT            NOT NULL,
    [Correo]    NVARCHAR (100) NOT NULL,
    [Direccion] NVARCHAR (MAX) NOT NULL,
        [BORRADO]                 BIT            DEFAULT ((0)) NOT NULL,
    [ID_USUARIO_REGISTRO]     INT            NOT NULL DEFAULT 1,
    [FECHA_REGISTRO]          DATETIME       NOT NULL DEFAULT GETDATE(),
    [FECHA_MODIFICACION]      DATETIME       NULL,
    [ID_USUARIO_MODIFICACION] INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
);


--GO
--create trigger [dbo].[trg_Usuario_Create]
--on [dbo].[T_Cliente]
--after insert
--as
--BEGIN
--    set nocount on;
--    declare
--	@dni int,
--    @correo nvarchar(100)
	
	

--    select @correo = correo,@dni = dni
--    from inserted

--    declare
--    @usuario nvarchar(100),
--    @contraseña  nvarchar(100)

--    set @usuario=@correo
--    set @contraseña = @dni

--    begin
--        insert into T_Usuario values(@usuario,@contraseña,@contraseña,2 )
--    end
--END