public class EternalGoal : Goal
{


  public EternalGoal(string shortName, string description, int points)
      : base(shortName, description, points)
  {
    // Eternal goals do not have a completion status
    // They are always available and never complete
  }

  public override int RecordEvent()
  {
    return _points; // Return points for recording an event
    // Eternal goals do not change their completion status
  }

  public override string GetStringRep()
  {
    return $"EternalGoal:{_shortName}|{_description}|{_points}";
  }

  public override bool Iscomplete()
  {
    return false; // Eternal goals are never complete
  }
}