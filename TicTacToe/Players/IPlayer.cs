﻿using CSharpFunctionalExtensions;
using TicTacToe.Boards;

namespace TicTacToe.Players;

public interface IPlayer
{
    public Task<Result<PlayerMove>> GetNextMoveAsync();
    public char Icon { get; }
}


public abstract class Player : IPlayer
{
    public abstract char Icon { get; }

    public abstract Task<Result<PlayerMove>> GetNextMoveAsync();

    public override string ToString()
        => $"{this.Icon}";
}
