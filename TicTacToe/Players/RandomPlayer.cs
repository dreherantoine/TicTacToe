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
        Task.Delay(1000).Wait();

        return PlayerMove.Random;
    }

}