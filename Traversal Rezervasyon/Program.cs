using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Containers;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Traversal_Rezervasyon.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Context>();

builder.Services.AddIdentity<AppUser, AppRole>().AddErrorDescriber<ValidationForPassword>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

builder.Services.Containers();

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();

builder.Services.AddControllersWithViews();

builder.Services.AddLogging(x =>
{
    x.ClearProviders();

    x.SetMinimumLevel(LogLevel.Debug);

    x.AddDebug();
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
// Eðer Microsoft.Extensions.Logging.File (veya kullandýðýn AddFile paketi) yüklüyse:
var logsDir = Path.Combine(builder.Environment.ContentRootPath, "Logs");
Directory.CreateDirectory(logsDir);
builder.Logging.AddFile(Path.Combine(logsDir, "app.log")); // veya "log-.txt" paketine göre

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/Admin/_404Pages/Index", "?code{0}");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
