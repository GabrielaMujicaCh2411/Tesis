CREATE TABLE [dbo].[T_CotizacionxUnidad] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [id_Serie]      NVARCHAR (100) NOT NULL,
    [id_Cotizacion] NVARCHAR (200) NOT NULL,
    [cantidad]      INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_CotizacionxUnidad_T_Cotizacion] FOREIGN KEY ([id_Cotizacion]) REFERENCES [dbo].[T_Cotizacion] ([id_Cotizacion]),
    CONSTRAINT [FK_T_CotizacionxUnidad_T_Unidad] FOREIGN KEY ([id_Serie]) REFERENCES [dbo].[T_Unidad] ([serie])
);


GO


create trigger [dbo].[trg_asignar_herramienta]
on [dbo].[T_CotizacionxUnidad]
after insert
as
   set nocount on;
    declare
    @idCotizacion nvarchar(200),
	@idserie nvarchar(100),
	@cantidad int
 

    select @idCotizacion = id_Cotizacion,@idserie=id_Serie,@cantidad=cantidad
    from inserted

    declare
    @cotizacionid nvarchar(50),
	@serieid  nvarchar(100),
	@cant int,
	@i int,
	@i2 int
   

    set @cotizacionid=@idCotizacion
	set @serieid=@idserie
	set @cant= @cantidad

    begin
		set @i= (select cantidad from T_Unidad where serie=@serieid);
	    update T_Cotizacion set id_Cotizacion_Estado=8  where id_Cotizacion = @cotizacionid;
		update T_Cotizacion set id_Cotizacion_Estado=10  where id_Cotizacion = @cotizacionid;
		update T_Unidad set cantidad=@i-@cant where serie=@serieid;

		set @i2= (select cantidad from T_Unidad where serie=@serieid);
		
		if @i2 =0
		update T_Unidad set id_Estado_Unidad=2 where serie=@serieid;

	end