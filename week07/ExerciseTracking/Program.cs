using System;

class Program
{
    static void Main(string[] args)
    {
        Activity runningActivity = new RunningActivity(30, 5.0);

        Activity cyclingActivity = new CyclingActivity(60, 20.0);

        Activity swimmingActivity = new SwimmingActivity(45, 30.0);

        List<Activity> activities = [
            runningActivity,
            cyclingActivity,
            swimmingActivity
        ];

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary() + "\n");
        }
    }
}