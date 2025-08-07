using System.IO;

public class GoalManager
{
  private List<Goal> _goals;
  private int _score;

  public GoalManager()
  {
    _goals = new List<Goal>();
    _score = 0;
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

  // ------------- Main function -----------------

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
      _ = int.TryParse(Console.ReadLine(), out choice);

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

          SaveGoals();
          Thread.Sleep(2000);
          Console.Clear();
          break;

        case MenuOptions.LoadGoals:
          Console.WriteLine("");

          LoadGoals();
          Thread.Sleep(2000);
          Console.Clear();
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

  // ------------ MenuOption methods ----------------

  public void RecordEvent()
  {
    ListGoalNames();
    Console.Write("Which goal did you accomplish? ");

    int choice;

    while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > _goals.Count)
    {
      Console.WriteLine("Invalid choice. Please try again.");
      Console.Write("Which goal did you accomplish? ");
    }

    Goal selectedGoal = _goals[choice - 1];
    int pointsEarned = selectedGoal.RecordEvent();
    _score += pointsEarned;

    Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points for completing the goal!");
    Console.WriteLine($"Your total score is now {_score} points.");
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

  public void SaveGoals()
  {
    Console.Write("What name would you like to save your goals as? ");
    string fileName = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(fileName))
    {
      Console.WriteLine("Invalid file name. Please try again.");
      return;
    }

    try
    {
      using (StreamWriter writer = new StreamWriter(fileName))
      {
        writer.WriteLine(_score.ToString());
        foreach (Goal goal in _goals)
        {
          writer.WriteLine(goal.GetStringRep());
        }
      }
      Console.WriteLine($"Goals saved to {fileName} successfully!");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error saving goals: {ex.Message}");
    }
  }

  public void LoadGoals()
  {
    Console.Write("What file would you like to load your goals from? ");
    string fileName = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(fileName))
    {
      Console.WriteLine("Invalid file name. Please try again.");
      return;
    }

    try
    {
      using (StreamReader reader = new StreamReader(fileName))
      {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
          // Handle the first line as the score
          if (int.TryParse(line, out int loadedScore))
          {
            _score = loadedScore;
            continue;
          }
          Goal goal = CreateGoalFromString(line);
          if (goal != null)
          {
            AddGoal(goal);
          }
        }
      }
      Console.WriteLine($"Goals loaded from {fileName} successfully!");
    }
    catch (Exception e)
    {
      Console.WriteLine($"Error loading goals: {e.Message}");
    }
  }

  // ------------- Display functions-------------------



  public void DisplayPlayerInfo()
  {
    Console.WriteLine($"You currently have {_score} {(_score > 1 ? "points" : "point")}.");
  }

  public void ListGoalNames()
  {
    if (_goals.Count == 0)
    {
      Console.WriteLine("You have no goals.");
      return;
    }
    Console.WriteLine("Your goals:");
    for (int i = 0; i < _goals.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
    }
  }


  public void ListGoalsDetails()
  {
    if (_goals.Count == 0)
    {
      Console.WriteLine("You have no goals.");
      return;
    }

    Console.WriteLine("Your goals:");
    Console.WriteLine(new string('-', 50));

    for (int i = 0; i < _goals.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
    }
  }

  // --------------- Helper functions -------------------
  private void AddGoal(Goal goal)
  {
    _goals.Add(goal);
  }

  private void RemoveGoal(Goal goal)
  {
    _ = _goals.Remove(goal);
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

  private Goal CreateGoalFromString(string line)
  {
    string[] parts = line.Split('|');
    if (parts.Length == 0) return null;
    string[] splitType = parts[0].Split(":");
    string goalType = splitType[0];

    string shortName = splitType[1];
    string description = parts[1];
    int points = int.Parse(parts[2]);

    switch (goalType)
    {
      case "SimpleGoal":

        _ = bool.TryParse(parts[3], out bool isComplete);

        return new SimpleGoal(shortName, description, points, isComplete);

      case "EternalGoal":
        return new EternalGoal(shortName, description, points);

      case "ChecklistGoal":
        _ = int.TryParse(parts[3], out int bonusPoints);
        _ = int.TryParse(parts[4], out int targetAmount);
        _ = int.TryParse(parts[5], out int amountCompleted);
        return new ChecklistGoal(shortName, description, points, targetAmount, bonusPoints, amountCompleted);

      default:
        return null;
    }
  }

}