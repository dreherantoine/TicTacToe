using System;
using System.Data;
using System.Data.Common;

namespace TicTacToe;

internal class Program
{
    static void Main(string[] args)
    {
        Game game = new();
        game.Initialize();
    }

}
