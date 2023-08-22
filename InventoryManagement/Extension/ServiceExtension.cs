using InventoryManagement.Data;
using InventoryManagement.Extension.Logger;
using InventoryManagement.Repository;
using InventoryManagement.Repository.Contracts;
using InventoryManagement.Services;
using InventoryManagement.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:MyWorldDbConnection"];
            services.AddDbContext<IMDbContext>(o => o.UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString)));
        }

        //repository injection
        public static void ConfigureRepository(this IServiceCollection services) =>
            services.AddScoped<IIMDbRepository, IMDbRepository>();

        //service injection
        public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

    }
}

