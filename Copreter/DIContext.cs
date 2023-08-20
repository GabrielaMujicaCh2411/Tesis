using Copreter.Domain.Service;

namespace Copreter
{
    public static class DIContext
    {
        public static void AddBaseCopreterServices(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();

            if (configuration != null)
            {
                services.AddCustomServices(configuration);
            }

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
