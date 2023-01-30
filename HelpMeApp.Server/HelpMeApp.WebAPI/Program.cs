using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using HelpMeApp.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HelpMeDbContext>(opts =>
{
    var connectionString = builder.Configuration.GetConnectionString("MyConnectionString");
    opts.UseSqlServer(connectionString);
});

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
