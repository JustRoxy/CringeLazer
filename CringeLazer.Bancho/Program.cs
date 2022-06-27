global using FastEndpoints;
global using FastEndpoints.Security;
using System.Reflection;
using System.Text.Json.Serialization;
using CringeLazer.Bancho;
using CringeLazer.Bancho._Features_.Multiplayer;
using CringeLazer.Bancho._Features_.Spectator;
using CringeLazer.Bancho.Middleware;
using FastEndpoints.Swagger;
using JorgeSerrano.Json;
using Mapster;
using MongoDB.Driver;
using MongoDB.Entities;

async Task<WebApplication> Startup()
{
    var builder = WebApplication.CreateBuilder();
    var settings = builder.Configuration.Get<Settings>();

    builder.Services.Configure<Settings>(builder.Configuration);
    builder.Services.AddFastEndpoints();
    builder.Services.AddAuthenticationJWTBearer(settings.Token.SigningKey); //add this
    builder.Services.AddSwaggerDoc();
    builder.Services.AddSignalR().AddMessagePackProtocol();
    builder.Services.AddScoped<LastVisitMiddleware>();
    TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetEntryAssembly()!);
    await DB.InitAsync("cringelazer",
        MongoClientSettings.FromConnectionString(builder.Configuration.GetConnectionString("Mongo")));

    return builder.Build();
}


var app = await Startup();

app.UseAuthentication();

app.UseAuthorization();

app.MapHub<SpectatorHub>("/spectator");
app.MapHub<MultiplayerHub>("/multiplayer");

app.UseMiddleware<LastVisitMiddleware>();
app.UseFastEndpoints(c =>
{
    c.RoutingOptions = s =>
    {
        s.Prefix = "api/v2";
    };
    c.ErrorResponseBuilder = (failures, statusCode) =>
    {
        var failure = failures.First();

        return new
        {
            error = $"{failure.Severity}.{failure.ErrorCode}",
            error_description = failure.ErrorMessage,
            hint = failure.ErrorMessage, message = failure.ErrorMessage
        };
    };
    c.SerializerOptions = s =>
    {
        s.Converters.Add(new JsonStringEnumConverter(new JsonSnakeCaseNamingPolicy()));
        s.PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy();
    };
});

app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.Run();
