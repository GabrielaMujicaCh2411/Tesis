using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Copreter.Domain.Model.DbModel
{
    public partial class DBCopreterContext : DbContext
    {
        public DBCopreterContext()
        {
        }

        public DBCopreterContext(DbContextOptions<DBCopreterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAcceso> TAcceso { get; set; } = null!;
        public virtual DbSet<TAdenda> TAdenda { get; set; } = null!;
        public virtual DbSet<TCita> TCita { get; set; } = null!;
        public virtual DbSet<TCotizacion> TCotizacion { get; set; } = null!;
        public virtual DbSet<TCotizacionxUnidad> TCotizacionxUnidad { get; set; } = null!;
        public virtual DbSet<TEstadoCotizacion> TEstadoCotizacion { get; set; } = null!;
        public virtual DbSet<TEstadoObra> TEstadoObra { get; set; } = null!;
        public virtual DbSet<TEstadoPedido> TEstadoPedido { get; set; } = null!;
        public virtual DbSet<TEstadoTrabajador> TEstadoTrabajador { get; set; } = null!;
        public virtual DbSet<TEstadoUnidad> TEstadoUnidad { get; set; } = null!;
        public virtual DbSet<TFactura> TFactura { get; set; } = null!;
        public virtual DbSet<TIncidencia> TIncidencia { get; set; } = null!;
        public virtual DbSet<TObra> TObra { get; set; } = null!;
        public virtual DbSet<TObraxPartida> TObraxPartida { get; set; } = null!;
        public virtual DbSet<TOrdenServicio> TOrdenServicio { get; set; } = null!;
        public virtual DbSet<TPago> TPago { get; set; } = null!;
        public virtual DbSet<TPartida> TPartida { get; set; } = null!;
        public virtual DbSet<TPedido> TPedido { get; set; } = null!;
        public virtual DbSet<TRol> TRol { get; set; } = null!;
        public virtual DbSet<TTipoPartida> TTipoPartida { get; set; } = null!;
        public virtual DbSet<TTipoTrabajador> TTipoTrabajador { get; set; } = null!;
        public virtual DbSet<TTipoUnidad> TTipoUnidad { get; set; } = null!;
        public virtual DbSet<TTrabajador> TTrabajador { get; set; } = null!;
        public virtual DbSet<TTrabajadorxCotizacion> TTrabajadorxCotizacion { get; set; } = null!;
        public virtual DbSet<TUnidad> TUnidad { get; set; } = null!;
        public virtual DbSet<TUsuario> TUsuario { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=ConnectionStrings:DatabaseConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAcceso>(entity =>
            {
                entity.ToTable("T_Acceso");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.Contrasenya).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.TAcceso)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Acceso_T_Rol");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TAcceso)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Acceso_To_Usuario");
            });

            modelBuilder.Entity<TAdenda>(entity =>
            {
                entity.ToTable("T_Adenda");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdPedido).HasColumnName("Id_Pedido");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Imagen).IsUnicode(false);

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.TAdenda)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Adenda_To_Orden");
            });

            modelBuilder.Entity<TCita>(entity =>
            {
                entity.ToTable("T_Cita");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Hora).HasMaxLength(50);

                entity.Property(e => e.IdObra).HasColumnName("Id_Obra");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Lugar)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdObraNavigation)
                    .WithMany(p => p.TCita)
                    .HasForeignKey(d => d.IdObra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Cita_T_Obra");
            });

            modelBuilder.Entity<TCotizacion>(entity =>
            {
                entity.ToTable("T_Cotizacion");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEstadoCotizacion).HasColumnName("Id_EstadoCotizacion");

                entity.Property(e => e.IdObra).HasColumnName("Id_Obra");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdEstadoCotizacionNavigation)
                    .WithMany(p => p.TCotizacion)
                    .HasForeignKey(d => d.IdEstadoCotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Cotizacion_T_EstadoCotizacion");

                entity.HasOne(d => d.IdObraNavigation)
                    .WithMany(p => p.TCotizacion)
                    .HasForeignKey(d => d.IdObra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Cotizacion_T_Obra");
            });

            modelBuilder.Entity<TCotizacionxUnidad>(entity =>
            {
                entity.ToTable("T_CotizacionxUnidad");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCotizacion).HasColumnName("Id_Cotizacion");

                entity.Property(e => e.IdUnidad).HasColumnName("Id_Unidad");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdCotizacionNavigation)
                    .WithMany(p => p.TCotizacionxUnidad)
                    .HasForeignKey(d => d.IdCotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_CotizacionxUnidad_T_Cotizacion");

                entity.HasOne(d => d.IdUnidadNavigation)
                    .WithMany(p => p.TCotizacionxUnidad)
                    .HasForeignKey(d => d.IdUnidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_CotizacionxUnidad_T_Unidad");
            });

            modelBuilder.Entity<TEstadoCotizacion>(entity =>
            {
                entity.ToTable("T_EstadoCotizacion");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<TEstadoObra>(entity =>
            {
                entity.ToTable("T_EstadoObra");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<TEstadoPedido>(entity =>
            {
                entity.ToTable("T_EstadoPedido");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<TEstadoTrabajador>(entity =>
            {
                entity.ToTable("T_EstadoTrabajador");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre).HasMaxLength(200);
            });

            modelBuilder.Entity<TEstadoUnidad>(entity =>
            {
                entity.ToTable("T_EstadoUnidad");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre).HasMaxLength(200);
            });

            modelBuilder.Entity<TFactura>(entity =>
            {
                entity.ToTable("T_Factura");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCotizacion).HasColumnName("Id_Cotizacion");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Imagen)
                    .IsUnicode(false)
                    .HasColumnName("imagen");

                entity.HasOne(d => d.IdCotizacionNavigation)
                    .WithMany(p => p.TFactura)
                    .HasForeignKey(d => d.IdCotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Factura_T_Cotizacion");
            });

            modelBuilder.Entity<TIncidencia>(entity =>
            {
                entity.ToTable("T_Incidencia");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HorasTrabajadas).HasColumnName("Horas_Trabajadas");

                entity.Property(e => e.IdPedido).HasColumnName("Id_Pedido");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.TIncidencia)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Incidencia_T_Pedido");
            });

            modelBuilder.Entity<TObra>(entity =>
            {
                entity.ToTable("T_Obra");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.Direccion).HasMaxLength(500);

                entity.Property(e => e.DuracionObra).HasColumnName("Duracion_Obra");

                entity.Property(e => e.Empresa).HasMaxLength(500);

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Inicio");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEstadoObra)
                    .HasColumnName("Id_Estado_Obra")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Imagen).IsUnicode(false);

                entity.Property(e => e.NombreObra)
                    .HasMaxLength(500)
                    .HasColumnName("Nombre_Obra");

                entity.HasOne(d => d.IdEstadoObraNavigation)
                    .WithMany(p => p.TObra)
                    .HasForeignKey(d => d.IdEstadoObra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Obra_T_EstadoObra");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TObra)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Obra_T_Usuario");
            });

            modelBuilder.Entity<TObraxPartida>(entity =>
            {
                entity.ToTable("T_ObraxPartida");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdObra).HasColumnName("Id_Obra");

                entity.Property(e => e.IdPartida).HasColumnName("Id_Partida");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Metrado).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Parcial).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Unidad).HasMaxLength(50);

                entity.HasOne(d => d.IdObraNavigation)
                    .WithMany(p => p.TObraxPartida)
                    .HasForeignKey(d => d.IdObra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_ObraxPartida_T_Obra");

                entity.HasOne(d => d.IdPartidaNavigation)
                    .WithMany(p => p.TObraxPartida)
                    .HasForeignKey(d => d.IdPartida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_ObraxPartida_T_Partida");
            });

            modelBuilder.Entity<TOrdenServicio>(entity =>
            {
                entity.ToTable("T_OrdenServicio");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCotizacion).HasColumnName("Id_Cotizacion");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Imagen).IsUnicode(false);

                entity.Property(e => e.Liquidacion).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdCotizacionNavigation)
                    .WithMany(p => p.TOrdenServicio)
                    .HasForeignKey(d => d.IdCotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_OrdenServicio_T_Cotizacion");
            });

            modelBuilder.Entity<TPago>(entity =>
            {
                entity.ToTable("T_Pago");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCotizacion).HasColumnName("Id_Cotizacion");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Monto).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdCotizacionNavigation)
                    .WithMany(p => p.TPago)
                    .HasForeignKey(d => d.IdCotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Pago_T_Cotizacion");
            });

            modelBuilder.Entity<TPartida>(entity =>
            {
                entity.ToTable("T_Partida");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdTipoPartida).HasColumnName("Id_Tipo_Partida");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PrecioUnidad)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Precio_Unidad");

                entity.HasOne(d => d.IdTipoPartidaNavigation)
                    .WithMany(p => p.TPartida)
                    .HasForeignKey(d => d.IdTipoPartida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Partida_T_TipoPartida");
            });

            modelBuilder.Entity<TPedido>(entity =>
            {
                entity.ToTable("T_Pedido");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.CantidadDias).HasColumnName("Cantidad_Dias");

                entity.Property(e => e.FechaEntrega)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Entrega");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Inicio");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEstadoPedido).HasColumnName("Id_Estado_Pedido");

                entity.Property(e => e.IdTrabajador).HasColumnName("Id_Trabajador");

                entity.Property(e => e.IdUnidad).HasColumnName("Id_Unidad");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PrecioPedido)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Precio_Pedido");

                entity.HasOne(d => d.IdEstadoPedidoNavigation)
                    .WithMany(p => p.TPedido)
                    .HasForeignKey(d => d.IdEstadoPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Pedido_T_EstadoPedido");

                entity.HasOne(d => d.IdTrabajadorNavigation)
                    .WithMany(p => p.TPedido)
                    .HasForeignKey(d => d.IdTrabajador)
                    .HasConstraintName("FK_T_Pedido_T_Trabajador");

                entity.HasOne(d => d.IdUnidadNavigation)
                    .WithMany(p => p.TPedido)
                    .HasForeignKey(d => d.IdUnidad)
                    .HasConstraintName("FK_T_Pedido_T_Unidad");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TPedido)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Pedido_T_Usuario1");
            });

            modelBuilder.Entity<TRol>(entity =>
            {
                entity.ToTable("T_Rol");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre).HasMaxLength(200);
            });

            modelBuilder.Entity<TTipoPartida>(entity =>
            {
                entity.ToTable("T_TipoPartida");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre).HasMaxLength(200);
            });

            modelBuilder.Entity<TTipoTrabajador>(entity =>
            {
                entity.ToTable("T_TipoTrabajador");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre).HasMaxLength(200);
            });

            modelBuilder.Entity<TTipoUnidad>(entity =>
            {
                entity.ToTable("T_TipoUnidad");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre).HasMaxLength(200);
            });

            modelBuilder.Entity<TTrabajador>(entity =>
            {
                entity.ToTable("T_Trabajador");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apellido).HasMaxLength(200);

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEstadoTrabajador).HasColumnName("Id_Estado_Trabajador");

                entity.Property(e => e.IdTipoTrabajador).HasColumnName("Id_Tipo_Trabajador");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre).HasMaxLength(200);

                entity.HasOne(d => d.IdEstadoTrabajadorNavigation)
                    .WithMany(p => p.TTrabajador)
                    .HasForeignKey(d => d.IdEstadoTrabajador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Trabajador_T_EstadoTrabajador");

                entity.HasOne(d => d.IdTipoTrabajadorNavigation)
                    .WithMany(p => p.TTrabajador)
                    .HasForeignKey(d => d.IdTipoTrabajador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Trabajador_T_TipoTrabajador");
            });

            modelBuilder.Entity<TTrabajadorxCotizacion>(entity =>
            {
                entity.ToTable("T_TrabajadorxCotizacion");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCotizacion).HasColumnName("Id_Cotizacion");

                entity.Property(e => e.IdTrabajador).HasColumnName("Id_Trabajador");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdCotizacionNavigation)
                    .WithMany(p => p.TTrabajadorxCotizacion)
                    .HasForeignKey(d => d.IdCotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_TrabajadorxCotizacion_T_Cotizacion");

                entity.HasOne(d => d.IdTrabajadorNavigation)
                    .WithMany(p => p.TTrabajadorxCotizacion)
                    .HasForeignKey(d => d.IdTrabajador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_TrabajadorxCotizacion_T_Trabajador");
            });

            modelBuilder.Entity<TUnidad>(entity =>
            {
                entity.ToTable("T_Unidad");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.Caracteristica1).HasMaxLength(500);

                entity.Property(e => e.Caracteristica2).HasMaxLength(500);

                entity.Property(e => e.Caracteristica3).HasMaxLength(500);

                entity.Property(e => e.Descripcion).HasMaxLength(500);

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEstadoUnidad).HasColumnName("Id_Estado_Unidad");

                entity.Property(e => e.IdTipoUnidad).HasColumnName("Id_Tipo_Unidad");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Imagen).IsUnicode(false);

                entity.Property(e => e.Marca).HasMaxLength(100);

                entity.Property(e => e.Modelo).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Serie).HasMaxLength(100);

                entity.HasOne(d => d.IdEstadoUnidadNavigation)
                    .WithMany(p => p.TUnidad)
                    .HasForeignKey(d => d.IdEstadoUnidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Unidad_T_EstadoUnidad");

                entity.HasOne(d => d.IdTipoUnidadNavigation)
                    .WithMany(p => p.TUnidad)
                    .HasForeignKey(d => d.IdTipoUnidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Unidad_T_TipoUnidad");
            });

            modelBuilder.Entity<TUsuario>(entity =>
            {
                entity.ToTable("T_Usuario");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apellido).HasMaxLength(100);

                entity.Property(e => e.Borrado).HasColumnName("BORRADO");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("ID_USUARIO_MODIFICACION");

                entity.Property(e => e.IdUsuarioRegistro)
                    .HasColumnName("ID_USUARIO_REGISTRO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
