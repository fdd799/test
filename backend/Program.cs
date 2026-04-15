using backend.Interfaces;
using backend.Services;
using Microsoft.EntityFrameworkCore;
using backend.Middlewares;

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