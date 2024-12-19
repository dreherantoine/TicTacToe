using CSharpFunctionalExtensions;

namespace TicTacToe;

internal class FakePlayer : IPlayer
{
    public char icon { get; }

    public FakePlayer(char icon)
    {
        this.icon = icon;
    }

    public Result<PlayerMoves> GetNextMove()
    {
        Random rnd = new();

        int targetRow = rnd.Next(1, 4);
        int targetColumn = rnd.Next(1, 4);

        return Result.Success(new PlayerMoves(targetRow, targetColumn));
    }
}