using TicTacToe;

internal class GameSession
{
    public char PlayerOne = 'O';
    public char PlayerTwo = 'X';

    public char CurrentPlayer { get; private set; }

    public void Initiliaze()
    {
        CurrentPlayer = PlayerOne;
    }

    public void SwitchPlayer()
    {
        CurrentPlayer = CurrentPlayer == PlayerOne ? PlayerTwo : PlayerOne;
    }

    public bool IsGameBoardWin(List<Cell> grid)
    {
        IEnumerable<IGrouping<int, Cell>> rows = grid
            .GroupBy(cell => cell.Row);

        if (rows.Any(row =>
            row.All(cell => cell.Value == PlayerOne) ||
            row.All(cell => cell.Value == PlayerTwo)))
        {
            return true;
        }

        IEnumerable<IGrouping<int, Cell>> columns = grid
            .GroupBy(cell => cell.Column);

        if (columns.Any(column =>
            column.All(cell => cell.Value == PlayerOne) ||
            column.All(cell => cell.Value == PlayerTwo)))
        {
            return true;
        }

        IEnumerable<Cell> firstDiagonal = grid.Where(c => c.Row == c.Column);
        IEnumerable<Cell> secondDiagonal = grid.Where(c => (c.Row + c.Column) == 4);

        var diagonals = new List<IEnumerable<Cell>>
        {
            firstDiagonal,
            secondDiagonal
        };

        if (diagonals.Any(diagonal =>
            diagonal.All(cell => cell.Value == PlayerOne) ||
            diagonal.All(cell => cell.Value == PlayerTwo)))
        {
            return true;
        }

        return false;
    }

    public bool PlayOnGameBoard(GameBoard board, int targetRow, int targetColumn, char currentPlayer)
    {
        Cell? cell = board.GetCell(targetRow, targetColumn);

        if (cell == null || cell.Value == PlayerOne || cell.Value == PlayerTwo)
            return false;

        cell.UpdateValue(currentPlayer);
        return true;
    }

    public bool IsGameBoardFull(List<Cell> grid)
        => grid.All(cell => cell.Value.HasValue);
}