namespace TicTacToe;

internal class Game
{
    private GameBoard board { get; set; }
    private GameSession session { get; set; }

    public void Initialize()
    {
        GameBoard board = new();
        GameSession session = new();

        board.Initialize();
        session.Initiliaze();
    }

    public void Start()
    {
        board.Display();
        while (true)
        {
            Console.WriteLine($"Player {session.CurrentPlayer} - Enter row (1-3) and column (1-3), separated by a space, or 'q' to quit...");
            string? input = Console.ReadLine();

            if (string.Compare(input, "q", StringComparison.OrdinalIgnoreCase) == 0)
                break;

            string[]? splittedInput = input?.Split(' ');

            if (int.TryParse(splittedInput?[0], out int targetRow) is false ||
                targetRow < 1 || targetRow > 3)
            {
                Console.WriteLine("Invalid target cell row must be betwen 1 and 3");
                continue;
            }

            if (int.TryParse(splittedInput?[1], out int targetColumn) is false ||
                targetColumn < 1 || targetColumn > 3)
            {
                Console.WriteLine("Invalid target cell column must be betwen 1 and 3");
                continue;
            }

            bool movePlayedSuccessfully = session.PlayOnGameBoard(board, targetRow, targetColumn, session.CurrentPlayer);

            if (movePlayedSuccessfully is false)
            {
                Console.WriteLine("Invalid move");
                continue;
            }

            Console.Clear();

            board.Display();

            if (session.IsGameBoardWin(board.Grid))
            {
                Console.WriteLine($"Player {session.CurrentPlayer} has won the game !!!!");
                break;
            }
            if (session.IsGameBoardFull(board.Grid))
            {
                Console.WriteLine($"It's a draw");
                break;
            }

            session.SwitchPlayer();
        }
    }
}
