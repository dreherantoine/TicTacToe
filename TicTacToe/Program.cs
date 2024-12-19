

namespace TicTacToe;

internal class Program
{
    public static char PlayerOneIcon = 'O';
    public static char PlayerTwoIcon = 'X';

    static void Main(string[] args)
    {
        Boolean useAI = AI.DisplayGameChoiceAndHeader();

        Player player1 = new Player(PlayerOneIcon);
        IPlayer player2 = useAI ? new FakePlayer(PlayerTwoIcon) : new Player(PlayerTwoIcon);

        Game game = new Game(player1, player2);
        game.Init();
        game.Play();
    }

}
