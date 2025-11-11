using System;
using System.Collections.Generic;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry()
    {
        Entry newEntry = new Entry();

        // Step 1: Get the date
        newEntry._date = DateTime.Now.ToShortDateString();

        // Step 2: Get the user's name
        Console.Write("Enter your name: ");
        newEntry._userName = Console.ReadLine();

        // Step 3: Get the user's mood
        Console.Write("How are you feeling today? ");
        newEntry._mood = Console.ReadLine();

        // Step 4: Show a random prompt
        string[] prompts = {
            "What was the best part of your day?",
            "What is something you’re grateful for today?",
            "Who made you smile today?",
            "What’s one thing you learned today?",
            "What’s a goal you have for tomorrow?"
        };

        Random rnd = new Random();
        newEntry._prompt = prompts[rnd.Next(prompts.Length)];

        Console.WriteLine($"\nPrompt: {newEntry._prompt}");
        Console.Write("Your response: ");
        newEntry._response = Console.ReadLine();

        // Step 5: Add entry to list
        _entries.Add(newEntry);

        Console.WriteLine("\nEntry saved successfully!");
    }

    public void DisplayAll()
    {
        Console.WriteLine("\n--- Your Journal Entries ---\n");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
}
