using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL.Concrete;

var builder = WebApplication.CreateBuilder(args);

// appsettings'ten ba�lant� dizesini oku
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ... di�er servisler ...

builder.Services.AddDbContext<Context>(opts =>
{
    // PostgreSQL yerine SQL Server sa�lay�c�s�n� kullan
    opts.UseSqlServer(connection);
});

// ... app.Run()