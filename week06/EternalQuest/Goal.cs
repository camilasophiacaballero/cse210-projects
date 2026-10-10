using System;

public abstract class Goal
{
    private string name;
    private string description;
    private int points;

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public int Points { get { return points; } }

    public Goal(string name, string description, int points)
    {
        this.name = name;
        this.description = description;
        this.points = points;
    }

    public abstract int RecordEvent();
    public abstract string GetStatus();
}
