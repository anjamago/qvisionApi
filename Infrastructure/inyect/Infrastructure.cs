using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Bases;
using Persistence.Context;

namespace Infrastructure.Inyect;

public  static class Infrastructure
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibrosContext>(options =>
        {
            options.UseSqlServer(HelperConnection.GetConnectionSQL(configuration), sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(30), null);
                sqlOptions.CommandTimeout(60);
            });
        });

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
    
    }

    public static void AppContextMigrate(this WebApplication app)
    {
        using ( var service = app.Services.CreateScope())
        {
            var context = service.ServiceProvider.GetRequiredService<LibrosContext>();
            context.Database.Migrate();

        }
    }
}