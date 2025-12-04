using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _responses;
    private static string[] _prompts = new string[]
    {
        "List as many things as you can that you are grateful for:",
        "List people who have helped you recently:",
        "List accomplishments you are proud of:",
        "List activities that make you feel calm:"
    };

    public ListingActivity(int durationSeconds)
        : base("Listing Activity",
               "This activity will prompt you to list items related to a topic. Try to list as many meaningful items as you can within the time limit.",
               durationSeconds)
    {
        _responses = new List<string>();
    }

    public override void StartActivity()
    {
        base.StartActivity();

        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Length)];

        Console.WriteLine(prompt);
        Console.WriteLine("You have " + _duration + " seconds. Start listing:");
        Console.WriteLine();

        Stopwatch stopwatch = Stopwatch.StartNew();
        while (stopwatch.Elapsed < TimeSpan.FromSeconds(_duration))
        {
            if (Console.KeyAvailable)
            {
                string line = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                    _responses.Add(line.Trim());
            }
            else
            {
                Console.Write(".");
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }

        Console.WriteLine();
        Console.WriteLine($"Time's up! You listed {_responses.Count} items.");
        EndActivity();
    }
}
