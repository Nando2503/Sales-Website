using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Protocol.Plugins;
using System.Linq;
using SalesWebMvc3.Data;
using System.Globalization;
using System.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Protocol.Plugins;
using System.Linq;
using SalesWebMvc3.Data;
using System.Configuration;
using SalesWebMvc3.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SalesWebMvc3Context>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("SalesWebMvc3Context"),
        new MySqlServerVersion(new Version(8, 0, 40)), // Replace with your MySQL version
        mysqlOptions => mysqlOptions.MigrationsAssembly("SalesWebMvc3")
    )
);


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentsService>();

var app = builder.Build();

// Seed data during application startup.
using (var scope = app.Services.CreateScope())
{
    var enUS = new CultureInfo("en-US");
    var Localizationoptions = new RequestLocalizationOptions
    {
        DefaultRequestCulture = new RequestCulture(enUS),
        SupportedCultures = new List<CultureInfo> { enUS },
        SupportedUICultures = new List<CultureInfo> { enUS }
    };
    app.UseRequestLocalization(Localizationoptions);

    var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
    seedingService.Seed();


    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        seedingService.Seed();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();





