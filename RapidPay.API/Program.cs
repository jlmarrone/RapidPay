using Microsoft.EntityFrameworkCore;
using RapidPay.API.Extensions;
using RapidPay.API.Filters;
using RapidPay.Application.DependencyInjection;
using RapidPay.Persistence.EF.DependencyInjection;
using RapidPay.Persistence.EF.Persistence;
using RapidPay.Services.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvcCore(options =>
{
    options.Filters.Add<ExceptionFilter>();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMemoryCache();
builder.Services.AddSwaggerServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddServicesImplementations();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<RapidPayDbContext>();
    context.Database.Migrate();
}

app.Run();
