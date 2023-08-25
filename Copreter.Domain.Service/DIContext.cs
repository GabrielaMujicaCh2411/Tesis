using Copreter.Domain.Model.Constant;
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
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICitaService, CitaService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ICotizacionService, CotizacionService>();

            //services.AddScoped<IEstadoCotizacionService, EstadoCotizacionService>();
            services.AddScoped<IEstadoObraService, EstadoObraService>();
            //services.AddScoped<IEstadoPedidoService, EstadoPedidoService>();
            services.AddScoped<IEstadoTrabajadorService, EstadoTrabajadorService>();
            services.AddScoped<IEstadoUnidadService, EstadoUnidadService>();

            
            services.AddScoped<IFacturaService, FacturaService>();
            services.AddScoped<IObraService, ObraService>();
            services.AddScoped<IPagoService, PagoService>();
            services.AddScoped<IPartidaService, PartidaService>();
            services.AddScoped<IPedidoService, PedidoService>();

            services.AddScoped<ITipoPartidaService, TipoPartidaService>();
            services.AddScoped<ITipoTrabajadorService, TipoTrabajadorService>();
            services.AddScoped<ITipoUnidadService, TipoUnidadService>();

            services.AddScoped<ITrabajadorService, TrabajadorService>();
            services.AddScoped<IUnidadService, UnidadService>();
            services.AddScoped<IAccesoService, AccesoService>();
            services.AddCustomRepositories(configuration.GetConnectionString(ConfigKeys.DatabaseConnection));
        }
    }
}

