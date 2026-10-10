using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> goals;
    private int score;

    public GoalManager()
    {
        goals = new List<Goal>();
        score = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordGoal(int index)
    {
        if (index >= 0 && index < goals.Count)
        {
            score += goals[index].RecordEvent();
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()} {goals[i].Name} ({goals[i].Description})");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Score: {score}");
    }

    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(score);
            foreach (Goal goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Description}|{goal.Points}");
            }
        }
    }

    public void Load(string filename)
    {
        goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        score = int.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            if (type == "SimpleGoal") goals.Add(new SimpleGoal(name, description, points));
            else if (type == "EternalGoal") goals.Add(new EternalGoal(name, description, points));
            else if (type == "ChecklistGoal") goals.Add(new ChecklistGoal(name, description, points, 5, 500));
        }
    }
}
