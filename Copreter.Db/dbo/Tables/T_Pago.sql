CREATE TABLE [dbo].[T_Pago] (
    [id_Pago]            NVARCHAR (200) NOT NULL,
    [fecha]              DATETIME       NULL,
    [pago1]              DECIMAL (18)   NULL,
    [pago2]              DECIMAL (18)   NULL,
    [id_Cotizacion_Pago] NVARCHAR (200) NULL,
    CONSTRAINT [PK_T_Pago] PRIMARY KEY CLUSTERED ([id_Pago] ASC),
    CONSTRAINT [FK_T_Pago_T_Cotizacion] FOREIGN KEY ([id_Cotizacion_Pago]) REFERENCES [dbo].[T_Cotizacion] ([id_Cotizacion])
);


GO


create trigger [dbo].[trg_Pago_2]
on [dbo].[T_Pago]
for update
as
   set nocount on;
    declare
    @idCotizacion nvarchar(200),
	@pago2 decimal(18,0)
 
    select @idCotizacion = (select o.id_Cotizacion from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion_Pago), @pago2=(select o.pago2 from T_Pago as o inner join inserted as s on o.id_Pago=s.id_Pago)
    from inserted

    declare
    @cotizacionid nvarchar(50),
	@2pago decimal(18,0)
   

    set @cotizacionid=@idCotizacion
	set @2pago=@pago2

    begin
		if @pago2 > 0
	    update T_Cotizacion set id_Cotizacion_Estado=7  where id_Cotizacion = @cotizacionid;
	end
GO


create trigger [dbo].[trg_Cotizacion_Pagado]
on [dbo].[T_Pago]
after insert
as
BEGIN
    set nocount on;
    declare
    @idCotizacion nvarchar(200)
 

    select @idCotizacion = id_Cotizacion_Pago
    from inserted

    declare
    @cotizacionid nvarchar(200)
   

    set @cotizacionid=@idCotizacion

    begin

       update T_Cotizacion set id_Cotizacion_Estado=5  where id_Cotizacion = @cotizacionid;
	end
	end