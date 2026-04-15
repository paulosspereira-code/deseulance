using Application.Common.Interfaces.Services;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuctionBidService, AuctionBidService>();
           
            services.AddScoped<IUserService, UserService>();
           
            services.AddScoped<IAuctionService, AuctionService>();
           
            services.AddScoped<ILotService, LotService>();
           
            return services;
        }
    }
}
