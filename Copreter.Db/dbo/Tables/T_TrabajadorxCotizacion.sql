CREATE TABLE [dbo].[T_TrabajadorxCotizacion] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Id_Cotizacion]             INT            NOT NULL,
    [Id_Trabajador]             INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_TrabajadorxCotizacion_T_Cotizacion] FOREIGN KEY ([Id_Cotizacion]) REFERENCES [dbo].[T_Cotizacion] ([ID]),
    CONSTRAINT [FK_T_TrabajadorxCotizacion_T_Trabajador] FOREIGN KEY ([Id_Trabajador]) REFERENCES [dbo].[T_Trabajador] ([ID])
);


--GO


--create trigger [dbo].[trg_asignar_trabajador]
--on [dbo].[T_TrabajadorxCotizacion]
--after insert
--as
--   set nocount on;
--    declare
--    @idCotizacion nvarchar(200),
--	@idtrabajador int
 

--    select @idCotizacion = id_Cotizacion,@idtrabajador=dni_Trabajador
--    from inserted

--    declare
--    @cotizacionid nvarchar(50),
--	@trabajadorid int
   

--    set @cotizacionid=@idCotizacion
--	set @trabajadorid=@idtrabajador

--    begin
--	    update T_Cotizacion set id_Cotizacion_Estado=9  where ID = @cotizacionid;
--		update T_Trabajador set id_Estado_Trabajador=2 where dni=@trabajadorid

--	end