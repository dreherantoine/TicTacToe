﻿
using CSharpFunctionalExtensions;

namespace TicTacToe;

internal class Game
{
    public static char PlayerOneIcon = 'O';
    public static char PlayerTwoIcon = 'X';

    private readonly Board board;
    private readonly IPlayer player1;
    private readonly IPlayer player2;

    public IPlayer currentPlayer {  get; private set; }

    public Game(IPlayer player1, IPlayer player2)
    {
        this.board = new Board();
        this.player1 = player1;
        this.player2 = player2;
    }

    public void Init()
    {
        this.board.Init();
        this.currentPlayer = this.player1;
    }

    public void Play()
    {
        this.board.DisplayGameBoardAndHeader();

        while (true)
        {
            Result<PlayerMoves> playerMoves = this.currentPlayer.GetNextMove();
            if (playerMoves.IsFailure)
            {
                Console.WriteLine(playerMoves.Error);
                continue;
            }

            bool movePlayedSuccessfully = this.board.PlayMoveOnBoard(playerMoves.Value, this.currentPlayer.icon);
            if (movePlayedSuccessfully is false)
            {
                Console.WriteLine("Invalid move");
                continue;
            }
            this.board.DisplayGameBoardAndHeader();

            Maybe<string> gameResult = this.board.IsGameOver(currentPlayer);
            if (gameResult.HasValue)
            {
                Console.WriteLine(gameResult.Value);
                break;
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
