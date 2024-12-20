using ConnectFourTDD;
using FluentAssertions;

namespace ConnectFourTDDTest;

public class PlayerTest
{
    [Fact]
    public void Initialize_ReturnChar()
    {
        // Arrange
        Player player = new Player("Red");

        // Act
        string expectedColor = player.Color;

        // Assert
        expectedColor
            .Should()
            .Be("Red");
    }
}
