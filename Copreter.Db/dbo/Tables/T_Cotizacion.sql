CREATE TABLE [dbo].[T_Cotizacion] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [fecha]                DATETIME       NULL,
    [total]                DECIMAL (18)   NULL,
    [id_Obra_Cotizacion]   NVARCHAR (50)  NULL,
    [id_Cotizacion_Estado] INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Cotizacion_T_EstadoCotizacion] FOREIGN KEY ([id_Cotizacion_Estado]) REFERENCES [dbo].[T_EstadoCotizacion] ([id_Estado_Cotizacion]),
    CONSTRAINT [FK_T_Cotizacion_T_Obra] FOREIGN KEY ([id_Obra_Cotizacion]) REFERENCES [dbo].[T_Obra] ([id_Obra])
);


GO

create trigger [dbo].[trg_Obra_Proceso]
on [dbo].[T_Cotizacion]
for update
as
   set nocount on;
    declare
    @idCotizacion nvarchar(200),
	@estado int
 

    select @idCotizacion = (select o.id_Obra_Cotizacion from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion), @estado=(select o.id_Cotizacion_Estado from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion)
    from inserted

    declare
    @cotizacionid nvarchar(50),
	@estadoi int
   

    set @cotizacionid=@idCotizacion
	set @estadoi=@estado

    begin
		if @estadoi =10
	    update T_Obra set id_Obra_Estado=9  where id_Obra = @cotizacionid;
	end
GO

create trigger [dbo].[trg_Obra_Pagado]
on [dbo].[T_Cotizacion]
for update
as
   set nocount on;
    declare
    @idCotizacion nvarchar(200),
	@estado int
 

    select @idCotizacion = (select o.id_Obra_Cotizacion from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion), @estado=(select o.id_Cotizacion_Estado from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion)
    from inserted

    declare
    @cotizacionid nvarchar(50),
	@estadoi int
   

    set @cotizacionid=@idCotizacion
	set @estadoi=@estado

    begin
		if @estadoi =5
	    update T_Obra set id_Obra_Estado=8  where id_Obra = @cotizacionid;
	end
GO

create trigger [dbo].[trg_Obra_Finalizada]
on [dbo].[T_Cotizacion]
for update
as
   set nocount on;
    declare
    @idCotizacion nvarchar(200),
	@estado int
 

    select @idCotizacion = (select o.id_Obra_Cotizacion from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion), @estado=(select o.id_Cotizacion_Estado from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion)
    from inserted

    declare
    @cotizacionid nvarchar(50),
	@estadoi int
   

    set @cotizacionid=@idCotizacion
	set @estadoi=@estado

    begin
		if @estadoi =7
	    update T_Obra set id_Obra_Estado=11  where id_Obra = @cotizacionid;
	end
GO


create trigger [dbo].[trg_Obra_Facturado]
on [dbo].[T_Cotizacion]
for update
as
   set nocount on;
    declare
    @idCotizacion nvarchar(200),
	@estado int
 

    select @idCotizacion = (select o.id_Obra_Cotizacion from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion), @estado=(select o.id_Cotizacion_Estado from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion)
    from inserted

    declare
    @cotizacionid nvarchar(50),
	@estadoi int
   

    set @cotizacionid=@idCotizacion
	set @estadoi=@estado

    begin
		if @estadoi =4
	    update T_Obra set id_Obra_Estado=7  where id_Obra = @cotizacionid;
	end
GO

create trigger [dbo].[trg_Obra_Cotizado]
on [dbo].[T_Cotizacion]
after insert
as
BEGIN
    set nocount on;
    declare
    @idObra nvarchar(50)
 

    select @idObra = id_Obra_Cotizacion
    from inserted

    declare
    @obraid nvarchar(50)
   

    set @obraid=@idObra

    begin

       update T_Obra set id_Obra_Estado=5  where id_Obra = @obraid;
	end
	end