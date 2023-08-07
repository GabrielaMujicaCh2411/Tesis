using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Copreter.Domain.Model.DbModel
{
    public partial class CopreterContext : DbContext
    {
        public CopreterContext()
        {
        }

        public CopreterContext(DbContextOptions<CopreterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TCita> TCita { get; set; } = null!;
        public virtual DbSet<TCliente> TCliente { get; set; } = null!;
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
            modelBuilder.Entity<TCita>(entity =>
            {
                entity.HasKey(e => e.IdCita);

                entity.ToTable("T_Cita");

                entity.Property(e => e.IdCita)
                    .HasMaxLength(100)
                    .HasColumnName("id_Cita");

                entity.Property(e => e.FechaCita)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_Cita");

                entity.Property(e => e.HoraCita)
                    .HasMaxLength(50)
                    .HasColumnName("hora_Cita");

                entity.Property(e => e.IdObraCita)
                    .HasMaxLength(50)
                    .HasColumnName("id_Obra_Cita");

                entity.Property(e => e.LugarCita)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("lugar_Cita");

                entity.HasOne(d => d.IdObraCitaNavigation)
                    .WithMany(p => p.TCita)
                    .HasForeignKey(d => d.IdObraCita)
                    .HasConstraintName("FK_T_Cita_T_Obra");
            });

            modelBuilder.Entity<TCliente>(entity =>
            {
                entity.HasKey(e => e.Dni);

                entity.ToTable("T_Cliente");

                entity.Property(e => e.Dni)
                    .ValueGeneratedNever()
                    .HasColumnName("dni");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .HasColumnName("apellido");

                entity.Property(e => e.Celular).HasColumnName("celular");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TCotizacion>(entity =>
            {
                entity.HasKey(e => e.IdCotizacion);

                entity.ToTable("T_Cotizacion");

                entity.Property(e => e.IdCotizacion)
                    .HasMaxLength(200)
                    .HasColumnName("id_Cotizacion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdCotizacionEstado).HasColumnName("id_Cotizacion_Estado");

                entity.Property(e => e.IdObraCotizacion)
                    .HasMaxLength(50)
                    .HasColumnName("id_Obra_Cotizacion");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdCotizacionEstadoNavigation)
                    .WithMany(p => p.TCotizacion)
                    .HasForeignKey(d => d.IdCotizacionEstado)
                    .HasConstraintName("FK_T_Cotizacion_T_EstadoCotizacion");

                entity.HasOne(d => d.IdObraCotizacionNavigation)
                    .WithMany(p => p.TCotizacion)
                    .HasForeignKey(d => d.IdObraCotizacion)
                    .HasConstraintName("FK_T_Cotizacion_T_Obra");

                entity.HasMany(d => d.DniTrabajador)
                    .WithMany(p => p.IdCotizacion)
                    .UsingEntity<Dictionary<string, object>>(
                        "TTrabajadorxCotizacion",
                        l => l.HasOne<TTrabajador>().WithMany().HasForeignKey("DniTrabajador").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_T_TrabajadorxCotizacion_T_Trabajador"),
                        r => r.HasOne<TCotizacion>().WithMany().HasForeignKey("IdCotizacion").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_T_TrabajadorxCotizacion_T_Cotizacion"),
                        j =>
                        {
                            j.HasKey("IdCotizacion", "DniTrabajador");

                            j.ToTable("T_TrabajadorxCotizacion");

                            j.IndexerProperty<string>("IdCotizacion").HasMaxLength(200).HasColumnName("id_Cotizacion");

                            j.IndexerProperty<int>("DniTrabajador").HasColumnName("dni_Trabajador");
                        });
            });

            modelBuilder.Entity<TCotizacionxUnidad>(entity =>
            {
                entity.HasKey(e => new { e.IdSerie, e.IdCotizacion });

                entity.ToTable("T_CotizacionxUnidad");

                entity.Property(e => e.IdSerie)
                    .HasMaxLength(100)
                    .HasColumnName("id_Serie");

                entity.Property(e => e.IdCotizacion)
                    .HasMaxLength(200)
                    .HasColumnName("id_Cotizacion");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.HasOne(d => d.IdCotizacionNavigation)
                    .WithMany(p => p.TCotizacionxUnidad)
                    .HasForeignKey(d => d.IdCotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_CotizacionxUnidad_T_Cotizacion");

                entity.HasOne(d => d.IdSerieNavigation)
                    .WithMany(p => p.TCotizacionxUnidad)
                    .HasForeignKey(d => d.IdSerie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_CotizacionxUnidad_T_Unidad");
            });

            modelBuilder.Entity<TEstadoCotizacion>(entity =>
            {
                entity.HasKey(e => e.IdEstadoCotizacion);

                entity.ToTable("T_EstadoCotizacion");

                entity.Property(e => e.IdEstadoCotizacion).HasColumnName("id_Estado_Cotizacion");

                entity.Property(e => e.DescripcionEstadoCotizacion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion_Estado_Cotizacion");

                entity.Property(e => e.NombreEstadoCotizacion)
                    .HasMaxLength(100)
                    .HasColumnName("nombre_Estado_Cotizacion");
            });

            modelBuilder.Entity<TEstadoObra>(entity =>
            {
                entity.HasKey(e => e.IdEstadoObra);

                entity.ToTable("T_EstadoObra");

                entity.Property(e => e.IdEstadoObra).HasColumnName("id_EstadoObra");

                entity.Property(e => e.DescripcionEstadoObra)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion_Estado_Obra");

                entity.Property(e => e.NombreEstadoObra)
                    .HasMaxLength(100)
                    .HasColumnName("nombre_Estado_Obra");
            });

            modelBuilder.Entity<TEstadoPedido>(entity =>
            {
                entity.HasKey(e => e.IdEstadoPedido);

                entity.ToTable("T_EstadoPedido");

                entity.Property(e => e.IdEstadoPedido).HasColumnName("id_Estado_Pedido");

                entity.Property(e => e.DescripcionEstadoPedido).HasColumnName("descripcion_Estado_Pedido");

                entity.Property(e => e.NombreEstadoPedido)
                    .HasMaxLength(100)
                    .HasColumnName("nombre_Estado_Pedido");
            });

            modelBuilder.Entity<TEstadoTrabajador>(entity =>
            {
                entity.HasKey(e => e.IdEstadoTrabajador);

                entity.ToTable("T_EstadoTrabajador");

                entity.Property(e => e.IdEstadoTrabajador).HasColumnName("id_Estado_Trabajador");

                entity.Property(e => e.DescripcionEstadoTrabajador)
                    .HasMaxLength(500)
                    .HasColumnName("descripcionEstadoTrabajador");

                entity.Property(e => e.NombreEstadoTrabajador)
                    .HasMaxLength(200)
                    .HasColumnName("nombre_Estado_Trabajador");
            });

            modelBuilder.Entity<TEstadoUnidad>(entity =>
            {
                entity.HasKey(e => e.IdEstadoUnidad);

                entity.ToTable("T_EstadoUnidad");

                entity.Property(e => e.IdEstadoUnidad).HasColumnName("id_Estado_Unidad");

                entity.Property(e => e.DescripcionEstadoUnidad)
                    .HasMaxLength(500)
                    .HasColumnName("descripcion_Estado_Unidad");

                entity.Property(e => e.NombreEstadoUnidad)
                    .HasMaxLength(200)
                    .HasColumnName("nombre_Estado_Unidad");
            });

            modelBuilder.Entity<TFactura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.ToTable("T_Factura");

                entity.Property(e => e.IdFactura)
                    .HasMaxLength(50)
                    .HasColumnName("id_Factura");

                entity.Property(e => e.IdCotizacionFactura)
                    .HasMaxLength(200)
                    .HasColumnName("id_Cotizacion_Factura");

                entity.Property(e => e.Imagen)
                    .IsUnicode(false)
                    .HasColumnName("imagen");

                entity.HasOne(d => d.IdCotizacionFacturaNavigation)
                    .WithMany(p => p.TFactura)
                    .HasForeignKey(d => d.IdCotizacionFactura)
                    .HasConstraintName("FK_T_Factura_T_Cotizacion");
            });

            modelBuilder.Entity<TIncidencia>(entity =>
            {
                entity.HasKey(e => e.IdIncidencia);

                entity.ToTable("T_Incidencia");

                entity.Property(e => e.IdIncidencia)
                    .HasMaxLength(50)
                    .HasColumnName("id_Incidencia");

                entity.Property(e => e.FechaHorario)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_Horario");

                entity.Property(e => e.HorasTrabajadas).HasColumnName("horas_Trabajadas");

                entity.Property(e => e.IdPedidoIncidencia)
                    .HasMaxLength(50)
                    .HasColumnName("id_Pedido_Incidencia");

                entity.Property(e => e.Incidencia).HasColumnName("incidencia");

                entity.HasOne(d => d.IdPedidoIncidenciaNavigation)
                    .WithMany(p => p.TIncidencia)
                    .HasForeignKey(d => d.IdPedidoIncidencia)
                    .HasConstraintName("FK_T_Incidencia_T_Pedido");
            });

            modelBuilder.Entity<TObra>(entity =>
            {
                entity.HasKey(e => e.IdObra);

                entity.ToTable("T_Obra");

                entity.Property(e => e.IdObra)
                    .HasMaxLength(50)
                    .HasColumnName("id_Obra");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .HasColumnName("direccion");

                entity.Property(e => e.DuracionObra).HasColumnName("duracion_Obra");

                entity.Property(e => e.Empresa)
                    .HasMaxLength(500)
                    .HasColumnName("empresa");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_Inicio");

                entity.Property(e => e.IdObraEstado).HasColumnName("id_Obra_Estado");

                entity.Property(e => e.IdUsuarioObra)
                    .HasMaxLength(100)
                    .HasColumnName("id_Usuario_Obra");

                entity.Property(e => e.Imagen)
                    .IsUnicode(false)
                    .HasColumnName("imagen");

                entity.Property(e => e.NombreObra)
                    .HasMaxLength(500)
                    .HasColumnName("nombre_Obra");

                entity.HasOne(d => d.IdObraEstadoNavigation)
                    .WithMany(p => p.TObra)
                    .HasForeignKey(d => d.IdObraEstado)
                    .HasConstraintName("FK_T_Obra_T_EstadoObra");

                entity.HasOne(d => d.IdUsuarioObraNavigation)
                    .WithMany(p => p.TObra)
                    .HasForeignKey(d => d.IdUsuarioObra)
                    .HasConstraintName("FK_T_Obra_T_Usuario");
            });

            modelBuilder.Entity<TObraxPartida>(entity =>
            {
                entity.HasKey(e => new { e.IdPartida, e.IdObra });

                entity.ToTable("T_ObraxPartida");

                entity.Property(e => e.IdPartida)
                    .HasMaxLength(50)
                    .HasColumnName("id_Partida");

                entity.Property(e => e.IdObra)
                    .HasMaxLength(50)
                    .HasColumnName("id_Obra");

                entity.Property(e => e.Metrado)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("metrado");

                entity.Property(e => e.Parcial)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("parcial");

                entity.Property(e => e.Unidad)
                    .HasMaxLength(50)
                    .HasColumnName("unidad");

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
                entity.HasKey(e => e.IdOrden);

                entity.ToTable("T_OrdenServicio");

                entity.Property(e => e.IdOrden)
                    .HasMaxLength(50)
                    .HasColumnName("id_Orden");

                entity.Property(e => e.FechaOrden)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_Orden");

                entity.Property(e => e.IdPedidoOrden)
                    .HasMaxLength(50)
                    .HasColumnName("id_Pedido_Orden");

                entity.Property(e => e.Liquidacion)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("liquidacion");

                entity.HasOne(d => d.IdPedidoOrdenNavigation)
                    .WithMany(p => p.TOrdenServicio)
                    .HasForeignKey(d => d.IdPedidoOrden)
                    .HasConstraintName("FK_T_OrdenServicio_T_Pedido");
            });

            modelBuilder.Entity<TPago>(entity =>
            {
                entity.HasKey(e => e.IdPago);

                entity.ToTable("T_Pago");

                entity.Property(e => e.IdPago)
                    .HasMaxLength(200)
                    .HasColumnName("id_Pago");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdCotizacionPago)
                    .HasMaxLength(200)
                    .HasColumnName("id_Cotizacion_Pago");

                entity.Property(e => e.Pago1)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("pago1");

                entity.Property(e => e.Pago2)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("pago2");

                entity.HasOne(d => d.IdCotizacionPagoNavigation)
                    .WithMany(p => p.TPago)
                    .HasForeignKey(d => d.IdCotizacionPago)
                    .HasConstraintName("FK_T_Pago_T_Cotizacion");
            });

            modelBuilder.Entity<TPartida>(entity =>
            {
                entity.HasKey(e => e.IdPartida);

                entity.ToTable("T_Partida");

                entity.Property(e => e.IdPartida)
                    .HasMaxLength(50)
                    .HasColumnName("id_Partida");

                entity.Property(e => e.IdTipoPartida).HasColumnName("id_Tipo_Partida");

                entity.Property(e => e.NombrePartida).HasColumnName("nombre_Partida");

                entity.Property(e => e.PrecioUnidad)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("precio_Unidad");

                entity.HasOne(d => d.IdTipoPartidaNavigation)
                    .WithMany(p => p.TPartida)
                    .HasForeignKey(d => d.IdTipoPartida)
                    .HasConstraintName("FK_T_Partida_T_TipoPartida");
            });

            modelBuilder.Entity<TPedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido);

                entity.ToTable("T_Pedido");

                entity.Property(e => e.IdPedido)
                    .HasMaxLength(50)
                    .HasColumnName("id_Pedido");

                entity.Property(e => e.CantidadDias).HasColumnName("cantidad_Dias");

                entity.Property(e => e.Empresa).HasColumnName("empresa");

                entity.Property(e => e.FechaEntrega)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_Entrega");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_Inicio");

                entity.Property(e => e.IdEstadoPedido).HasColumnName("id_Estado_Pedido");

                entity.Property(e => e.IdTrabajadorPedido).HasColumnName("id_Trabajador_Pedido");

                entity.Property(e => e.IdUnidadPedido)
                    .HasMaxLength(100)
                    .HasColumnName("id_Unidad_Pedido");

                entity.Property(e => e.IdUsuarioPedido)
                    .HasMaxLength(100)
                    .HasColumnName("id_Usuario_Pedido");

                entity.Property(e => e.Obra).HasColumnName("obra");

                entity.Property(e => e.PrecioPedido)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("precio_Pedido");

                entity.Property(e => e.Ubicacion).HasColumnName("ubicacion");

                entity.HasOne(d => d.IdEstadoPedidoNavigation)
                    .WithMany(p => p.TPedido)
                    .HasForeignKey(d => d.IdEstadoPedido)
                    .HasConstraintName("FK_T_Pedido_T_EstadoPedido");

                entity.HasOne(d => d.IdTrabajadorPedidoNavigation)
                    .WithMany(p => p.TPedido)
                    .HasForeignKey(d => d.IdTrabajadorPedido)
                    .HasConstraintName("FK_T_Pedido_T_Trabajador");

                entity.HasOne(d => d.IdUnidadPedidoNavigation)
                    .WithMany(p => p.TPedido)
                    .HasForeignKey(d => d.IdUnidadPedido)
                    .HasConstraintName("FK_T_Pedido_T_Unidad");

                entity.HasOne(d => d.IdUsuarioPedidoNavigation)
                    .WithMany(p => p.TPedido)
                    .HasForeignKey(d => d.IdUsuarioPedido)
                    .HasConstraintName("FK_T_Pedido_T_Usuario1");
            });

            modelBuilder.Entity<TRol>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("T_Rol");

                entity.Property(e => e.IdRol).HasColumnName("id_Rol");

                entity.Property(e => e.DescripcionRol)
                    .HasMaxLength(500)
                    .HasColumnName("descripcion_Rol");

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(200)
                    .HasColumnName("nombre_Rol");
            });

            modelBuilder.Entity<TTipoPartida>(entity =>
            {
                entity.HasKey(e => e.IdTipoPartida);

                entity.ToTable("T_TipoPartida");

                entity.Property(e => e.IdTipoPartida).HasColumnName("id_Tipo_Partida");

                entity.Property(e => e.DescripcionTipoPartida)
                    .HasMaxLength(500)
                    .HasColumnName("descripcion_Tipo_Partida");

                entity.Property(e => e.NombreTipoPartida)
                    .HasMaxLength(200)
                    .HasColumnName("nombre_Tipo_Partida");
            });

            modelBuilder.Entity<TTipoTrabajador>(entity =>
            {
                entity.HasKey(e => e.IdTipoTrabajdor);

                entity.ToTable("T_TipoTrabajador");

                entity.Property(e => e.IdTipoTrabajdor).HasColumnName("id_Tipo_Trabajdor");

                entity.Property(e => e.DescripcionTipoTrabajador)
                    .HasMaxLength(500)
                    .HasColumnName("descripcion_Tipo_Trabajador");

                entity.Property(e => e.NombreTipoTrabajador)
                    .HasMaxLength(200)
                    .HasColumnName("nombre_Tipo_Trabajador");
            });

            modelBuilder.Entity<TTipoUnidad>(entity =>
            {
                entity.HasKey(e => e.IdTipoUnidad);

                entity.ToTable("T_TipoUnidad");

                entity.Property(e => e.IdTipoUnidad).HasColumnName("id_Tipo_Unidad");

                entity.Property(e => e.NombreTipoUnidad)
                    .HasMaxLength(200)
                    .HasColumnName("nombre_Tipo_Unidad");
            });

            modelBuilder.Entity<TTrabajador>(entity =>
            {
                entity.HasKey(e => e.Dni);

                entity.ToTable("T_Trabajador");

                entity.Property(e => e.Dni)
                    .ValueGeneratedNever()
                    .HasColumnName("dni");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(200)
                    .HasColumnName("apellido");

                entity.Property(e => e.Celular).HasColumnName("celular");

                entity.Property(e => e.IdEstadoTrabajador).HasColumnName("id_Estado_Trabajador");

                entity.Property(e => e.IdTipoTrabajador).HasColumnName("id_Tipo_Trabajador");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdEstadoTrabajadorNavigation)
                    .WithMany(p => p.TTrabajador)
                    .HasForeignKey(d => d.IdEstadoTrabajador)
                    .HasConstraintName("FK_T_Trabajador_T_EstadoTrabajador");

                entity.HasOne(d => d.IdTipoTrabajadorNavigation)
                    .WithMany(p => p.TTrabajador)
                    .HasForeignKey(d => d.IdTipoTrabajador)
                    .HasConstraintName("FK_T_Trabajador_T_TipoTrabajador");
            });

            modelBuilder.Entity<TUnidad>(entity =>
            {
                entity.HasKey(e => e.Serie);

                entity.ToTable("T_Unidad");

                entity.Property(e => e.Serie)
                    .HasMaxLength(100)
                    .HasColumnName("serie");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Caracteristica1)
                    .HasMaxLength(500)
                    .HasColumnName("caracteristica1");

                entity.Property(e => e.Caracteristica2)
                    .HasMaxLength(500)
                    .HasColumnName("caracteristica2");

                entity.Property(e => e.Caracteristica3)
                    .HasMaxLength(500)
                    .HasColumnName("caracteristica3");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdEstadoUnidad).HasColumnName("id_Estado_Unidad");

                entity.Property(e => e.IdTipoUnidad).HasColumnName("id_Tipo_Unidad");

                entity.Property(e => e.Imagen)
                    .IsUnicode(false)
                    .HasColumnName("imagen");

                entity.Property(e => e.Marca)
                    .HasMaxLength(100)
                    .HasColumnName("marca");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(100)
                    .HasColumnName("modelo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("precio");

                entity.HasOne(d => d.IdEstadoUnidadNavigation)
                    .WithMany(p => p.TUnidad)
                    .HasForeignKey(d => d.IdEstadoUnidad)
                    .HasConstraintName("FK_T_Unidad_T_EstadoUnidad");

                entity.HasOne(d => d.IdTipoUnidadNavigation)
                    .WithMany(p => p.TUnidad)
                    .HasForeignKey(d => d.IdTipoUnidad)
                    .HasConstraintName("FK_T_Unidad_T_TipoUnidad");
            });

            modelBuilder.Entity<TUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("T_Usuario");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(100)
                    .HasColumnName("id_Usuario");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(100)
                    .HasColumnName("contraseña");

                entity.Property(e => e.DniUsuario).HasColumnName("dni_Usuario");

                entity.Property(e => e.IdRolUsuario).HasColumnName("id_Rol_Usuario");

                entity.HasOne(d => d.DniUsuarioNavigation)
                    .WithMany(p => p.TUsuario)
                    .HasForeignKey(d => d.DniUsuario)
                    .HasConstraintName("FK_T_Usuario_T_Cliente");

                entity.HasOne(d => d.IdRolUsuarioNavigation)
                    .WithMany(p => p.TUsuario)
                    .HasForeignKey(d => d.IdRolUsuario)
                    .HasConstraintName("FK_T_Usuario_T_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
