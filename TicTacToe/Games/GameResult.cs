using TicTacToe.Players;

namespace TicTacToe.Games;

public record GameResult(GameState State, char? Winner)
{
    public static GameResult Draw()
        => new GameResult(GameState.Draw, null);

    public static GameResult Win(char winner)
        => new GameResult(GameState.Win, winner);

    public override string ToString()
        => State == GameState.Draw
            ? "It's a draw!"
            : $"Player {Winner} has won the game !!!!";
}
