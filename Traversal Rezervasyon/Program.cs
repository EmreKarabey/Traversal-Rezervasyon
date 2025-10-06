using BusinessLayer.Concrete;
using BusinessLayer.Containers;
using BusinessLayer.ValidationRule;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Traversal_Rezervasyon.CRQS.Handlers;
using Traversal_Rezervasyon.Models;

var builder = WebApplication.CreateBuilder(args);

// ---------- Services ----------
builder.Services.AddDbContext<Context>();

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddErrorDescriber<ValidationForPassword>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

builder.Services.Containers();
builder.Services.CustomerValidator();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(typeof(Program));



// Global auth policy
builder.Services.AddMvc(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

// Cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/SignIn/Index";
});


builder.Services.AddLocalization(o => o.ResourcesPath = "Resource");

builder.Services.AddControllersWithViews()
    .AddViewLocalization()               
    .AddDataAnnotationsLocalization()      
    .AddFluentValidation();

var supportedCultures = new[] { "tr-TR", "en-US", "fr-FR", "es-ES", "el-GR", "de-DE" };

var locOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("tr-TR")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);



builder.Services.AddScoped<GetAllDestinationQueryHandlers>();
builder.Services.AddScoped<GetDestinationQueryHandlers>();
builder.Services.AddScoped<GetAddDestinationQueryHandlers>();
builder.Services.AddScoped<GetDeleteDestinationQueryHandlers>();
builder.Services.AddScoped<GetUpdateDestinationQueryHandlers>();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseStatusCodePagesWithReExecute("/Admin/_404Pages/Index", "?code={0}");

app.UseHttpsRedirection();


app.UseRequestLocalization(locOptions);

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Areas
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
});

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
