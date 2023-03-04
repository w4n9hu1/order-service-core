using Order.Application;
using Order.Application.Mapper;
using Order.Domain.Order;
using Order.Infrastructure;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AddServices(builder.Services);

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

static void AddServices(IServiceCollection services)
{
    services.AddAutoMapper(typeof(OrderProfile));
    services.AddScoped<IOrderRepository, OrderRepository>();

    services.AddRefitClient<IQuotesApi>().ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.quotable.io"));
}