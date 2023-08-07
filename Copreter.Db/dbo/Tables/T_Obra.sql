CREATE TABLE [dbo].[T_Obra] (
    [id_Obra]         NVARCHAR (50)  NOT NULL,
    [empresa]         NVARCHAR (500) NULL,
    [direccion]       NVARCHAR (500) NULL,
    [nombre_Obra]     NVARCHAR (500) NULL,
    [imagen]          VARCHAR (MAX)  NULL,
    [fecha_Inicio]    DATETIME       NULL,
    [duracion_Obra]   INT            NULL,
    [id_Usuario_Obra] NVARCHAR (100) NULL,
    [id_Obra_Estado]  INT            NULL,
    CONSTRAINT [PK_T_Obra] PRIMARY KEY CLUSTERED ([id_Obra] ASC),
    CONSTRAINT [FK_T_Obra_T_EstadoObra] FOREIGN KEY ([id_Obra_Estado]) REFERENCES [dbo].[T_EstadoObra] ([id_EstadoObra]),
    CONSTRAINT [FK_T_Obra_T_Usuario] FOREIGN KEY ([id_Usuario_Obra]) REFERENCES [dbo].[T_Usuario] ([id_Usuario])
);


GO

create trigger [dbo].[trg_Obra_Rechazada]
on [dbo].[T_Obra]
for update
as
   set nocount on;
    declare
    @idObra nvarchar(50),
	@estado int
 

    select @idObra = (select o.id_Obra from T_Obra as o inner join inserted as s on o.id_Obra=s.id_Obra), @estado=(select o.id_Obra_Estado from T_Obra as o inner join inserted as s on o.id_Obra=s.id_Obra)
    from inserted

    declare
    @obraid nvarchar(50),
	@estadoi int
   

    set @obraid=@idObra
	set @estadoi=@estado

    begin
		if @estadoi =6
	    update T_Cotizacion set id_Cotizacion_Estado=3  where id_Obra_Cotizacion = @obraid;
	end
GO

create trigger [dbo].[trg_Obra_Aceptado]
on [dbo].[T_Obra]
for update
as
   set nocount on;
    declare
    @idObra nvarchar(50),
	@estado int
 

    select @idObra = (select o.id_Obra from T_Obra as o inner join inserted as s on o.id_Obra=s.id_Obra), @estado=(select o.id_Obra_Estado from T_Obra as o inner join inserted as s on o.id_Obra=s.id_Obra)
    from inserted

    declare
    @obraid nvarchar(50),
	@estadoi int
   

    set @obraid=@idObra
	set @estadoi=@estado

    begin
		if @estadoi =2
	    update T_Cotizacion set id_Cotizacion_Estado=2  where id_Obra_Cotizacion = @obraid;
	end