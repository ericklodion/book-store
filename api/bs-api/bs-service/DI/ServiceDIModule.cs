
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_domain.DI
{
    public static class ServiceDIModule
    {
        public static IServiceCollection AddServiceModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAppDbContext(configuration);

            return services;
        }
    }
}
