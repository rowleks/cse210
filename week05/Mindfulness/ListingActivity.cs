class ListingActivity : Activity
{

  private int _count;
  private List<string> _prompts;

  public ListingActivity(string name, string description) : base(name, description)
  {
    _prompts = [
      "Who are people that you appreciate?",
      "What are personal strengths of yours?",
      "Who are people that you have helped this week?",
      "When have you felt the Holy Ghost this month?",
      "Who are some of your personal heroes?"];
    _count = 0;
  }

  public void GetRandomPrompt()
  {
    Random random = new Random();
    int index = random.Next(0, _prompts.Count);
    Console.WriteLine("\nList as many responses you can to the following prompt:");
    Console.WriteLine($"--- {_prompts[index]} ---");
  }

  public List<string> GetListFromUser()
  {
    List<string> userInput = [];
    Console.Write("> ");
    string input = Console.ReadLine();

    userInput.Add(input);
    return userInput;

  }

  public void Run()
  {
    Console.Clear();
    Console.WriteLine("Get ready...");
    ShowSpinner(5);

    GetRandomPrompt();

    Console.Write("You may begin in: ");
    ShowCountDown(5);
    Console.WriteLine("");

    DateTime start = DateTime.Now;
    DateTime end = start.AddSeconds(GetDuration());

    while (DateTime.Now < end)
    {
      GetListFromUser();
      _count++;
    }

    Console.WriteLine($"You listed {_count} responses.");

    DisplayEndingMessage();
  }


}