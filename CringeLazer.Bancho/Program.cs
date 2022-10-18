using CringeLazer.Application.Database;
using CringeLazer.Application.Services;
using CringeLazer.Core.Services;
using CringeLazer.Core.Settings;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen().AddSwaggerGenNewtonsoftSupport();
var connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));
builder.Services.AddDbContext<CringeContext>(
    o => o.UseNpgsql(connectionString,
    op => op.MigrationsAssembly(typeof(Program).Assembly.FullName)));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));

builder.Services.AddTransient<IAuthorizationService, AuthorizationService>();
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CringeContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
