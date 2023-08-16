using DataVisualiser.Data;
using Microsoft.EntityFrameworkCore;
using DevExpress.AspNetCore;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardWeb;
using Microsoft.Extensions.FileProviders;
using DevExpress.XtraCharts;
using DataVisualiser.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

IFileProvider? fileProvider = builder.Environment.ContentRootFileProvider;
IConfiguration? configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddDevExpressControls();
builder.Services.AddScoped<DashboardConfigurator>((IServiceProvider serviceProvider) => {
    DashboardConfigurator configurator = new DashboardConfigurator();
    configurator.SetDashboardStorage(new DashboardFileStorage(fileProvider.GetFileInfo("Data/Dashboards").PhysicalPath));
    configurator.SetConnectionStringsProvider(new DashboardConnectionStringsProvider(configuration));
    return configurator;
});
builder.Services.AddDbContext<DataVisualiserDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDevExpressControls();
app.MapDashboardRoute("api/dashboard", "DefaultDashboard");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
