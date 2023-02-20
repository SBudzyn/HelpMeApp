using System;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using HelpMeApp.DatabaseAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HelpMeApp.WebAPI.ServiceCollectionConfiguration;
using HelpMeApp.DatabaseAccess.Initializers;
using HelpMeApp.WebAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.BindServices();
builder.Services.BindRepositories();
builder.Services.ConfigureMapping();
builder.Services.ConfigureAuthorization();
builder.Services.ConfigureValidation();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureChat();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HelpMeDbContext>(opts =>
{
    var connectionString = builder.Configuration.GetConnectionString("MyConnectionString");
    opts.UseSqlServer(connectionString);
});
builder.Services.AddScoped<DbInitializer>();

builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>
    (options =>
    {
        options.Password.RequireDigit= true;
        options.Password.RequiredLength= 8;
        options.Password.RequireLowercase= true;
        options.Password.RequireUppercase= true;
    }
    )
    .AddEntityFrameworkStores<HelpMeDbContext>();

var app = builder.Build();

app.UseCors(builder => 
{
    builder.WithOrigins("http://localhost:3000");
    builder.SetIsOriginAllowed(origin => true);
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
    builder.AllowCredentials();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseItToSeedSqlServer();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/chat-hub");

app.Run();
