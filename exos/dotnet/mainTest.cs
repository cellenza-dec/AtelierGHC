using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using Xunit;

namespace MyApp.Tests
{
    public class AppTests
    {
  
        [Fact]
        public async Task TestHelloEndpoint()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();
            var client = app.CreateClient();

            // Act
            var response = await client.GetAsync("/hello");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal("Bonjour! (en .NET)", content);
        }
    }
}