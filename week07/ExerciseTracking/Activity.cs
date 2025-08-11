public abstract class Activity
{
  private string _date;
  private int _duration; // in minutes
  private string _type;

  public Activity(int duration, string type)
  {
    _date = DateTime.Now.ToString("dd MMM yyyy");
    _duration = duration;
    _type = type;
  }

  public virtual string GetSummary()
  {
    return $"{_date} {_type} ({_duration} min) - Distance: {GetDistance():F2} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
  }

  public int GetDuration()
  {
    return _duration;
  }

  public abstract double GetDistance();
  public abstract double GetSpeed();
  public abstract double GetPace();
}