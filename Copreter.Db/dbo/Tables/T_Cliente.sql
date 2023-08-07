CREATE TABLE [dbo].[T_Cliente] (
    [dni]       INT            NOT NULL,
    [nombre]    NVARCHAR (100) NULL,
    [apellido]  NVARCHAR (100) NULL,
    [celular]   INT            NULL,
    [correo]    NVARCHAR (100) NULL,
    [direccion] NVARCHAR (500) NULL,
    CONSTRAINT [PK_T_Cliente] PRIMARY KEY CLUSTERED ([dni] ASC)
);


GO
create trigger [dbo].[trg_Usuario_Create]
on [dbo].[T_Cliente]
after insert
as
BEGIN
    set nocount on;
    declare
	@dni int,
    @correo nvarchar(100)
	
	

    select @correo = correo,@dni = dni
    from inserted

    declare
    @usuario nvarchar(100),
    @contraseña  nvarchar(100)

    set @usuario=@correo
    set @contraseña = @dni

    begin
        insert into T_Usuario values(@usuario,@contraseña,@contraseña,2 )
    end
END