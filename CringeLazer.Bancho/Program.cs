using System.Reflection;
using System.Text;
using CringeLazer.Application.Database;
using CringeLazer.Application.Services;
using CringeLazer.Bancho.Hubs;
using CringeLazer.Bancho.Middlewares;
using CringeLazer.Core.Services;
using CringeLazer.Core.Settings;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = "cringelazer",
            ValidAudience = "osu",
            ValidateAudience = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Settings:AuthorizationKey"])),
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });
builder.Services.AddControllers().AddNewtonsoftJson(o =>
{
    o.SerializerSettings.Converters.Add(new StringEnumConverter(typeof(SnakeCaseNamingStrategy)));
    o.SerializerSettings.ContractResolver = new DefaultContractResolver
    {
        NamingStrategy = new SnakeCaseNamingStrategy
        {
            ProcessDictionaryKeys = true
        }
    };
});

builder.Services.AddSignalR().AddMessagePackProtocol();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo() { Title = "CringeLazer API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
}).AddSwaggerGenNewtonsoftSupport();

builder.Services.AddTransient<OnlineMiddleware>();

var connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));
builder.Services.AddDbContext<CringeContext>(
    o => o.UseNpgsql(connectionString,
        op => op.MigrationsAssembly(typeof(Program).Assembly.FullName)));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));
TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IAuthorizationService, AuthorizationService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddMemoryCache();
builder.Services.AddTransient<IOnlineUsers, OnlineUsers>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CringeContext>();
    context.Database.Migrate();

    using (var conn = (NpgsqlConnection) context.Database.GetDbConnection())
    {
        conn.Open();
        conn.ReloadTypes();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<OnlineMiddleware>();

app.MapHub<SpectatorHub>("/spectator");
app.MapHub<MultiplayerHub>("/multiplayer");
app.MapHub<MetadataHub>("/metadata");

app.MapControllers();

app.Run();
