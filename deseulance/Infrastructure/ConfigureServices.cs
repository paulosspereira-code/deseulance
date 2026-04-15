using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuctionBidRepository, AuctionBidRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuctionRepository, AuctionRepository>();
            services.AddScoped<ILotRepository, LotRepository>();
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<DeseulanceDbContext>());
            return services;
        }
    }
}
