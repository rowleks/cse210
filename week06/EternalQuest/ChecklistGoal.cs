public class ChecklistGoal : Goal
{
  private int _amountCompleted;
  private int _targetAmount;
  private int _bonusPoints;

  public ChecklistGoal(string shortName, string description, int points, int targetAmount, int bonusPoints)
      : base(shortName, description, points)
  {
    _targetAmount = targetAmount;
    _bonusPoints = bonusPoints;
    _amountCompleted = 0;
  }

  public override int RecordEvent()
  {
    _amountCompleted++;
    return _amountCompleted == _targetAmount ? _points + _bonusPoints : _points;
  }

  public override string GetDetailsString()
  {
    string checkMark = Iscomplete() ? "[ x ]" : "[ ]";
    return $"{checkMark} {_shortName} - {_description} (Completed: {_amountCompleted}/{_targetAmount})";
  }

  public override string GetStringRep()
  {
    return $"ChecklistGoal:{_shortName}|{_description}|{_points}|{_bonusPoints}|{_targetAmount}|{_amountCompleted}";
  }

  public override bool Iscomplete()
  {
    return _amountCompleted >= _targetAmount; // Check if the target amount is reached
  }
}