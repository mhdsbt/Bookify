using Bookify.Application.Abstraction.Behaviors;
using Bookify.Domain.Entities.Booking;
using FluentValidation;
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

                configuration.AddOpenBehavior(typeof(loggingBehavior<,>));

                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);   

            services.AddTransient<PricingService>();


            return services;
        }
    }
}
