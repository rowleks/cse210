public class GoalManager
{
  private List<Goal> goals;
  private int score;

  public GoalManager()
  {
    goals = new List<Goal>();
    score = 0;
  }

  enum MenuOptions
  {
    CreateGoal = 1,
    ListGoals,
    SaveGoals,
    LoadGoals,
    RecordEvent,
    Quit
  }

  public void Start()
  {
    Dictionary<int, string> choices = new()
        {
            { (int)MenuOptions.CreateGoal, "Create New Goal" },
            { (int)MenuOptions.ListGoals, "List Goals" },
            { (int)MenuOptions.SaveGoals, "Save Goals" },
            { (int)MenuOptions.LoadGoals, "Load Goals" },
            { (int)MenuOptions.RecordEvent, "Record Event" },
            { (int)MenuOptions.Quit, "Quit" }
        };

    int choice = 0;

    while (choice != (int)MenuOptions.Quit)
    {
      Console.WriteLine("");
      DisplayPlayerInfo();

      Console.WriteLine("\nMenu Options:");
      foreach (var pair in choices)
      {
        Console.WriteLine($"{pair.Key}. {pair.Value}");
      }
      Console.Write("Select a choice from the menu: ");
      int.TryParse(Console.ReadLine(), out choice);

      switch ((MenuOptions)choice)
      {
        case MenuOptions.CreateGoal:
          Console.WriteLine("");
          CreateGoal();
          break;

        case MenuOptions.ListGoals:
          Console.WriteLine("");
          ListGoalsDetails();
          break;

        case MenuOptions.SaveGoals:
          Console.WriteLine("");
          // Save goals logic here
          Console.WriteLine("Goals saved successfully!");
          Thread.Sleep(2000);
          break;

        case MenuOptions.LoadGoals:
          Console.WriteLine("");
          // Load goals logic here
          Console.WriteLine("Goals loaded successfully!");
          Thread.Sleep(2000);
          break;

        case MenuOptions.RecordEvent:
          Console.WriteLine("");
          RecordEvent();
          break;

        case MenuOptions.Quit:
          Console.WriteLine("");
          Console.WriteLine("Goodbye!");
          break;

        default:
          Console.WriteLine("");
          Console.WriteLine("Invalid choice. Please try again.");
          break;
      }
    }
  }

  public void DisplayPlayerInfo()
  {
    Console.WriteLine($"You currently have {score} {(score > 1 ? "points" : "point")}.");
  }

  public void ListGoalNames()
  {
    if (goals.Count == 0)
    {
      Console.WriteLine("You have no goals.");
      return;
    }
    Console.WriteLine("Your goals:");
    for (int i = 0; i < goals.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {goals[i].GetShortName()}");
    }
  }


  public void ListGoalsDetails()
  {
    if (goals.Count == 0)
    {
      Console.WriteLine("You have no goals.");
      return;
    }

    Console.WriteLine("Your goals:");
    Console.WriteLine(new string('-', 50));

    for (int i = 0; i < goals.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
    }
  }

  public void RecordEvent()
  {
    ListGoalNames();
    Console.Write("Which goal did you accomplish? ");

    int choice;

    while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > goals.Count)
    {
      Console.WriteLine("Invalid choice. Please try again.");
      Console.Write("Which goal did you accomplish? ");
    }

    Goal selectedGoal = goals[choice - 1];
    int pointsEarned = selectedGoal.RecordEvent();
    score += pointsEarned;

    Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points for completing the goal!");
    Console.WriteLine($"Your total score is now {score} points.");
    Thread.Sleep(5000);
    Console.Clear();
  }

  public void CreateGoal()
  {
    ListGoals();
    Console.WriteLine("");
    Console.Write("Which type of goal would you like to create? ");

    int choice;

    while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
    {
      Console.WriteLine("Invalid choice. Please try again.");
      Console.Write("Which type of goal would you like to create? ");
    }

    Console.Write("What is the name of your goal? ");
    string shortName = Console.ReadLine();
    Console.Write("Write a short description of it ");
    string description = Console.ReadLine();
    Console.Write("How many points is it worth? ");
    int points;
    while (!int.TryParse(Console.ReadLine(), out points) || points <= 0)
    {
      Console.WriteLine("Invalid number. Please enter a positive integer.");
      Console.Write("How many points is it worth? ");
    }

    Goal newGoal = null;

    switch (choice)
    {
      case 1:
        newGoal = new SimpleGoal(shortName, description, points);
        break;

      case 2:
        newGoal = new EternalGoal(shortName, description, points);
        break;

      case 3:
        Console.Write("How many times does this goal need to be completed to get a bonus? ");
        int targetEvents;
        while (!int.TryParse(Console.ReadLine(), out targetEvents) || targetEvents <= 0)
        {
          Console.WriteLine("Invalid number. Please enter a positive integer.");
          Console.Write("How many times does this goal need to be completed to get a bonus? ");
        }

        Console.Write("What is the bonus for completing this goal? ");
        int bonusPoints;
        while (!int.TryParse(Console.ReadLine(), out bonusPoints) || bonusPoints < 0)
        {
          Console.WriteLine("Invalid number. Please enter a non-negative integer.");
          Console.Write("What is the bonus for completing this goal? ");
        }

        newGoal = new ChecklistGoal(shortName, description, points, targetEvents, bonusPoints);
        break;
    }

    AddGoal(newGoal);
    Console.WriteLine($"Goal: '{shortName}' created successfully!");
    Thread.Sleep(3000);
    Console.Clear();
  }



  private void AddGoal(Goal goal)
  {
    goals.Add(goal);
  }

  private void RemoveGoal(Goal goal)
  {
    goals.Remove(goal);
  }

  private void ListGoals()
  {
    List<string> goalNames = ["Simple Goal", "Eternal Goal", "Checklist Goal"];
    Console.WriteLine("The types of goals are:");
    for (int i = 0; i < goalNames.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {goalNames[i]}");
    }
  }

}