using System.Text.RegularExpressions;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

var app = builder.Build();

// Ask to Copilot to add /hello EndPoint



// Bugy code to fix
app.MapGet("/parallelloop", (int iteration) =>
{
    int i=0;
    Parallel.For(0, iteration, i =>
    {
        i=i+1;
    });
    return i.ToString();    
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();


public partial class Program {}
    