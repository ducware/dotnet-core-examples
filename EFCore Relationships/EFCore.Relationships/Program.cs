global using Microsoft.EntityFrameworkCore;
using EFCore.Relationships.Data;
using EFCore.Relationships.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Db"));
});

var assembly = Assembly.GetExecutingAssembly();
var types = assembly.GetTypes()
    .Where(type => type.IsClass   // chỉ kiểm tra các lớp
        && !type.IsAbstract  // không kiểm tra các lớp abstract
        && type.GetInterfaces()  // lay cac interface ma type này kế thừa
            .Any(i => i.IsGenericType  // kiểm tra xem có interface nào là generic type không
                    && i.GetGenericTypeDefinition() == typeof(IRepository<>)));  // kiểm tra xem có interface nào kế thừa từ IRepository<T> không

foreach (var type in types)
{
    foreach (var iface in type.GetInterfaces())
    {
        builder.Services.AddScoped(iface, type); // đăng ký dịch vụ với DI container
    }
}


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
