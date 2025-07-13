// I added a reset feature to show all the words again when the user types 'reset'.


using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new("John", 3, 16);
        Scripture scripture = new(reference, "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have eternal life.");

        Console.WriteLine("");
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("Press Enter to hide random words or type 'quit' to exit.");

        string input = Console.ReadLine();
        while (input.ToLower() != "quit")
        {
            if (input.ToLower() == "reset")
            {
                scripture.ResetWords();
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("Press Enter to hide random words, type 'reset' to show all the words, or type 'quit' to exit.");
                input = Console.ReadLine();
                continue;
            }

            if (!scripture.IsCompletelyHidden())
            {
                Console.Clear();

                int visibleWordsCount = scripture.GetVisibleWordCount();


                if (visibleWordsCount < 3)
                {
                    scripture.HideRandomWords(visibleWordsCount);
                }
                else
                {
                    scripture.HideRandomWords(3);
                }

                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("Press Enter to hide random words, type 'reset' to show all the words, or type 'quit' to exit.");
                input = Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("All words are hidden. Type 'reset' to show all the words, Press Enter or type 'quit' to exit.");
                input = Console.ReadLine();
                if (input.Length == 0 || input.ToLower() == "quit")
                {
                    break;
                }

            }
        }
    }
}