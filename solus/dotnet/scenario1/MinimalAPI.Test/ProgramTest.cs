using System.Text.RegularExpressions;
namespace MinimalAPI.Test;
public class ProgramTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ProgramTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_Hello_ReturnsHelloWorld()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/hello");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal("Hello World !", content);
    }

    [Fact]
    public void CalculateDays_ReturnsCorrectNumberOfDays()
    {
        // Arrange
        var startDate = new DateTime(2022, 1, 1);
        var endDate = new DateTime(2022, 1, 10);
        var expectedDays = 9;

        // Act
        var actualDays = (endDate - startDate).TotalDays;

        // Assert
        Assert.Equal(expectedDays, actualDays);
    }
    
        [Fact]
        public void Regex_ValidEmail_ReturnsTrue()
        {
            // Arrange
            var email = "test@example.com";
            var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

            // Act
            var isEmailValid = regex.IsMatch(email);

            // Assert
            Assert.True(isEmailValid);
        }

        [Fact]
        public void Regex_InvalidEmail_ReturnsFalse()
        {
            // Arrange
            var email = "invalid_email";
            var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

            // Act
            var isEmailValid = regex.IsMatch(email);

            // Assert
            Assert.False(isEmailValid);
        }
        
    [Fact]
    public async Task Get_OpenIdConfiguration_ReturnsSuccess()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("https://login.microsoftonline.com/common/.well-known/openid-configuration");

        // Assert
        response.EnsureSuccessStatusCode();
    }
}