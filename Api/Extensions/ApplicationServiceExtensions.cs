using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Repository.Implementation;
using Api.Repository.Interface;
using Api.Helpers;

namespace Api.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("DBConnection"));
        });
        return services;
    }
}