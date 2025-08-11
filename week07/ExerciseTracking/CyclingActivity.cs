public class CyclingActivity : Activity
{
  private double _distance; // in kilometers

  public CyclingActivity(int duration, double distance)
    : base(duration, "Cycling")
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