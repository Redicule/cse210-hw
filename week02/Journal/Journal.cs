using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    // ---------------- Add Entry ----------------
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

    // ---------------- Display All ----------------
    public void DisplayAll()
    {
        Console.WriteLine("\n--- Your Journal Entries ---\n");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // ---------------- Save to File ----------------
    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var e in _entries)
            {
                writer.WriteLine(e._date);
                writer.WriteLine(e._userName);
                writer.WriteLine(e._mood);
                writer.WriteLine(e._prompt);
                writer.WriteLine(e._response);
                writer.WriteLine("---"); // separator between entries
            }
        }

        Console.WriteLine("Journal saved to " + filename);
    }

    // ---------------- Load from File ----------------
    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found: " + filename);
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);
        Entry e = null;
        int count = 0;

        foreach (string line in lines)
        {
            if (line == "---")
            {
                // End of an entry
                _entries.Add(e);
                e = null;
                count = 0;
                continue;
            }

            if (e == null) e = new Entry();

            // Add fields line by line
            if (count == 0) e._date = line;
            else if (count == 1) e._userName = line;
            else if (count == 2) e._mood = line;
            else if (count == 3) e._prompt = line;
            else if (count == 4) e._response = line;

            count++;
        }

        Console.WriteLine("Journal loaded from " + filename);
    }
}
