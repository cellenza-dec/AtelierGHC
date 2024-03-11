using System.Text.RegularExpressions;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

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
/// Extracts the query string from the specified URI.
/// </summary>
/// <param name="url">The URI to extract the query string from.</param>
/// <returns>The query string portion of the URI.</returns>
app.MapGet("/parseurl", (string url) =>
{
    var uri = new Uri(url);
    var protocol = uri.Scheme;
    var host = uri.Host;
    var port = uri.Port;
    var queryString = uri.Query;
    var hash = uri.Fragment;

    return JsonSerializer.Serialize(new { protocol, host, port, queryString, hash });
});

/// <summary>
/// Sends an HTTP GET request to retrieve a joke from the specified API.
/// </summary>
/// <param name="client">The HTTP client used to send the request.</param>
/// <returns>A task representing the asynchronous operation. The task result contains the HTTP response.</returns>
app.MapGet("/joke", async (IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient();

    var response = await client.GetAsync("https://v2.jokeapi.dev/joke/Any");
    var content = await response.Content.ReadAsStringAsync();
    var joke = JsonSerializer.Deserialize<dynamic>(content);
    return joke;
});

app.MapGet("/randomeuropeancountry", () =>
{
    /// <summary>
    /// Represents an array of countries.
    /// </summary>
    var countries = new[] { "Spain", "France", "Germany", "Italy", "Portugal", "Sweden", "Norway", "Denmark", "Finland", "Iceland", "Ireland", "United Kingdom", "Greece", "Austria", "Belgium", "Bulgaria", "Croatia", "Cyprus", "Czech Republic", "Estonia", "Hungary", "Latvia", "Lithuania", "Luxembourg", "Malta", "Netherlands", "Poland", "Romania", "Slovakia", "Slovenia" };
    return countries[new Random().Next(0, countries.Length)];
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



//


app.MapGet("/parallelloop", (int iteration) =>
{
    int i = 0;
    Parallel.For(0, iteration, (_) =>
    {
        Interlocked.Increment(ref i);
    });
    return i.ToString();
});


app.Run();

public partial class Program { }
    