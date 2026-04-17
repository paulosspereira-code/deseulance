using API.Converters;
using API.Exceptions;
using API.Features.AuctionBids.Endpoints;
using API.Features.Auctions.Endpoints;
using API.Features.Lots.Endpoints;
using API.Features.Users.Endpoints;
using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new EmptyStringToNullableDateTimeConverter());
});

builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "API deseulance";


    config.AddSecurity("JWT", new NSwag.OpenApiSecurityScheme
    {
        Type = NSwag.OpenApiSecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
    });


    config.OperationProcessors.Add(
        new NSwag.Generation.Processors.Security.AspNetCoreOperationSecurityScopeProcessor("JWT"));
});

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddApplication();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();    
    app.UseSwaggerUi();  
    app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();
}

app.UseHttpsRedirection();

app.MapAuctionEndpoints();
app.MapLotEndpoints();
app.MapUserEndpoints();
app.MapAuctionBidEndpoints();

app.UseExceptionHandler();

app.Run();


