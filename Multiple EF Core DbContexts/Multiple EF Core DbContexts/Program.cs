using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Multiple_EF_Core_DbContexts.Contracts;
using Multiple_EF_Core_DbContexts.Orders;
using Multiple_EF_Core_DbContexts.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Database");

builder.Services.AddDbContext<OrdersDbContext>(
    options => options.UseSqlServer(connectionString,
    o => o.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "orders")));

builder.Services.AddDbContext<ProductsDbContext>(
    options => options.UseSqlServer(connectionString,
    o => o.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "products")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Minimal APIs
app.MapGet("products", async (ProductsDbContext productsContext) =>
{
    return Results.Ok(await productsContext.Products.ToListAsync());
});

app.MapGet("products/get-name", async (ProductsDbContext productsContext) =>
{
    return Results.Ok(await productsContext.Products.Select(p => p.Name).ToListAsync());
});

app.MapGet("products/get-id", async (ProductsDbContext productsContext) =>
{
    return Results.Ok(await productsContext.Products.Select(p => p.Id).ToListAsync());
});

app.MapPost("orders", async (
    SubmitOrderRequest request,
    ProductsDbContext productsContext,
    OrdersDbContext ordersContext) =>
{
    var products = await productsContext.Products
        .Where(p => request.ProductIds.Contains(p.Id))
        .AsNoTracking()
        .ToListAsync();

    if (products.Count != request.ProductIds.Count)
    {
        return Results.BadRequest("some product is missing");
    }

    var order = new Order
    {
        Id = Guid.NewGuid(),
        TotalPrice = products.Sum(p => p.Price),
        LineItems = products.Select(p => new LineItem
        {
            Id = Guid.NewGuid(),
            ProductId = p.Id,
            Price = p.Price
        }).ToList()
    };

    ordersContext.Orders.Add(order);

    await ordersContext.SaveChangesAsync();

    return Results.Ok(order);

});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
