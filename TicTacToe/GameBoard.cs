using TicTacToe;

internal class GameBoard
{
    public List<Cell> Grid { get; private set; }

    public void Initialize()
    {
        Grid = [
            Cell.EmptyCell(1, 1),
            Cell.EmptyCell(1, 2),
            Cell.EmptyCell(1, 3),
            Cell.EmptyCell(2, 1),
            Cell.EmptyCell(2, 2),
            Cell.EmptyCell(2, 3),
            Cell.EmptyCell(3, 1),
            Cell.EmptyCell(3, 2),
            Cell.EmptyCell(3, 3),
        ];
    }

    public void Display()
    {
        Console.WriteLine(new string('=', Console.WindowWidth));
        Console.WriteLine(".NET MAUI".PadLeft(Console.WindowWidth / 2));
        Console.WriteLine(new string('=', Console.WindowWidth));

        Console.WriteLine($"|-----------------|");
        DisplayGameBoardLine(GetCellContent(1, 1), GetCellContent(1, 2), GetCellContent(1, 3));
        Console.WriteLine($"|-----|-----|-----|");
        DisplayGameBoardLine(GetCellContent(2, 1), GetCellContent(2, 2), GetCellContent(2, 3));
        Console.WriteLine($"|-----|-----|-----|");
        DisplayGameBoardLine(GetCellContent(3, 1), GetCellContent(3, 2), GetCellContent(3, 3));
        Console.WriteLine($"|-----------------|");
    }

    private static void DisplayGameBoardLine(char leftCell, char middleCell, char rightCell)
    {
        Console.WriteLine($"|  {leftCell}  |  {middleCell}  |  {rightCell}  |");
    }

    private char GetCellContent(int row, int column)
        => GetCell(row, column)?.Value ?? ' ';

    public Cell? GetCell(int row, int column)
        => Grid
            .Where(cell => cell.Row == row)
            .Where(cell => cell.Column == column)
            .FirstOrDefault();
}