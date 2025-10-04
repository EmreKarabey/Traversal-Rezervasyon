using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL.Concrete;

var builder = WebApplication.CreateBuilder(args);

// appsettings'ten baðlantý dizesini oku
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ... diðer servisler ...

builder.Services.AddDbContext<Context>(opts =>
{
    // PostgreSQL yerine SQL Server saðlayýcýsýný kullan
    opts.UseSqlServer(connection);
});

// ... app.Run()