CREATE TABLE [dbo].[T_Cita] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Fecha]   DATETIME       NOT NULL,
    [Hora]    NVARCHAR (50)  NOT NULL,
    [Id_Obra] INT  NOT NULL,
    [Lugar]   VARCHAR (500)  NOT NULL,
    [BORRADO]                 BIT            DEFAULT ((0)) NOT NULL,
    [ID_USUARIO_REGISTRO]     INT            NOT NULL DEFAULT 1,
    [FECHA_REGISTRO]          DATETIME       NOT NULL DEFAULT GETDATE(),
    [FECHA_MODIFICACION]      DATETIME       NULL,
    [ID_USUARIO_MODIFICACION] INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Cita_T_Obra] FOREIGN KEY ([Id_Obra]) REFERENCES [dbo].[T_Obra] ([ID])
);


GO

--create trigger [dbo].[trg_Cita_Pendiente]
--on [dbo].[T_Cita]
--after insert
--as
--BEGIN
--    set nocount on;
--    declare
--    @idObra nvarchar(50)
 

--    select @idObra = id_Obra_Cita
--    from inserted

--    declare
--    @obraid nvarchar(50)
   

--    set @obraid=@idObra

--    begin

--       update T_Obra set id_Obra_Estado=4  where id_Obra = @obraid;
--	end
--	end