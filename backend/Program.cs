using backend.Interfaces;
using backend.Services;
using Microsoft.EntityFrameworkCore;
using backend.Middlewares;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddControllers();
builder.Services.AddScoped<IHelloService, HelloService>();
builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddCors(options => {
    options.AddPolicy("vue", policy => {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(x => x.Value.Errors.Count > 0)
            .ToDictionary(
                x => x.Key,
                x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );

        var response = new
        {
            message = "Validation failed",
            errors = errors
        };

        return new BadRequestObjectResult(response);
    };
});

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