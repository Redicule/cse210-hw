using System;

class Program
{
    static void Main(string[] args)
    {
<<<<<<< HEAD
        Console.WriteLine("What is your first name? ");
        string first = Console.ReadLine();

        Console.WriteLine("What is your last name? ");
=======
        Console.Write("What is your first name? ");
        string first = Console.ReadLine();

        Console.Write("What is your last name? ");
>>>>>>> a836016d18840a798326f0c721efc49aabaa3ba8
        string last = Console.ReadLine();

        Console.WriteLine($"Your name is {last}, {first} {last}.");
    }
}