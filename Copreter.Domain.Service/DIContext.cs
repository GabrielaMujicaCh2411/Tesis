﻿using Copreter.Domain.Model.Constant;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Copreter.Domain.Model;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Contracts;

namespace Copreter.Domain.Service
{
    public static class DIContext
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAdendaService, AdendaService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICitaService, CitaService>();
            services.AddScoped<IConfiguracionService, ConfiguracionService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ICotizacionService, CotizacionService>();
            services.AddScoped<ICotizacionxUnidadService, CotizacionxUnidadService>();

            services.AddScoped<IEstadoCotizacionService, EstadoCotizacionService>();
            services.AddScoped<IEstadoObraService, EstadoObraService>();
            services.AddScoped<IEstadoPedidoService, EstadoPedidoService>();
            services.AddScoped<IEstadoTrabajadorService, EstadoTrabajadorService>();
            services.AddScoped<IEstadoUnidadService, EstadoUnidadService>();


            services.AddScoped<IFacturaService, FacturaService>();
            services.AddScoped<IIncidenciaService, IncidenciaService>();
            services.AddScoped<IObraService, ObraService>();
            services.AddScoped<IObraIncidenciaService, ObraIncidenciaService>();
            services.AddScoped<IObraPartidaService, ObraPartidaService>();
            services.AddScoped<IOrdenServicioService, OrdenServicioService>();

            services.AddScoped<IPagoService, PagoService>();
            services.AddScoped<IPartidaService, PartidaService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IPedidoOrdenServicioService, PedidoOrdenServicioService>();
            services.AddScoped<IRolService, RolService>();


            services.AddScoped<ITipoPartidaService, TipoPartidaService>();
            services.AddScoped<ITipoTrabajadorService, TipoTrabajadorService>();
            services.AddScoped<ITipoUnidadService, TipoUnidadService>();

            services.AddScoped<ITrabajadorService, TrabajadorService>();
            services.AddScoped<ITrabajadorxCotizacionService, TrabajadorxCotizacionService>();
            services.AddScoped<IUnidadService, UnidadService>();
            services.AddScoped<IAccesoService, AccesoService>();
            services.AddCustomRepositories(configuration.GetConnectionString(ConfigKeys.DatabaseConnection));
        }
    }
}

