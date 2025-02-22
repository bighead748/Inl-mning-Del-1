using dagnyr.api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DevConnection"));
});

builder.Services.AddControllers();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
var context = services.GetRequiredService<DataContext>();
await context.Database.MigrateAsync();
await Seed.LoadProducts(context);
await Seed.LoadOrders(context);
await Seed.LoadSuppliers(context);

}
catch (Exception ex)
{
    System.Console.WriteLine("{0}", ex.Message);
    throw;
}

app.MapControllers();

app.Run();
