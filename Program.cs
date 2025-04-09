// See https://aka.ms/new-console-template for more information

using BlackjackCLI.Content.Game;

class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        game.StartGame();
    }
}
