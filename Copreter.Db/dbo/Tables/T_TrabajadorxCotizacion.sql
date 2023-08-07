CREATE TABLE [dbo].[T_TrabajadorxCotizacion] (
    [id_Cotizacion]  NVARCHAR (200) NOT NULL,
    [dni_Trabajador] INT            NOT NULL,
    CONSTRAINT [PK_T_TrabajadorxCotizacion] PRIMARY KEY CLUSTERED ([id_Cotizacion] ASC, [dni_Trabajador] ASC),
    CONSTRAINT [FK_T_TrabajadorxCotizacion_T_Cotizacion] FOREIGN KEY ([id_Cotizacion]) REFERENCES [dbo].[T_Cotizacion] ([id_Cotizacion]),
    CONSTRAINT [FK_T_TrabajadorxCotizacion_T_Trabajador] FOREIGN KEY ([dni_Trabajador]) REFERENCES [dbo].[T_Trabajador] ([dni])
);


GO


create trigger [dbo].[trg_asignar_trabajador]
on [dbo].[T_TrabajadorxCotizacion]
after insert
as
   set nocount on;
    declare
    @idCotizacion nvarchar(200),
	@idtrabajador int
 

    select @idCotizacion = id_Cotizacion,@idtrabajador=dni_Trabajador
    from inserted

    declare
    @cotizacionid nvarchar(50),
	@trabajadorid int
   

    set @cotizacionid=@idCotizacion
	set @trabajadorid=@idtrabajador

    begin
	    update T_Cotizacion set id_Cotizacion_Estado=9  where id_Cotizacion = @cotizacionid;
		update T_Trabajador set id_Estado_Trabajador=2 where dni=@trabajadorid

	end