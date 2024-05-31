using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MadWorldNL.HomeFriend.Database;

public static class ServiceProvider
{
    public static void MigrateDatabase<TDbContext>(this IServiceProvider services) where TDbContext : DbContext
    {
        using var serviceScope = services.GetService<IServiceScopeFactory>()!.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<TDbContext>();
        context.Database.Migrate();
    }  
}