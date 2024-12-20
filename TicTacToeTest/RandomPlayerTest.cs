using CSharpFunctionalExtensions;
using FluentAssertions;
using TicTacToe;
using TicTacToe.Boards;
using TicTacToe.Players;

namespace TicTacToeTest
{
    public class RandomPlayerTest
    {
        [Fact]
        public async void GetNextMove_Default_ReturnsAValidPlayerMove()
        {
            // Arrange
            RandomPlayer randomPlayer = new RandomPlayer(PlayerConstants.PlayerOneIcon);

            // Act
            Result<PlayerMove> actualMove = await randomPlayer.GetNextMoveAsync();

            // Assert
            actualMove.IsSuccess
                .Should()
                .BeTrue();

            actualMove.Value.Row
                .Should()
                .BeInRange(1, 3);

            actualMove.Value.Column
                .Should()
                .BeInRange(1, 3);
        }
    }
}
