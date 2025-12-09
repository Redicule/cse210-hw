using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void Start()
        {
            bool running = true;

            while (running)
            {
                DisplayPlayerInfo();
                Console.WriteLine("1. Create Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Load Goals");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": CreateGoal(); break;
                    case "2": ListGoalDetails(); break;
                    case "3": RecordEvent(); break;
                    case "4": SaveGoals(); break;
                    case "5": LoadGoals(); break;
                    case "6": running = false; break;
                    default: Console.WriteLine("Invalid option."); break;
                }

                Console.WriteLine();
            }
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"Player Score: {_score}");
        }

        public void ListGoalNames()
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        public void ListGoalDetails()
        {
            ListGoalNames();
        }

        public void CreateGoal()
        {
            Console.WriteLine("Choose goal type: 1) Simple 2) Eternal 3) Checklist");
            Console.Write("Type: ");
            string t = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Description: ");
            string desc = Console.ReadLine();

            Console.Write("Points: ");
            int points = int.Parse(Console.ReadLine());

            switch (t)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, desc, points));
                    break;

                case "2":
                    _goals.Add(new EternalGoal(name, desc, points));
                    break;

                case "3":
                    Console.Write("Target amount: ");
                    int target = int.Parse(Console.ReadLine());

                    Console.Write("Bonus points: ");
                    int bonus = int.Parse(Console.ReadLine());

                    _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                    break;
            }
        }

        public void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available.");
                return;
            }

            ListGoalNames();
            Console.Write("Which goal did you complete? ");

            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < _goals.Count)
            {
                int earned = _goals[index].RecordEvent();
                _score += earned;
                Console.WriteLine($"You earned {earned} points!");
            }
        }

        public void SaveGoals(string filename = "goals.txt")
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);

                foreach (Goal g in _goals)
                {
                    writer.WriteLine(g.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved.");
        }

        public void LoadGoals(string filename = "goals.txt")
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _goals.Clear();

            string[] lines = File.ReadAllLines(filename);

            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("|");

                switch (parts[0])
                {
                    case "SimpleGoal":
                        var sg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));

                        if (bool.Parse(parts[4]))
                        {
                            sg.RecordEvent();
                        }
                        _goals.Add(sg);
                        break;

                    case "EternalGoal":
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;

                    case "ChecklistGoal":
                        var cg = new ChecklistGoal(
                            parts[1],
                            parts[2],
                            int.Parse(parts[3]),
                            int.Parse(parts[5]),
                            int.Parse(parts[6])
                        );

                        int completed = int.Parse(parts[4]);
                        for (int c = 0; c < completed; c++)
                        {
                            cg.RecordEvent();
                        }

                        _goals.Add(cg);
                        break;
                }
            }

            Console.WriteLine("Goals loaded.");
        }
    }
}
