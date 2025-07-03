public class Resume
{
  public string _name;
  public List<Job> _jobs = new List<Job>();

  public void Display()
  {
    Console.WriteLine("");
    Console.WriteLine($"Name: {_name}");
    Console.WriteLine("Jobs: ");
    _jobs.ForEach(job => job.Display());
  }

}