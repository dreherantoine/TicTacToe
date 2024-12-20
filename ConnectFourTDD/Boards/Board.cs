namespace ConnectFourTDD.Boards;

public class Board
{
    public List<Cell> Grid { get; private set; }

    public Board()
    {
        this.Grid = InitiliazeGrid();
    }

    private static List<Cell> InitiliazeGrid()
    {
        List<Cell> grid = new List<Cell>();

        for (int column = 0; column < 7; column++)
        {
            for (int row = 0; row < 6; row++)
            {
                grid.Add(new Cell(column, row));
            }
        }

        return grid;
    }

    public bool PlayerMove(int column, string color)
    {
        Cell? cell = this.Grid
            .Where(cell => cell.Column == column)
            .Where(cell => cell.Value == null)
            .LastOrDefault();

        if (cell == null)
            return false;

        cell.SetValue(color);

        return true;
    }

    public bool IsGameWin()
    {
        IEnumerable<IGrouping<int, Cell>> columns = this.Grid
            .GroupBy(cell => cell.Column);

        IEnumerable<IGrouping<int, Cell>> rows = this.Grid
            .GroupBy(cell => cell.Row);

        if (IsFourConsecutive(columns) || IsFourConsecutive(rows))
        {
            return true;
        }

        return false;
    }

    private static bool IsFourConsecutive(IEnumerable<IGrouping<int, Cell>> grid)
    {
        // Not implemented yet
        return true;
    }
}
