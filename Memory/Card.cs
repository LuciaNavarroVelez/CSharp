public class Card{

    public string Number {get; private set;}
    public Suits Suit {get; private set;}
    public bool Guessed {get; set;}
    public Card(Suits suit, string number) {
        Suit = suit;
        Number = number;   
        Guessed = false;  
    }
    public Dictionary<Suits, string> cardSymbols = new()
    {
        { Suits.Hearts, "\u2665" },
        { Suits.Diamonds, "\u2666" }, 
        { Suits.Clubs, "\u2663" },
        { Suits.Spades, "\u2660" }
    };
    public override string ToString() => $"{Number}{cardSymbols[Suit]}";
}