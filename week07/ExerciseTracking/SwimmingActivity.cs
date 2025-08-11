public class SwimmingActivity : Activity
{
  private double _laps; // number of laps

  public SwimmingActivity(int duration, double laps)
    : base(duration, "Swimming")
  {
    _laps = laps;
  }

  public override double GetDistance()
  {
    return _laps * 50 / 1000; // assuming each lap is 50 meters, convert to kilometers
  }

  public override double GetSpeed()
  {
    return GetDistance() / GetDuration() * 60; // speed in kph
  }

  public override double GetPace()
  {
    return 60 / GetSpeed(); // pace in min per km
  }
}