using Copreter.Domain.Model.Constant;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Copreter.Domain.Model;

namespace Copreter.Domain.Service
{
    public static class DIContext
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IAuthService, AuthService>();

            services.AddCustomRepositories(configuration.GetConnectionString(ConfigKeys.DatabaseConnection));
        }
    }
}
