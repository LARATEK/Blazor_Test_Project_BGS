using Abstractions;
using Microsoft.EntityFrameworkCore;
using Storage;

namespace BGS;

internal static class StorageExtensions
{
    public static IServiceCollection AddStorage(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDbContext<DatabaseContext>(
                (sp, dbOpt) => 
                dbOpt.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection")))
            .AddScoped<IBoardgameRepository, BoardgameRepository>()
            .AddScoped<IUnitOfWork, UnitOfWork>();
}
