using Application.Common.Behaviours;
using Application.Common.Interfaces.Services;
using Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, typeof(ConfigureServices).Assembly);
            
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });

            services.AddScoped<IAuctionBidService, AuctionBidService>();
           
            services.AddScoped<IUserService, UserService>();
           
            services.AddScoped<IAuctionService, AuctionService>();
           
            services.AddScoped<ILotService, LotService>();
           
            return services;
        }
    }
}
