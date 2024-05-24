using Bookify.Application.Abstraction.Data;
using Bookify.Application.Abstraction.Email;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Entities.Apratment;
using Bookify.Domain.Entities.Booking;
using Bookify.Infrastructure.Data;
using Bookify.Infrastructure.EmailService;
using Bookify.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Bookify.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddTransient<IEmailService, EmailService.EmailService>();

            var connectionString = configuration.GetConnectionString("Database") ??
                throw new ArgumentNullException(nameof(configuration));
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
            }

            );

            services.AddScoped<IApartmentRepository,ApartmentRepository>();

            services.AddScoped<IBookingRepository,BookingRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));
            
            return services;
        }

    }
}
