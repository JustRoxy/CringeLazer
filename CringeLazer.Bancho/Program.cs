global using FastEndpoints;
global using FastEndpoints.Security;
using System.Text.Json.Serialization;
using CringeLazer.Bancho;
using CringeLazer.Bancho.Data;
using FastEndpoints.Swagger;
using JorgeSerrano.Json;
using MediatR;
using Microsoft.EntityFrameworkCore;

WebApplication Startup()
{
    var builder = WebApplication.CreateBuilder();
    var settings = builder.Configuration.Get<Settings>();

    builder.Services.Configure<Settings>(builder.Configuration);
    builder.Services.AddFastEndpoints();
    builder.Services.AddAuthenticationJWTBearer(settings.Token.SigningKey); //add this
    builder.Services.AddSwaggerDoc();
    builder.Services.AddSignalR();
    builder.Services.AddMediatR(typeof(Program));

    builder.Services.AddDbContext<CringeContext>(x =>
    {
        x.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
    });


    return builder.Build();
}


var app = Startup();

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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CringeContext>();
    context.Database.EnsureCreated();
}

app.Run();
