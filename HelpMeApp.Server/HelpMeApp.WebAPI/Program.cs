using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using HelpMeApp.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HelpMeApp.WebAPI.ServiceCollectionConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HelpMeDbContext>(opts =>
{
    var connectionString = builder.Configuration.GetConnectionString("MyConnectionString");
    opts.UseSqlServer(connectionString);
});

builder.Services.AddAuthentication(o =>
{
    o.DefaultScheme = IdentityConstants.ApplicationScheme;
    o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddIdentityCookies(o => { });

builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>
    (options =>
    {
        options.SignIn.RequireConfirmedEmail= true;
        options.SignIn.RequireConfirmedAccount= true;
        options.Password.RequireDigit= true;
        options.Password.RequiredLength= 10;
        options.Password.RequireNonAlphanumeric= true;
        options.Password.RequireLowercase= true;
        options.Password.RequireUppercase= true;
    }
    )
    .AddEntityFrameworkStores<HelpMeDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    app.UseHsts();
//}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();

