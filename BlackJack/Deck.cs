public class Deck
{
    private List<Card> cards = new List<Card>();
    private static Random random = new Random();

    private static readonly string[] Suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
    private static readonly string[] Ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

    public Deck()
    {
        foreach (var suit in Suits)
        {
            foreach (var rank in Ranks)
            {
                cards.Add(new Card(rank, suit));
            }
        }
        Shuffle();
    }

    public void Shuffle()
    {
        cards = cards.OrderBy(c => random.Next()).ToList();
    }

    public Card DealCard()
    {
        if (cards.Count == 0)
        {
            throw new InvalidOperationException("No cards left in the deck!");
        }
        Card topCard = cards[0];
        cards.RemoveAt(0);
        return topCard;
    }
}