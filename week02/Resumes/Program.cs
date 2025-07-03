using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        Job job2 = new Job();

        job1._jobTitle = "Frontend Developer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        job2._jobTitle = "Software Engineer";
        job2._company = "Apple";
        job2._startYear = 2023;
        job2._endYear = 2024;

        // job1.Display();
        // job2.Display();

        Resume myResume = new Resume();
        myResume._name = "Rowland Momoh";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();

    }
}