// I added a feature to remove a goal from the list of goals
// I also added a spinner animation when saving and loading goals from a file

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}