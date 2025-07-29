class ReflectingActivity : Activity
{

  List<string> _prompts;
  List<string> _questions;

  public ReflectingActivity(string name, string description) : base(name, description)
  {
    _prompts = [
    "Think of a time when you stood up for someone else.",
    "Think of a time when you did something really difficult.",
    "Think of a time when you helped someone in need.",
    "Think of a time when you did something truly selfless."
    ];

    _questions = [
      "Why was this experience meaningful to you?",
      "Have you ever done anything like this before?",
      "How did you get started?",
      "How did you feel when it was complete?",
      "What made this time different than other times when you were not as successful?",
      "What is your favorite thing about this experience?",
      "What could you learn from this experience that applies to other situations?",
      "What did you learn about yourself through this experience?",
      "How can you keep this experience in mind in the future?"
    ];
  }

  public string GetRandomPrompt()
  {
    Random random = new Random();
    int index = random.Next(0, _prompts.Count);
    return _prompts[index];
  }

  public string GetRandomQuestion()
  {
    Random random = new Random();
    int index = random.Next(0, _questions.Count);
    return _questions[index];
  }

  public void DisplayPrompt()
  {
    string prompt = GetRandomPrompt();
    Console.WriteLine("\nReflect on the following prompt:");
    Console.WriteLine($"--- {prompt} ---");
  }

  public void DisplayQuestion()
  {
    string question = GetRandomQuestion();
    Console.Write($"> {question} ");
  }

  public void Run()
  {
    Console.Clear();
    Console.WriteLine("Get ready...");
    ShowSpinner(5);

    DisplayPrompt();
    Console.Write("When you're ready, press enter to continue... ");
    Console.ReadLine();
    Console.WriteLine("");

    Console.WriteLine("Now ponder on each of the following questions as they related to this experience:");
    Console.Write("You may begin in: ");
    ShowCountDown(5);
    Console.Clear();

    DateTime start = DateTime.Now;
    DateTime end = start.AddSeconds(GetDuration());

    while (DateTime.Now < end)
    {
      DisplayQuestion();
      ShowSpinner(5);
      Console.WriteLine("");
    }

    DisplayEndingMessage();
  }

}