using System.Drawing;

public class MemoryRenderer
{
    public Memory Game { get; private set; }
    public MemoryRenderer(Memory memory)
    {
        Game = memory;
    }
    public void Show()
    {
        Console.WriteLine(@"
  __  __                                           
 |  \/  |   ___   _ __ ___     ___    _ __   _   _ 
 | |\/| |  / _ \ | '_ ` _ \   / _ \  | '__| | | | |
 | |  | | |  __/ | | | | | | | (_) | | |    | |_| |
 |_|  |_|  \___| |_| |_| |_|  \___/  |_|     \__, |
                                             |___/
        ");
        var count = 0;
        for (var i = 0; i < Memory.ROWS; ++i)
        {
            for (var j = 0; j < Memory.COLUMNS; ++j)
            {
                if (SameAsCursorPosition(Game.Position, i, j))
                    Console.ForegroundColor = ConsoleColor.Red;
                if (Game.ShuffledDeck[count].Guessed)
                    Console.Write("..\t");
                else if (Game.SelectedCards.Contains(Game.ShuffledDeck[count]))
                    Console.Write(Game.ShuffledDeck[count] + "\t");
                else
                    Console.Write("??\t");
                Console.ResetColor();

                count++;
            }
            Console.WriteLine();
        }

        Console.WriteLine("\n\n" + string.Join(" - ", Game.GuessedCards));
    }
    public bool SameAsCursorPosition(Position position, int rows, int columns) => position.X == rows && position.Y == columns;
}