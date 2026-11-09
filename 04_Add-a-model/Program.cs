using Microsoft.EntityFrameworkCore;
using MvcGuitarCatalog.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MvcGuitarCatalogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcGuitarCatalogContext")
    ?? throw new InvalidOperationException("Connection string 'MvcGuitarCatalogContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();