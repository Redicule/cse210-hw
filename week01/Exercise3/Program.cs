using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            int magicNumber = randomGenerator.Next(1, 20);
            int userGuess = 0;
            int guessCount = 0;

            Console.WriteLine("I have chosen a number between 1 and 100");
            Console.WriteLine("Try to guess it!");

            while (userGuess != magicNumber)
            {
                Console.Write("What is your guess? ");
                userGuess = int.Parse(Console.ReadLine());
                guessCount++;

                if (userGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (userGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} tries!");
                }
            }
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();

            if (response != "yes")
            {
                playAgain = false;
            }

            Console.WriteLine();
        }
        Console.WriteLine("Thanks for playing!");
    }
}