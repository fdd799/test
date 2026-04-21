using backend.Interfaces;
using backend.Services;
using Microsoft.EntityFrameworkCore;
using backend.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add OpenAPI
builder.Services.AddOpenApi();

// Configure database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Configure AutoMapper
builder.Services.AddAutoMapper(cfg => { }, typeof(Program));

// Configure services
builder.Services.AddControllers();
builder.Services.AddScoped<IHelloService, HelloService>();
builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddScoped<IUsersService, UsersService>();

// Configure CORS
builder.Services.AddCors(options => {
    options.AddPolicy("vue", policy => {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Configure API behavior
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(x => x.Value != null && x.Value.Errors.Count > 0)
            .ToDictionary(
                x => x.Key,
                x => x.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
            );

        var response = new
        {
            message = "Validation failed",
            errors = errors
        };

        return new BadRequestObjectResult(response);
    };
});

// Configure Serilog bootstrap logger for startup errors
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

builder.Host.UseSerilog((context, services, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
);

try
{
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseCors("vue");

    app.MapControllers();

    app.UseHttpsRedirection();

    app.UseMiddleware<ExceptionMiddleware>();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}