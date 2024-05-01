using Project4.repositories;
using Project4.services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddScoped<IWarehousesRepository, WarehousesRepository>();
        builder.Services.AddScoped<IWarehousesService, WarehousesService>();
        builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
        builder.Services.AddScoped<IOrdersService, OrdersService>();
        builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
        builder.Services.AddScoped<IProductsService, ProductsService>();
        builder.Services.AddScoped<IProductWarehouseRepository, ProductWarehouseRepository>();
        builder.Services.AddScoped<IProductWarehouseService, ProductWarehouseService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();
        
        app.Run();
    }
}