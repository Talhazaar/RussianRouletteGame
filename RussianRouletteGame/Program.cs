using System;

namespace RussianRoulette
{
    class Program
    {
        static void Main(string[] args)
        {
            // Game introduction and setup
            Console.Title = "Russian Roulette";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please Enter Your Rank.");
            Console.ForegroundColor = ConsoleColor.Green;
            string Name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nHello {Name}, Welcome.\nI am CPU E7250. I will be interrogating you today.");
            Console.WriteLine("We will play a simple game of Russian Roulette using a six shooter revolver. The rules are simple.\n\nRules:\n1) You will have two choices: Shoot the CPU or yourself.\n2) The game will end after six shots.\n3) If you survive, you walk free.");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nWhen ready, please press and enter 1 to flip a coin to start the game.");

            char answer = Convert.ToChar(Console.ReadLine());
            bool isPlayerTurn = true; // Default to player starting

            if (answer == '1')
            {
                Random random = new Random();
                int coinFlip = random.Next(2); // Generates 0 or 1

                if (coinFlip == 0)
                {
                    Console.WriteLine("\nCoin Flip Result: Player");
                    Console.WriteLine("The first turn will be by the player.");
                    isPlayerTurn = true;
                }
                else
                {
                    Console.WriteLine("\nCoin Flip Result: CPU");
                    Console.WriteLine("The first turn will be by the CPU.");
                    isPlayerTurn = false;
                }
            }
            else
            {
                Console.WriteLine("\nYou have ended your life. Pathetic coward!");
                return;
            }

            Console.Clear();

            // Game logic
            Random random1 = new Random();
            int bulletPosition = random1.Next(1, 7); // Generates a number between 1 and 6
            int shotsTaken = 0;
            bool gameEnded = false;

            while (shotsTaken < 6 && !gameEnded)
            {
                Console.WriteLine(isPlayerTurn ? "It's your turn. Press 1 to aim at the CPU or 2 to aim at yourself." : "CPU's turn.");
                int choice = 0;

                if (isPlayerTurn)
                {
                    while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
                    {
                        Console.WriteLine("Invalid input. Please enter 1 to aim at the CPU or 2 to aim at yourself.");
                    }
                }
                else
                {
                    choice = random1.Next(1, 3); // Randomly choose 1 or 2 for the CPU
                    Console.WriteLine($"CPU chooses to aim at {(choice == 1 ? "you" : "itself")}.");
                    System.Threading.Thread.Sleep(1000); // Add a small delay for CPU's turn
                }

                int currentChamber = (shotsTaken % 6) + 1; // Sequence through chambers 1 to 6

                if (currentChamber == bulletPosition)
                {
                    if (choice == 2)
                    {
                        if (isPlayerTurn)
                        {
                            Console.WriteLine("Bang! You've been shot. You lose.");
                        }
                        else
                        {
                            Console.WriteLine("Bang! The CPU has been shot. You win!");
                        }
                    }
                    else
                    {
                        if (isPlayerTurn)
                        {
                            Console.WriteLine("Bang! The CPU has been shot. You win!");
                        }
                        else
                        {
                            Console.WriteLine("Bang! You've been shot. You lose.");
                        }
                    }
                    gameEnded = true;
                }
                else
                {
                    Console.WriteLine("Click. No bullet.");
                }

                shotsTaken++;
                isPlayerTurn = !isPlayerTurn; // Switch turns
            }

            if (!gameEnded)
            {
                Console.WriteLine("All 6 shots have been taken. No one got shot. It's a draw!");
            }

            Console.WriteLine("Game over. Thanks for playing.");
        }
    }
}
