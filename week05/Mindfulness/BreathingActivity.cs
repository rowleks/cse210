class BreathingActivity : Activity
{
  public BreathingActivity(string name, string description) : base(name, description)
  {

  }

  public void Run()
  {
    Console.Clear();
    Console.WriteLine("Get ready...");
    ShowSpinner(5);

    DateTime start = DateTime.Now;
    DateTime end = start.AddSeconds(GetDuration());

    while (DateTime.Now < end)
    {
      Console.Write("\nBreathe in...");
      ShowCountDown(4);
      Console.WriteLine("");
      Console.Write("Now Breathe out...");
      ShowCountDown(5);
      Console.WriteLine("");
    }

    DisplayEndingMessage();
  }


}