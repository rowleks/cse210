using System.IO;

class Journal
{
  public List<Entry> _entries = [];

  public void AddEntry(Entry newEntry)
  {
    _entries.Add(newEntry);
  }
  public void DisplayAll()
  {
    for (int i = 0; i < _entries.Count; i++)
    {
      Console.WriteLine($"Entry ID: {i + 1}");
      _entries[i].Display();
      Console.WriteLine("");
    }
  }

  public void SaveToFile(string fileName)
  {
    using (StreamWriter writer = new(fileName))
    {
      foreach (Entry entry in _entries)
      {
        writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
      }
    }

    Console.WriteLine("Journal saved to file successfully");
  }

  public void LoadFromFile(string fileName)
  {
    if (File.Exists(fileName))
    {
      string[] lines = File.ReadAllLines(fileName);
      foreach (string line in lines)
      {
        string[] parts = line.Split("|");
        if (parts.Length == 3)
        {
          Entry entry = new()
          {
            _date = parts[0],
            _promptText = parts[1],
            _entryText = parts[2]
          };
          _entries.Add(entry);
        }
      }
      Console.WriteLine("Journal loaded from file successfully.");
    }
    else
    {
      Console.WriteLine("File not found.");
    }
  }

  public void DeleteEntry(int index)
  {
    if (index >= 0 && index < _entries.Count)
    {
      _entries.RemoveAt(index);
      Console.WriteLine("Entry deleted successfully.");
    }
    else
    {
      Console.WriteLine("Invalid entry number.");
    }
  }
}
