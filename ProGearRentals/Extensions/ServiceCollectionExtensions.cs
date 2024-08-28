using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Services.Equipment;
using ProGearRentals.Infrastructure.Data;
using ProGearRentals.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEquipmentService,EquipmentService>();   
            return services;     
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ProGearRentalsDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services,IConfiguration config)
        {
           services.AddDefaultIdentity<IdentityUser>(options =>
           {
               options.SignIn.RequireConfirmedAccount = false;
               options.Password.RequireNonAlphanumeric = false;
               options.Password.RequireDigit = false;
               options.Password.RequireLowercase = false;
               options.Password.RequireUppercase = false;
           }).AddEntityFrameworkStores<ProGearRentalsDbContext>();
               

           


            return services;
        }




    }
}
