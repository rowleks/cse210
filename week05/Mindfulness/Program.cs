using System;

class Program
{
    enum MenuAction
    {
        BreathingActivity = 1,
        ReflectingActivity,
        ListingActivity,
        Quit
    }
    static void Main(string[] args)
    {
        Dictionary<int, string> choices = new()
        {
            { (int)MenuAction.BreathingActivity, "Start Breathing Activity" },
            { (int)MenuAction.ReflectingActivity, "Start Reflecting Activity" },
            { (int)MenuAction.ListingActivity, "Start Listing Activity" },
            { (int)MenuAction.Quit, "Quit" }
        };

        int choice = 0;
        while (choice != (int)MenuAction.Quit)
        {
            Console.Clear();
            Console.WriteLine("\nMenu Options:");
            foreach (var pair in choices)
            {
                Console.WriteLine($"{pair.Key}. {pair.Value}");
            }

            Console.Write("Select a choice from the menu: ");
            int.TryParse(Console.ReadLine(), out choice);

            switch ((MenuAction)choice)
            {
                case MenuAction.BreathingActivity:
                    BreathingActivity breathingActivity = new("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
                    breathingActivity.DisplayStartingMessage();
                    breathingActivity.Run();
                    break;

                case MenuAction.ListingActivity:
                    ListingActivity listingActivity = new("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

                    listingActivity.DisplayStartingMessage();
                    listingActivity.Run();
                    break;
            }

        }
    }
}