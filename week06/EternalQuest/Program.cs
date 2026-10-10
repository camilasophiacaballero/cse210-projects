using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save");
            Console.WriteLine("6. Load");
            Console.WriteLine("7. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Choose type: 1=Simple, 2=Eternal, 3=Checklist");
                    string type = Console.ReadLine();
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Description: ");
                    string description = Console.ReadLine();
                    Console.Write("Points: ");
                    int points = int.Parse(Console.ReadLine());

                    if (type == "1") manager.AddGoal(new SimpleGoal(name, description, points));
                    else if (type == "2") manager.AddGoal(new EternalGoal(name, description, points));
                    else if (type == "3")
                    {
                        Console.Write("Target count: ");
                        int target = int.Parse(Console.ReadLine());
                        Console.Write("Bonus: ");
                        int bonus = int.Parse(Console.ReadLine());
                        manager.AddGoal(new ChecklistGoal(name, description, points, target, bonus));
                    }
                    break;

                case "2":
                    manager.DisplayGoals();
                    Console.Write("Select goal number: ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordGoal(index);
                    break;

                case "3":
                    manager.DisplayGoals();
                    break;

                case "4":
                    manager.DisplayScore();
                    break;

                case "5":
                    manager.Save("goals.txt");
                    break;

                case "6":
                    manager.Load("goals.txt");
                    break;

                case "7":
                    running = false;
                    break;
            }
        }
    }
}
