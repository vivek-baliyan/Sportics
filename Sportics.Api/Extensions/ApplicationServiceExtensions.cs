using Microsoft.EntityFrameworkCore;
using Sportics.Api.Data;
using Sportics.Api.Repository.Implementation;
using Sportics.Api.Repository.Interface;

namespace Sportics.Api.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("DBConnection"));
        });
        return services;
    }
}