using CSharpFunctionalExtensions;
using FluentAssertions;
using TicTacToe;
using TicTacToe.Boards;
using TicTacToe.Display;
using TicTacToe.Games;
using TicTacToe.Players;

namespace TicTacToeTest
{
    public class GameTest
    {

        [Fact]
        public async void Play_TwoFakePlayerTargettingACol_ReturnsPlayerOneWon()
        {
            // Arrange
            FakePlayer fakePlayer1 = new FakePlayer(
                PlayerConstants.PlayerOneIcon,
                CreateMovesInColumn(1));
            FakePlayer fakePlayer2 = new FakePlayer(
                PlayerConstants.PlayerTwoIcon,
                CreateMovesInColumn(2));

            Game game = new Game(new DebugDisplay(), fakePlayer1, fakePlayer2);

            // Act
            GameResult actualGameResult = await game.PlayAsync();

            // Assert
            actualGameResult
                .Should()
                .Be(GameResult.Win(PlayerConstants.PlayerOneIcon));
        }

        private static Queue<PlayerMove> CreateMovesInColumn(int column)
        {
            Queue<PlayerMove> firstColumnMoves = new Queue<PlayerMove>();
            firstColumnMoves.Enqueue(new PlayerMove(1, column));
            firstColumnMoves.Enqueue(new PlayerMove(2, column));
            firstColumnMoves.Enqueue(new PlayerMove(3, column));
            return firstColumnMoves;
        }
    }

    public class FakePlayer : Player
    {
        public override char Icon { get; }

        private readonly Queue<PlayerMove> Moves;

        public FakePlayer(char icon, Queue<PlayerMove> moves)
        {
            this.Icon = icon;
            this.Moves = moves;
        }

        public async override Task<Result<PlayerMove>> GetNextMoveAsync()
            => Moves.Dequeue();
    }
}
