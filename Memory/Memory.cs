using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

public class Memory
{
    public List<Tuple<Card, Card>> GuessedCards;
    public bool DisplayingSelection = false;
    public const int ROWS = 6;
    public const int COLUMNS = 8;
    public Position Position;
    public List<Card> ShuffledDeck;
    public List<Card> SelectedCards;
    public Memory()
    {

        DeckLoader deckLoader = new();
        deckLoader.Load();
        ShuffledDeck = deckLoader.ShuffledDeck(deckLoader.cards);

        GuessedCards = new();
        SelectedCards = new();
        Position = new(0, 0);
        Comparer = GameModeNumbers;
    }
    public void Run()
    {
        ReadKeyBoard();
        SolveGame();
    }

    public delegate bool DelegateComparer();
    public DelegateComparer Comparer;
    public void ChooseGameLevel(){
        Console.Clear();
        Console.WriteLine(@"
        CHOOSE YOUR DIFFICULTY
        (*~Couples Maker~*)

        1 - Suits Mode
        2 - Number Mode
        ");
        var tecla = Console.ReadKey(true);

        switch(tecla.Key){
            case ConsoleKey.D1:
                Comparer = GameModeSuits;
                break; 
            case ConsoleKey.D2:
                Comparer = GameModeNumbers; 
                break;
        }
    } 
    public bool GameModeNumbers() => SelectedCards[0].Number == SelectedCards[1].Number;
    public bool GameModeSuits() => SelectedCards[0].Suit == SelectedCards[1].Suit;
    public bool DoCardsMatch() => Comparer != null && Comparer();


    public void SolveGame()
    {
        if (SelectedCards.Count == 2)
        {
            DisplayingSelection = true;
            if (DoCardsMatch())
            {
                SelectedCards[0].Guessed = true;
                SelectedCards[1].Guessed = true;
                GuessedCards.Add(new(SelectedCards[0], SelectedCards[1]));
            }
        }
    }
    
    public void ReadKeyBoard()
    {

        ConsoleKeyInfo key = Console.ReadKey(true);

        if (DisplayingSelection)
            SelectedCards.Clear();
        DisplayingSelection = false;

        switch (key.Key)
        {

            case ConsoleKey.LeftArrow:
                if (LeftMovementAvailable())
                    Position.Y--;
                break;
            case ConsoleKey.RightArrow:
                if (RigthMovementAvailable())
                    Position.Y++;
                break;
            case ConsoleKey.UpArrow:
                if (UpMovementAvailable())
                    Position.X--;
                break;
            case ConsoleKey.DownArrow:
                if (DownMovementAvailable())
                    Position.X++;
                break;
            case ConsoleKey.Enter:
                if (!IsOneGuessedCard() && !SelectedCards.Contains(HoveredCard()))
                    SelectedCards.Add(HoveredCard());
                break;
        }
    }
    public bool RigthMovementAvailable() => Position.Y < COLUMNS - 1;
    public bool LeftMovementAvailable() => Position.Y > 0;
    public bool DownMovementAvailable() => Position.X < ROWS - 1;
    public bool UpMovementAvailable() => Position.X > 0;
    public bool IsOneGuessedCard() => HoveredCard().Guessed;
    public Card HoveredCard() => ShuffledDeck[Position.X * COLUMNS + Position.Y];
    public bool IsEndOfTheGame() => GuessedCards.Count == ShuffledDeck.Count / 2;
}
