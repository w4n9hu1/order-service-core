using Microsoft.AspNetCore.HttpLogging;
using Order.Application;
using Order.Application.Mapper;
using Order.Domain.Order;
using Order.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AddServices(builder.Services);

var app = builder.Build();

app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddServices(IServiceCollection services)
{
    services.AddHttpLogging(logging =>
    {
        logging.LoggingFields = HttpLoggingFields.RequestBody | HttpLoggingFields.RequestPath | HttpLoggingFields.ResponseBody;
        logging.RequestBodyLogLimit = 4096;
        logging.ResponseBodyLogLimit = 4096;
    });

    services.AddAutoMapper(typeof(OrderProfile));
    services.AddScoped<IOrderRepository, OrderRepository>();

    services.AddScoped<OrderService>();
}