class Activity
{
  private string _name;
  private string _description;
  private int _duration;

  public Activity(string name, string description)
  {
    _name = name;
    _description = description;
  }

  public void DisplayStartingMessage()
  {
    Console.Clear();
    Console.WriteLine($"\nWelcome to the {_name}.\n");
    Console.WriteLine($"{_description}\n");
    Console.Write("How long, in seconds, would you like for your session? ");
    _duration = int.Parse(Console.ReadLine());
  }
  public void DisplayEndingMessage()
  {
    Console.WriteLine("\nWell done!!");
    ShowSpinner(5);

    Console.WriteLine("");

    Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
    ShowSpinner(5);
  }

  public void ShowSpinner(int seconds)
  {
    List<string> spinner = ["-", "\\", "|", "/"];
    for (int i = 0; i < seconds; i++)
    {
      Console.Write(spinner[i % 4]);
      Thread.Sleep(1000);
      Console.Write("\b \b");
    }
  }

  public void ShowCountDown(int seconds)
  {
    for (int i = seconds; i > 0; i--)
    {
      Console.Write(i);
      Thread.Sleep(1000);
      Console.Write("\b \b");
    }
  }

  public int GetDuration()
  {
    return _duration;
  }

}