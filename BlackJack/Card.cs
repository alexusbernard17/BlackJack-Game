using System.Diagnostics.Tracing;

public class Card
{
    public string Rank { get; }
    public string Suit { get; }
    public int Value
    {
        get
        {
            if (int.TryParse(Rank, out int number))
            {
                return number;
            }
            else if (Rank == "A")
            {
                return 11;
            }
            else
            {
                return 10; // J, Q, K
            }
        }
    }

    public Card(string rank, string suit)
    {
        this.Rank = rank;
        this.Suit = suit;
    }

    public override string ToString() => $"{Rank} of {Suit}";
}