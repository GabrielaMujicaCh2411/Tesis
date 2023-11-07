CREATE TABLE [dbo].[T_Pago] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Fecha]              DATETIME       NOT NULL,
    [Monto]              DECIMAL (18)   NOT NULL,
    [Saldo]              DECIMAL (18)   NOT NULL,
    [Id_Cotizacion]      INT NOT NULL,
    [BORRADO]                 BIT            DEFAULT ((0)) NOT NULL,
    [ID_USUARIO_REGISTRO]     INT            NOT NULL DEFAULT 1,
    [FECHA_REGISTRO]          DATETIME       NOT NULL DEFAULT GETDATE(),
    [FECHA_MODIFICACION]      DATETIME       NULL,
    [ID_USUARIO_MODIFICACION] INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Pago_T_Cotizacion] FOREIGN KEY ([id_Cotizacion]) REFERENCES [dbo].[T_Cotizacion] ([ID])
);


--GO


--create trigger [dbo].[trg_Pago_2]
--on [dbo].[T_Pago]
--for update
--as
--   set nocount on;
--    declare
--    @idCotizacion nvarchar(200),
--	@pago2 decimal(18,0)
 
--    select @idCotizacion = (select o.id_Cotizacion from T_Cotizacion as o inner join inserted as s on o.id_Cotizacion=s.id_Cotizacion_Pago), @pago2=(select o.pago2 from T_Pago as o inner join inserted as s on o.id_Pago=s.id_Pago)
--    from inserted

--    declare
--    @cotizacionid nvarchar(50),
--	@2pago decimal(18,0)
   

--    set @cotizacionid=@idCotizacion
--	set @2pago=@pago2

--    begin
--		if @pago2 > 0
--	    update T_Cotizacion set id_Cotizacion_Estado=7  where id_Cotizacion = @cotizacionid;
--	end
--GO


--create trigger [dbo].[trg_Cotizacion_Pagado]
--on [dbo].[T_Pago]
--after insert
--as
--BEGIN
--    set nocount on;
--    declare
--    @idCotizacion nvarchar(200)
 

--    select @idCotizacion = id_Cotizacion_Pago
--    from inserted

--    declare
--    @cotizacionid nvarchar(200)
   

--    set @cotizacionid=@idCotizacion

--    begin

--       update T_Cotizacion set id_Cotizacion_Estado=5  where id_Cotizacion = @cotizacionid;
--	end
--	end