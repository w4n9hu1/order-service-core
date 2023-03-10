using Order.Application;
using Order.Application.Mapper;
using Order.Domain.Order;
using Order.Infrastructure;
using Order.Webapi.Middlewares;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
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
    services.AddAutoMapper(typeof(OrderProfile));
    services.AddScoped<IOrderRepository, OrderRepository>();

    services.AddScoped<OrderService>();
}