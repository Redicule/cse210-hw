using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity(int durationSeconds)
        : base("Breathing Activity",
               "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breath.",
               durationSeconds)
    {
    }

    public override void StartActivity()
    {
        base.StartActivity();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in: ");
            Countdown(4);
            Console.WriteLine();

            Console.Write("Breathe out: ");
            Countdown(6);
            Console.WriteLine();

            Thread.Sleep(300);
        }

        EndActivity();
    }
}
