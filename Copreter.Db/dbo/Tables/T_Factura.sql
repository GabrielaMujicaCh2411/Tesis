CREATE TABLE [dbo].[T_Factura] (
    [id_Factura]            NVARCHAR (50)  NOT NULL,
    [imagen]                VARCHAR (MAX)  NULL,
    [id_Cotizacion_Factura] NVARCHAR (200) NULL,
    CONSTRAINT [PK_T_Factura] PRIMARY KEY CLUSTERED ([id_Factura] ASC),
    CONSTRAINT [FK_T_Factura_T_Cotizacion] FOREIGN KEY ([id_Cotizacion_Factura]) REFERENCES [dbo].[T_Cotizacion] ([id_Cotizacion])
);


GO


create trigger [dbo].[trg_Cotizacion_Facturado]
on [dbo].[T_Factura]
after insert
as
BEGIN
    set nocount on;
    declare
    @idCotizacion nvarchar(200),
	@idFactura nvarchar(200)
 

    select @idCotizacion = id_Cotizacion_Factura
    from inserted

    declare
    @cotizacionid nvarchar(200),
	 @facturaid nvarchar(200),
	@i int
   

    set @cotizacionid=@idCotizacion
	set @facturaid=@idFactura

    begin
		set @i= (select count(*) from T_Factura where id_Cotizacion_Factura  =@idCotizacion);

		if @i=1
       update T_Cotizacion set id_Cotizacion_Estado=4  where id_Cotizacion = @cotizacionid;

	   if @i=2
       update T_Cotizacion set id_Cotizacion_Estado=6  where id_Cotizacion = @cotizacionid;
	end
	end