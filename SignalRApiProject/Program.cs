using Microsoft.EntityFrameworkCore;
using SignalRApiProject.DAL.Concrete;
using SignalRApiProject.Hubs;
using SignalRApiProject.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<VisitorServicesModel>();
builder.Services.AddSignalR();

// UI origin'ini birebir yaz (port dahil)
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", p => p
        .WithOrigins(
            "http://localhost:5086",   // UI'nin ger�ek adresi
            "https://localhost:5086"   // UI https ile de a��labiliyorsa ekle
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();     // <-- �nemli
app.UseCors("CorsPolicy");     // <-- MapHub'tan �nce
app.UseAuthorization();

app.MapControllers();
app.MapHub<VisitorHub>("/VisitorHub"); // <-- ba��nda / var

app.Run();
