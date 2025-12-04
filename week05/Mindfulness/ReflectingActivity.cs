using System;
using System.Threading;

public class ReflectingActivity : Activity
{
    private static string[] _prompts = new string[]
    {
        "Think of a time you did something really difficult.",
        "Recall a time you helped someone in need.",
        "Remember a moment when you were proud of yourself."
    };

    private static string[] _questions = new string[]
    {
        "Why was this experience meaningful to you?",
        "What did you learn about yourself?",
        "How can you apply this lesson in the future?",
        "How did you feel in the moment?"
    };

    public ReflectingActivity(int durationSeconds)
        : base("Reflecting Activity",
               "This activity will help you reflect on meaningful moments in your life.",
               durationSeconds)
    {
    }

    public override void StartActivity()
    {
        base.StartActivity();

        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Length)];

        Console.WriteLine(prompt);
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(_questions[index % _questions.Length]);
            DisplayAnimation(4);
            index++;
        }

        EndActivity();
    }
}
