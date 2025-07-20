// I added a delete feature where users can delete an entry by ID.

using System;

enum MenuAction
{
    Write = 1,
    Display,
    Load,
    Save,
    Delete,
    Quit
}

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, string> choices = new()
        {
            { (int)MenuAction.Write, "Write" },
            { (int)MenuAction.Display, "Display" },
            { (int)MenuAction.Load, "Load" },
            { (int)MenuAction.Save, "Save" },
            { (int)MenuAction.Delete, "Delete" },
            { (int)MenuAction.Quit, "Quit" }
        };

        int choice = 0;
        Journal journal = new();

        while (choice != (int)MenuAction.Quit)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            foreach (var pair in choices)
            {
                Console.WriteLine($"{pair.Key}. {pair.Value}");
            }

            Console.WriteLine("");
            Console.Write("What would you like to do? ");
            int.TryParse(Console.ReadLine(), out choice);
            Console.WriteLine("");

            switch ((MenuAction)choice)
            {
                case MenuAction.Write:
                    journal.CreateEntry();
                    break;

                case MenuAction.Display:
                    if (journal._entries.Count > 0)
                        journal.DisplayAll();
                    else
                        Console.WriteLine("No entries to display.");
                    break;

                case MenuAction.Load:
                    journal.Load();
                    break;

                case MenuAction.Save:
                    journal.Save();
                    break;

                case MenuAction.Delete:
                    journal.Delete();
                    break;

                case MenuAction.Quit:
                    Console.WriteLine("Goodbye!\n");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}