using Bookify.Domain.Entities.Booking;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection Addapplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
            });

            services.AddTransient<PricingService>();

            return services;
        }
    }
}
