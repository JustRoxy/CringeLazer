global using FastEndpoints;
global using FastEndpoints.Security;
using System.Text.Json;
using System.Text.Json.Serialization;
using CringeLazer.Bancho;
using FastEndpoints.Swagger;
using JorgeSerrano.Json;
using MongoDB.Driver;
using MongoDB.Entities;
using Newtonsoft.Json.Converters;

async Task<WebApplication> Startup()
{
    var builder = WebApplication.CreateBuilder();
    var settings = builder.Configuration.Get<Settings>();

    builder.Services.Configure<Settings>(builder.Configuration);
    builder.Services.AddFastEndpoints();
    builder.Services.AddAuthenticationJWTBearer(settings.Token.SigningKey); //add this
    builder.Services.AddSwaggerDoc();
    await DB.InitAsync("cringe-lazer",
        MongoClientSettings.FromConnectionString(settings.Database.MongoDbConnectionString));

    return builder.Build();
}


var app = await Startup();

app.UseAuthentication();

app.UseAuthorization();
app.UseFastEndpoints(c =>
{
    c.SerializerOptions = s =>
    {
        s.Converters.Add(new JsonStringEnumConverter(new JsonSnakeCaseNamingPolicy()));
        s.PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy();
    };
});

app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());
app.Run();
