CREATE TABLE [dbo].[T_Cita] (
    [id_Cita]      NVARCHAR (100) NOT NULL,
    [fecha_Cita]   DATETIME       NULL,
    [hora_Cita]    NVARCHAR (50)  NULL,
    [id_Obra_Cita] NVARCHAR (50)  NULL,
    [lugar_Cita]   VARCHAR (500)  NULL,
    CONSTRAINT [PK_T_Cita] PRIMARY KEY CLUSTERED ([id_Cita] ASC),
    CONSTRAINT [FK_T_Cita_T_Obra] FOREIGN KEY ([id_Obra_Cita]) REFERENCES [dbo].[T_Obra] ([id_Obra])
);


GO

create trigger [dbo].[trg_Cita_Pendiente]
on [dbo].[T_Cita]
after insert
as
BEGIN
    set nocount on;
    declare
    @idObra nvarchar(50)
 

    select @idObra = id_Obra_Cita
    from inserted

    declare
    @obraid nvarchar(50)
   

    set @obraid=@idObra

    begin

       update T_Obra set id_Obra_Estado=4  where id_Obra = @obraid;
	end
	end