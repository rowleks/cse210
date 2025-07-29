// I added a feature where no prompts or questions are repeated until all have been used at least once in a session.


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
    Random random = new();
    int index = random.Next(0, _prompts.Count);
    return _prompts[index];
  }

  public string GetRandomQuestion()
  {
    Random random = new();
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

  public void Run()
  {
    Console.Clear();
    Console.WriteLine("Get ready...");
    ShowSpinner(5);

    // Shuffle prompts to avoid repeats
    List<string> shuffledPrompts = new List<string>(_prompts);
    Random rand = new();
    ShuffleList(shuffledPrompts, rand);

    // Shuffle questions to avoid repeats
    List<string> shuffledQuestions = new List<string>(_questions);
    ShuffleList(shuffledQuestions, rand);

    DateTime start = DateTime.Now;
    DateTime end = start.AddSeconds(GetDuration());
    int promptIndex = 0;
    int questionIndex = 0;

    while (DateTime.Now < end)
    {
      // Show prompt (cycle through all prompts before repeating)
      if (promptIndex >= shuffledPrompts.Count)
      {
        promptIndex = 0;
        ShuffleList(shuffledPrompts, rand);
      }
      string prompt = shuffledPrompts[promptIndex];
      Console.WriteLine("\nReflect on the following prompt:");
      Console.WriteLine($"--- {prompt} ---");
      promptIndex++;

      Console.Write("When you're ready, press enter to continue... ");
      Console.ReadLine();
      Console.WriteLine("");

      Console.WriteLine("Now ponder on each of the following questions as they relate to this experience:");
      Console.Write("You may begin in: ");
      ShowCountDown(5);
      Console.Clear();

      // Show all questions for this prompt (cycle through all questions before repeating)
      questionIndex = 0;
      ShuffleList(shuffledQuestions, rand);
      foreach (var question in shuffledQuestions)
      {
        Console.Write($"> {question} ");
        ShowSpinner(5);
        Console.WriteLine("");
        questionIndex++;
        if (DateTime.Now >= end) break;
      }
    }

    DisplayEndingMessage();
  }

}