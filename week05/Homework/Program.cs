using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Loius Litt", "Biology");
        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine();

        MathAssignment assignment2 = new MathAssignment("Mike Ross", "Algebra", "3.1", "5-10");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());
        Console.WriteLine();

        WritingAssignment assignment3 = new WritingAssignment("Harvey Specter", "American History", "The Declaration of Independence");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());
    }
}