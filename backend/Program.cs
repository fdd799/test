using backend.Interfaces;
using backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IHelloService, HelloService>();
builder.Services.AddScoped<ITableService, TableService>();

builder.Services.AddCors(options => {
    options.AddPolicy("vue", policy => {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("vue");

app.MapControllers();

app.UseHttpsRedirection();

app.Run();