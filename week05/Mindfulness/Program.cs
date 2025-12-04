using System;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity(30);
                    break;

                case "2":
                    activity = new ListingActivity(30);
                    break;

                case "3":
                    activity = new ReflectingActivity(45);
                    break;

                case "4":
                    exit = true;
                    continue;

                default:
                    Console.WriteLine("Invalid option. Press Enter.");
                    Console.ReadLine();
                    continue;
            }

            activity.StartActivity();
        }

        Console.WriteLine("Goodbye!");
    }
}
