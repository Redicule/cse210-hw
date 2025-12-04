using System;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    protected Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public virtual void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"*** {_name} ***");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine($"You will do this activity for {_duration} seconds.");
        DisplayAnimation(3);
    }

    public virtual void EndActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Well done! Returning to menu...");
        DisplayAnimation(2);
    }

    public void DisplayAnimation(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        int interval = 200;
        int cycles = (seconds * 1000) / interval;

        for (int i = 0; i < cycles; i++)
        {
            Console.Write(frames[i % frames.Length]);
            Thread.Sleep(interval);
            Console.Write("\b");
        }
        Console.WriteLine();
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
