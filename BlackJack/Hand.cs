public class Hand
{
    private List<Card> cards = new List<Card>();

    public void AddCard(Card card) => cards.Add(card);

    public int Value
    {
        get
        {
            int total = cards.Sum(c => c.Value);
            int aceCount = cards.Count(c => c.Rank == "A");
            while (total > 21 && aceCount > 0)
            {
                total -= 10;
                aceCount--;
            }
            return total;
        }
    }

    public bool IsBust => Value > 21;
    public bool IsBlackjack => Value == 21;

    public void Display(bool hideSecondCard = false)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (i == 1 && hideSecondCard)
            {
                Console.WriteLine("[Hidden Card]");
            }
            else
            {
                Console.WriteLine(cards[i]);
            }
        }
    }

    public void Clear() => cards.Clear();
    public List<Card> Cards => cards;
}