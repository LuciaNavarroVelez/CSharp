using System.Diagnostics;
public class DeckLoader
{

    public List<Card> cards;
    public DeckLoader()
    {
        cards = new();
    }
    public void Load()
    {
        for (var j = 0; j < 4; ++j)
        {
            var type = Type(j);
            for (var i = 1; i < 13; ++i)
            {
                var value = Value(i);
                cards.Add(new Card(type, value));
            }
        }
    }
    public string Value(int i)
    {
        switch (i)
        {
            case 10: return "J";
            case 11: return "Q";
            case 12: return "K";
            default: return i.ToString();
        }
    }
    public Suits Type(int j)
    {
        switch (j)
        {
            case 0: return Suits.Diamonds;
            case 1: return Suits.Spades;
            case 2: return Suits.Clubs;
            case 3: return Suits.Hearts;
            default: return Suits.Hearts;
        }
    }
    public List<Card> ShuffledDeck(List<Card> deck)
    {
        Random rand = new();
        return deck.OrderBy(a => rand.Next()).ToList();
    }

}