using CSharpFunctionalExtensions;
using TicTacToe.Boards;
using TicTacToe.Players;

namespace TicTacToe;

public class RandomPlayer : Player
{
    public override char Icon { get; }

    public RandomPlayer(char icon)
    {
        this.Icon = icon;
    }

    public override async Task<Result<PlayerMove>> GetNextMoveAsync()
    {
        Console.Write($"\rPlayer {this.Icon} is thinking.");
        await Task.Delay(1000);
        Console.Write($"\rPlayer {this.Icon} is thinking..");
        await Task.Delay(1000);
        Console.Write($"\rPlayer {this.Icon} is thinking...");
        await Task.Delay(1000);

        return PlayerMove.Random;
    }

}