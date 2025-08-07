public class SimpleGoal : Goal
{
  private bool _isComplete;

  public SimpleGoal(string shortName, string description, int points)
      : base(shortName, description, points)
  {
    _isComplete = false;
  }

  public override int RecordEvent()
  {
    _isComplete = true;
    return _points; // Return points for completing the goal
  }

  public override string GetStringRep()
  {
    return $"SimpleGoal:{_shortName}|{_description}|{_points}|{_isComplete}";
  }

  public override bool Iscomplete()
  {
    return _isComplete;
  }
}