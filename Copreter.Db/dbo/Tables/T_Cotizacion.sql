CREATE TABLE [dbo].[T_Cotizacion] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Fecha]                DATETIME       NOT NULL,
    [Igv]                   DECIMAL (18,2)   NOT NULL,
    [Igv_Calculado]                   DECIMAL (18,2)   NOT NULL,
    [SubTotal]              DECIMAL(18, 2) NOT NULL, 
    [Total]                DECIMAL (18,2)   NOT NULL,
    [Saldo]                DECIMAL (18,2)   NOT NULL,
    [Id_Obra]   INT  NOT NULL,
    [Id_EstadoCotizacion] INT            NOT NULL,
    [BORRADO]                 BIT            DEFAULT ((0)) NOT NULL,
    [ID_USUARIO_REGISTRO]     INT            NOT NULL DEFAULT 1,
    [FECHA_REGISTRO]          DATETIME       NOT NULL DEFAULT GETDATE(),
    [FECHA_MODIFICACION]      DATETIME       NULL,
    [ID_USUARIO_MODIFICACION] INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Cotizacion_T_EstadoCotizacion] FOREIGN KEY ([Id_EstadoCotizacion]) REFERENCES [dbo].[T_EstadoCotizacion] ([ID]),
    CONSTRAINT [FK_T_Cotizacion_T_Obra] FOREIGN KEY ([Id_Obra]) REFERENCES [dbo].[T_Obra] ([ID])
);


--GO

--create trigger [dbo].[trg_Obra_Proceso]
--on [dbo].[T_Cotizacion]
--for update
--as
--   set nocount on;
--    declare
--    @idCotizacion nvarchar(200),
--	@estado int
 

--    select @idCotizacion = (select o.id_Obra_Cotizacion from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion), @estado=(select o.id_Cotizacion_Estado from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion)
--    from inserted

--    declare
--    @cotizacionid nvarchar(50),
--	@estadoi int
   

--    set @cotizacionid=@idCotizacion
--	set @estadoi=@estado

--    begin
--		if @estadoi =10
--	    update T_Obra set id_Obra_Estado=9  where id_Obra = @cotizacionid;
--	end
--GO

--create trigger [dbo].[trg_Obra_Pagado]
--on [dbo].[T_Cotizacion]
--for update
--as
--   set nocount on;
--    declare
--    @idCotizacion nvarchar(200),
--	@estado int
 

--    select @idCotizacion = (select o.id_Obra_Cotizacion from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion), @estado=(select o.id_Cotizacion_Estado from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion)
--    from inserted

--    declare
--    @cotizacionid nvarchar(50),
--	@estadoi int
   

--    set @cotizacionid=@idCotizacion
--	set @estadoi=@estado

--    begin
--		if @estadoi =5
--	    update T_Obra set id_Obra_Estado=8  where id_Obra = @cotizacionid;
--	end
--GO

--create trigger [dbo].[trg_Obra_Finalizada]
--on [dbo].[T_Cotizacion]
--for update
--as
--   set nocount on;
--    declare
--    @idCotizacion nvarchar(200),
--	@estado int
 

--    select @idCotizacion = (select o.id_Obra_Cotizacion from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion), @estado=(select o.id_Cotizacion_Estado from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion)
--    from inserted

--    declare
--    @cotizacionid nvarchar(50),
--	@estadoi int
   

--    set @cotizacionid=@idCotizacion
--	set @estadoi=@estado

--    begin
--		if @estadoi =7
--	    update T_Obra set id_Obra_Estado=11  where id_Obra = @cotizacionid;
--	end
--GO


--create trigger [dbo].[trg_Obra_Facturado]
--on [dbo].[T_Cotizacion]
--for update
--as
--   set nocount on;
--    declare
--    @idCotizacion nvarchar(200),
--	@estado int
 

--    select @idCotizacion = (select o.id_Obra_Cotizacion from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion), @estado=(select o.id_Cotizacion_Estado from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion)
--    from inserted

--    declare
--    @cotizacionid nvarchar(50),
--	@estadoi int
   

--    set @cotizacionid=@idCotizacion
--	set @estadoi=@estado

--    begin
--		if @estadoi =4
--	    update T_Obra set id_Obra_Estado=7  where id_Obra = @cotizacionid;
--	end
--GO

--create trigger [dbo].[trg_Obra_Cotizado]
--on [dbo].[T_Cotizacion]
--after insert
--as
--BEGIN
--    set nocount on;
--    declare
--    @idObra nvarchar(50)
 

--    select @idObra = id_Obra_Cotizacion
--    from inserted

--    declare
--    @obraid nvarchar(50)
   

--    set @obraid=@idObra

--    begin

--       update T_Obra set id_Obra_Estado=5  where id_Obra = @obraid;
--	end
--	end