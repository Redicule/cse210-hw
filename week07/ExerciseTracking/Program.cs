using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("03 Feb 2025", 30, 4.8));
        activities.Add(new Cycling("03 Feb 2025", 45, 20));
        activities.Add(new Swimming("03 Feb 2025", 25, 40));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
