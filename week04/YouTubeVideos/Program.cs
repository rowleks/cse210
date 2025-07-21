using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new("Top 10 Movies of All Time", "Rowland Momoh", 180);
        video1.AddComment(new Comment("Alice", "Great list, but where's The Godfather?"));
        video1.AddComment(new Comment("Bob", "Totally agree with #1!"));
        video1.AddComment(new Comment("Charlie", "Nice editing."));

        Video video2 = new("How to make the perfect omelette", "CookingWithChris", 450);
        video2.AddComment(new Comment("Dana", "My omelette came out perfectly, thanks!"));
        video2.AddComment(new Comment("Eve", "I always burn mine, this helped a lot."));
        video2.AddComment(new Comment("Frank", "What kind of pan are you using?"));
        video2.AddComment(new Comment("Grace", "Simple and delicious."));

        Video video3 = new("C# for Beginners", "CodeAcademy", 1200);
        video3.AddComment(new Comment("Heidi", "This is the best C# intro I've seen."));
        video3.AddComment(new Comment("Ivan", "Can you do a video on advanced topics?"));
        video3.AddComment(new Comment("Judy", "Very clear explanations. Subscribed!"));

        Video[] videos = { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine("Video details:");
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of comments: {video.CommentsCount()}");

            Console.WriteLine("");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"- {comment._username}");
                Console.WriteLine(comment._text);
            }
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("");
        }
    }

}