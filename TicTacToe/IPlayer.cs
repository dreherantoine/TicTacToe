using CSharpFunctionalExtensions;

namespace TicTacToe
{
    internal interface IPlayer
    {
        public char icon { get; }
        public Result<PlayerMoves> GetNextMove();
    }
}
