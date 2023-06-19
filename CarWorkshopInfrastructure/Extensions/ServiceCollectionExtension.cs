using CarWorkshopDomain.Interfaces;
using CarWorkshopInfrastructure.Persistence;
using CarWorkshopInfrastructure.Repositories;
using CarWorkshopInfrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshopInfrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarWorkshopDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("CarWorkshop")));

            services.AddScoped<CarWorkshopSeeder>();

            services.AddScoped<ICarWorkshopRepository, CarWorkshopRepository>();
        }
    }
}
