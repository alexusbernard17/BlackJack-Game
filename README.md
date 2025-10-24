# 🃏 Console BlackJack Game (C#/ .NET 8)

A simple, interactive **BlackJack** game built with **.NET 8** for the console.  
Play against the dealer, place bets, double down, and see how long your money lasts!

---

## 🚀 Features

- Full deck of 52 cards with shuffle and draw logic  
- Player and dealer turns with BlackJack and bust handling  
- Betting system with money tracking  
- Double down option (only for certain hand values)  
- Clean console-based UI with replay option  

---

## 🧩 Class Overview

### **BlackJackGame**
Main game controller that manages:
- Game loop, betting, and player money  
- Dealing and displaying cards  
- Player and dealer turns  
- Determining the winner of each round  

### **Card**
Represents a single playing card.
- **Properties:** `Rank`, `Suit`, `Value`  
- Handles special card values (Aces, face cards)  
- Overrides `ToString()` for clean display output  

### **Deck**
Represents and manages a standard deck of 52 cards.
- Builds deck from all ranks and suits  
- Randomly shuffles using `Random`  
- Deals one card at a time and removes it from the deck  

### **Hand**
Represents a player or dealer hand.
- Adds and displays cards  
- Dynamically calculates hand value (handles Ace as 1 or 11)  
- Detects BlackJack and busts  

### **Program**
Entry point of the application.
- Initializes and starts the game by calling `BlackJackGame.Play()`  

---

## 🛠️ Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Git (optional, for cloning)

---

## ⚙️ Installation & Run Terminal Instructions

1. Git clone the repository
2. cd to BlackJack directory
3. dotnet run
