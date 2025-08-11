public class RunningActivity : Activity
{
  private double _distance; // in kilometers

  public RunningActivity(int duration, double distance)
    : base(duration, "Running")
  {
    _distance = distance;
  }

  public override double GetDistance()
  {
    return _distance;
  }

  public override double GetSpeed()
  {
    return _distance / GetDuration() * 60; // speed in kph
  }

  public override double GetPace()
  {
    return GetDuration() / _distance; // pace in min per km
  }
}