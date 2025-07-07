// I added a delete feature where users can delete an entry by ID.

using System;

class Program
{
    static void Main(string[] args)
    {
        List<string> choices = ["Write", "Display", "Load", "Save", "Delete", "Quit"];
        string choice = "";
        Journal journal = new();

        while (choice != "6")
        {
            Console.WriteLine("\nPlease select one of the following choices:");

            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {choices[i]}");
            }

            Console.WriteLine("");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();
            Console.WriteLine("");

            switch (choice)
            {
                case "1":
                    PromptGenerator promptGenerator = new();
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string entry = Console.ReadLine();

                    Entry newEntry = new()
                    {
                        _date = DateTime.Now.ToShortDateString(),
                        _promptText = prompt,
                        _entryText = entry
                    };

                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    if (journal._entries.Count > 0)
                    {
                        journal.DisplayAll();
                    }
                    else
                    {
                        Console.WriteLine("No entries to display.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Load from?");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.WriteLine("Save as?");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "5":
                    if (journal._entries.Count > 0)
                    {
                        journal.DisplayAll();
                        Console.Write("Enter the number of the entry to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int entryNumber))
                        {
                            journal.DeleteEntry(entryNumber - 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No entries to delete.");
                    }
                    break;

                default:
                    Console.WriteLine("Goodbye!\n");
                    choice = "6";
                    break;

            }

        }
    }
}