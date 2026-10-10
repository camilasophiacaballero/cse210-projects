public class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus) : base(name, description, points)
    {
        this.targetCount = targetCount;
        this.bonus = bonus;
        currentCount = 0;
    }

    public override int RecordEvent()
    {
        currentCount++;
        if (currentCount == targetCount)
        {
            return Points + bonus;
        }
        return Points;
    }

    public override string GetStatus()
    {
        return $"Completed {currentCount}/{targetCount}";
    }
}
