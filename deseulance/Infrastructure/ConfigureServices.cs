using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DeseulanceDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                sqlOptions =>
                {
                    // Essencial para o Docker: tenta conectar várias vezes se o banco estiver subindo
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null);
                }));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<DeseulanceDbContext>());


            services.AddScoped<IAuctionBidRepository, AuctionBidRepository>();
 
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddScoped<IAuctionRepository, AuctionRepository>();
            
            services.AddScoped<ILotRepository, LotRepository>();


            return services;
        }
    }
}
