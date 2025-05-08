using ScryfallClient.Requests;
using Shouldly;

namespace ScryfallClient.Tests;

[Explicit]
[TestFixture]
public class ScryfallApiClientTests
{
    [Test]
    public async Task CanSearchCardsAsync()
    {
        // Arrange
        using var client = new ScryfallApiClient();
        var request = new CardSearchRequest
        {
            Query = "Black Lotus"
        };

        // Act
        var result = await client.Cards.SearchAsync(request);

        // Assert
        result.TotalCards.ShouldBe(2);
        result.Data[1].Name.ShouldBe("Black Lotus");
        result.Data[0].Name.ShouldBe("Blacker Lotus");
    }
}