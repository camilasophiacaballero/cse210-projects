public class SimpleGoal : Goal
{
    private bool isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        isComplete = false;
    }

    public override int RecordEvent()
    {
        if (!isComplete)
        {
            isComplete = true;
            return Points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return isComplete ? "[X]" : "[ ]";
    }
}
