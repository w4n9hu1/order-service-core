using Order.Application;
using Order.Application.Mapper;
using Order.Domain.Order;
using Order.Infrastructure;
using Order.Webapi.Middlewares;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs\\log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AddServices(builder.Services);

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseAuditLog();

app.Run();

static void AddServices(IServiceCollection services)
{
    services.AddMemoryCache();
    services.AddAutoMapper(typeof(OrderProfile));
    services.AddScoped<IOrderRepository, CacheOrderRepository>();

    services.AddScoped<OrderService>();
    services.AddScoped<OrderManager>();

    services.AddScoped<IDistributedEventBus, KafkaEventBus>();
}