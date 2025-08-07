public abstract class Goal
{
  protected string _shortName;
  protected string _description;
  protected int _points;

  public Goal(string shortName, string description, int points)
  {
    _shortName = shortName;
    _description = description;
    _points = points;
  }

  public virtual string GetDetailsString()
  {
    string checkMark = Iscomplete() ? "[ x ]" : "[ ]";
    return $"{checkMark} {_shortName} - {_description}";
  }

  public string GetShortName()
  {
    return _shortName;
  }

  public abstract int RecordEvent();
  public abstract string GetStringRep();
  public abstract bool Iscomplete();

}