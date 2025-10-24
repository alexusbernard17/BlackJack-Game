public class BlackJackGame
{
    private Deck deck;
    private Hand playerHand;
    private Hand dealerHand;
    private int playerMoney;
    private int currentBet;
    private bool playerDoubledDown;

    public BlackJackGame()
    {
        deck = new Deck();
        playerHand = new Hand();
        dealerHand = new Hand();
        playerMoney = 500; // Starting bankroll
    }

    public void Play()
    {
        while (playerMoney > 0)
        {
            Console.Clear();
            Console.WriteLine("=== Welcome to Blackjack ===");
            Console.WriteLine($"Your balance: ${playerMoney}\n");

            PlaceBet();

            playerHand.Clear();
            dealerHand.Clear();
            deck = new Deck();
            playerDoubledDown = false;

            // Deal initial cards
            playerHand.AddCard(deck.DealCard());
            playerHand.AddCard(deck.DealCard());
            dealerHand.AddCard(deck.DealCard());
            dealerHand.AddCard(deck.DealCard());

            Console.WriteLine("\nYour hand:");
            playerHand.Display();
            Console.WriteLine($"Total: {playerHand.Value}\n");

            Console.WriteLine("Dealer's hand:");
            dealerHand.Display(hideSecondCard: true);
            Console.WriteLine();

            PlayerTurn();

            if (playerHand.IsBust)
            {
                Console.WriteLine("You bust! Dealer wins 😢");
                playerMoney -= currentBet;
                Console.WriteLine($"Your balance: ${playerMoney}");
                if (playerMoney <= 0) break;
                AskReplay();
                continue;
            }

            DealerTurn();
            DetermineWinner();

            if (playerMoney <= 0)
            {
                Console.WriteLine("You're out of money! Game over 😭");
                break;
            }

            AskReplay();
        }
    }

    private void PlaceBet()
    {
        while (true)
        {
            Console.Write("Place your bet: $");
            string input = Console.ReadLine()?.Trim();
            if (int.TryParse(input, out int bet) && bet > 0 && bet <= playerMoney)
            {
                currentBet = bet;
                break;
            }
            Console.WriteLine("Invalid bet. Try again.");
        }
    }

    private void PlayerTurn()
    {
        bool canDoubleDown = playerHand.Value == 9 || playerHand.Value == 10 || playerHand.Value == 11;

        while (true)
        {
            if (playerHand.IsBlackjack)
            {
                Console.WriteLine("Blackjack! Let's see what the dealer has...\n");
                break;
            }

            Console.Write("Do you want to (H)it, (S)tand" + (canDoubleDown ? ", or (D)ouble down" : "") + "? ");
            string choice = Console.ReadLine()?.Trim().ToLower();

            if (choice == "h")
            {
                var card = deck.DealCard();
                playerHand.AddCard(card);
                Console.WriteLine($"\nYou drew: {card}");
                Console.WriteLine($"Your total: {playerHand.Value}\n");

                if (playerHand.IsBust) break;
            }
            else if (choice == "s")
            {
                Console.WriteLine("\nYou stand.\n");
                break;
            }
            else if (choice == "d" && canDoubleDown)
            {
                if (playerMoney < currentBet * 2)
                {
                    Console.WriteLine("You don't have enough money to double down.\n");
                    continue;
                }
                currentBet *= 2;
                playerDoubledDown = true;

                var card = deck.DealCard();
                playerHand.AddCard(card);
                Console.WriteLine($"\nYou doubled down and drew: {card}");
                Console.WriteLine($"Your total: {playerHand.Value}\n");
                break; // Turn automatically ends after doubling down
            }
            else
            {
                Console.WriteLine("Please enter H, S" + (canDoubleDown ? ", or D" : "") + ".\n");
            }
        }
    }

    private void DealerTurn()
    {
        Console.WriteLine("Dealer's hand:");
        dealerHand.Display();
        Console.WriteLine($"Dealer's total: {dealerHand.Value}\n");

        while (dealerHand.Value < 17)
        {
            var card = deck.DealCard();
            dealerHand.AddCard(card);
            Console.WriteLine($"Dealer draws: {card}");
            Console.WriteLine($"Dealer's total: {dealerHand.Value}\n");
        }
    }

    private void DetermineWinner()
    {
        int playerTotal = playerHand.Value;
        int dealerTotal = dealerHand.Value;

        if (dealerHand.IsBust)
        {
            Console.WriteLine("Dealer busts! You win 🎉");
            playerMoney += currentBet;
        }
        else if (playerTotal > dealerTotal)
        {
            Console.WriteLine("You win 🎉");
            playerMoney += currentBet;
        }
        else if (playerTotal < dealerTotal)
        {
            Console.WriteLine("Dealer wins 😢");
            playerMoney -= currentBet;
        }
        else
        {
            Console.WriteLine("It's a tie! 🤝 (Your bet is returned)");
        }

        Console.WriteLine($"Your balance: ${playerMoney}");
    }

    private void AskReplay()
    {
        Console.Write("\nPlay another round? (y/n): ");
        string again = Console.ReadLine()?.Trim().ToLower();
        if (again != "y")
        {
            Console.WriteLine("Thanks for playing! 👋");
            Environment.Exit(0);
        }
    }
}