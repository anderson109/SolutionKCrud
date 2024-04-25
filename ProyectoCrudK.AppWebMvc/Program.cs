using Microsoft.EntityFrameworkCore;
using ProyectoCrudK.BLL.Service;
using ProyectoCrudK.DAL.DataContext;
using ProyectoCrudK.DAL.Repositories;
using ProyectoCrudK.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ADBContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));

});


builder.Services.AddScoped<IGenericRepository<PersonaK>,ContactoRepository>();
builder.Services.AddScoped<IContactoService, ContactoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
