using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = [new Square("Blue", 7), new Rectangle("Red", 4, 6), new Circle("Yellow", 5)];

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}, Area: {shape.GetArea():F2}");
        }

    }
}