using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            return Console.ReadLine();
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favourite number: ");
            return int.Parse(Console.ReadLine());

        }

        static int SquareNumber(int number)
        {
            return number * number;
        }

        static void DisplayResult(string name, int number)
        {
            Console.WriteLine($"Hello {name}, your favourite number squared is {number}.");

        }

        DisplayWelcome();
        string name = PromptUserName();
        int favouriteNumber = PromptUserNumber();
        int favNumSquared = SquareNumber(favouriteNumber);
        DisplayResult(name, favNumSquared);

    }
}