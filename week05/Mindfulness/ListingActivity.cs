// I added a feature where no prompts or questions are repeated until all have been used at least once in a session.
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
      "Who are some of your personal heroes?"
    ];
    _count = 0;
  }

  // Fisher-Yates shuffle helper method
  private void ShuffleList<T>(List<T> list, Random rand)
  {
    int n = list.Count;
    for (int i = n - 1; i > 0; i--)
    {
      int j = rand.Next(i + 1);
      T temp = list[i];
      list[i] = list[j];
      list[j] = temp;
    }
  }

  public void DisplayPrompt(string prompt)
  {
    Console.WriteLine("\nList as many responses you can to the following prompt:");
    Console.WriteLine($"--- {prompt} ---");
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

    // Shuffle prompts to avoid repeats
    List<string> shuffledPrompts = [.. _prompts];
    Random rand = new();
    ShuffleList(shuffledPrompts, rand);

    // Display the first prompt from the shuffled list
    string prompt = shuffledPrompts[0];
    DisplayPrompt(prompt);

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