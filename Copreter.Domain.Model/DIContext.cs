using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Repository;
using Copreter.Domain.Model.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Copreter.Domain.Model
{
    public static class DIContext
    {
        public static void AddCustomRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CopreterContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICopreterData, CopreterData>();
        }
    }
}
