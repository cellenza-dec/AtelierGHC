using System.Text.RegularExpressions;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/// <summary>
/// Returns a greeting message.
/// </summary>
app.MapGet("/hello", () => "Hello World !");

/// <summary>
/// Calculates the number of days between two dates.
/// </summary>
/// <param name="startDate">The start date.</param>
/// <param name="endDate">The end date.</param>
/// <returns>The number of days between the start and end dates.</returns>
app.MapGet("/daysbetweendates", (DateTime startDate, DateTime endDate) =>
{
    var days = (endDate - startDate).TotalDays;
    return days.ToString();
});

/// <summary>
/// Validates an email address.
/// </summary>
/// <param name="email">The email address to validate.</param>
/// <returns>True if the email address is valid; otherwise, false.</returns>
app.MapGet("/validateemail", (string email) =>
{
    var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
    return regex.IsMatch(email).ToString();
});

/// <summary>
/// Retrieves the OpenID configuration from a remote server.
/// </summary>
/// <param name="clientFactory">The HTTP client factory.</param>
/// <returns>The OpenID configuration as a string.</returns>
app.MapGet("/openid", async (IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient();
    var response = await client.GetAsync("https://login.microsoftonline.com/common/.well-known/openid-configuration");
    var content = await response.Content.ReadAsStringAsync();
    return content;
});

/// <summary>
/// Retrieves the list of files in the current directory.
/// </summary>
/// <returns>The list of files in the current directory as a JSON string.</returns>
app.MapGet("/files", () =>
{
    var files = System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory());
    return JsonSerializer.Serialize(files);
});

/// <summary>
/// Retrieves the memory usage of the application.
/// </summary>
app.MapGet("/memoryusage", () =>
{
    var memoryUsage = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64;
    return (memoryUsage / (1024 * 1024 * 1024)).ToString();
});

app.Run();


public partial class Program {}
    