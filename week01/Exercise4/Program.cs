using System;

class Program
{
    static void Main(string[] args)
    {
        string userInput = "";
        float sum = 0;

        List<float> numbers = new List<float>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (userInput != "0")
        {
            Console.Write("Enter a number: ");
            userInput = Console.ReadLine();
            if (userInput != "0")
            {
                numbers.Add(float.Parse(userInput));
            }
        }

        foreach (float number in numbers)
        {
            sum += number;
        }

        float average = sum / numbers.Count;
        float largest = numbers.Max();

        Console.WriteLine("");

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}