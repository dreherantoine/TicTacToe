﻿using CSharpFunctionalExtensions;
using TicTacToe.Boards;
using TicTacToe.Display;
using TicTacToe.Games;
using TicTacToe.Players;

namespace TicTacToe;

public class Game
{
    private GameState gameState = GameState.InProgress;
    private readonly IDisplay display;
    private readonly Board board;
    private readonly IPlayer player1;
    private readonly IPlayer player2;

    public IPlayer currentPlayer {  get; private set; }

    public Game(IDisplay display, IPlayer player1, IPlayer player2)
    {
        this.board = new Board(display);

        this.player1 = player1;
        this.player2 = player2;

        this.currentPlayer = this.player1;
        this.display = display;
    }

    public async Task<GameResult> PlayAsync()
    {
        this.board.DisplayGameBoard();

        while (true)
        {
            Result<PlayerMove> playerMoves = await this.currentPlayer.GetNextMoveAsync();

            if (playerMoves.IsFailure)
            {
                this.display.WriteLine(playerMoves.Error);
                continue;
            }

            bool movePlayedSuccessfully = this.board.PlayMoveOnBoard(playerMoves.Value, this.currentPlayer.Icon);
            if (movePlayedSuccessfully is false)
            {
                this.display.WriteLine("Invalid move");
                continue;
            }
            this.board.DisplayGameBoard();

            GameState gameResult = this.board.IsGameOver(currentPlayer);
            if (gameResult == GameState.Win)
            {
                this.display.WriteLine(gameResult);
                return GameResult.Win(currentPlayer.Icon);
            }
            else if (gameResult == GameState.Draw)
            {
                this.display.WriteLine(gameResult);
                return GameResult.Draw();
            }

            this.SwitchPlayer();
        }
    }

    private void SwitchPlayer()
    {
        if (this.currentPlayer == player1)
            this.currentPlayer = player2;
        else
            this.currentPlayer = player1;
    }

}
