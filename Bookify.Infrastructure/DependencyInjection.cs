using Bookify.Application.Abstraction.Email;
using Bookify.Infrastructure.EmailService;
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

            return services;
        }

    }
}
