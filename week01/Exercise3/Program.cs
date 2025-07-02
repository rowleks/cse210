using System;

class Program
{
    static void Main(string[] args)
    {

        string play;

        do
        {
            Random randomGen = new Random();
            int magicNumber = randomGen.Next(1, 21);
            int guess = 0;
            int playCount = 1;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                    playCount++;
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                    playCount++;
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {playCount} guesses");
                }


            }

            Console.Write("Would you like to play again? (yes/no) ");
            play = Console.ReadLine();
            Console.WriteLine("");


        }
        
        while (play == "yes");

    }
}