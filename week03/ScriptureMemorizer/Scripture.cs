// I included a ResetWords method in the Scripture class to reset all words to visible.
// I added a GetVisibleWordCount method to count how many words are currently visible.


class Scripture
{
  private Reference _reference;
  private Word[] _words;

  public Scripture(Reference reference, string text)
  {
    _reference = reference;
    _words = CreateWords(text);
  }
  private static Word[] CreateWords(string text)
  {
    return text.Split(' ').Select(wordText => new Word(wordText)).ToArray();
  }

  public int GetVisibleWordCount()
  {
    return _words.Count(word => !word.IsHidden());
  }

  public void ResetWords()
  {
    foreach (Word word in _words)
    {
      if (word.IsHidden())
      {
        word.Show();
      }
    }
  }

  public void HideRandomWords(int count)
  {
    Random random = new();
    int hiddenCount = 0;

    while (hiddenCount < count)
    {
      int index = random.Next(_words.Length);
      if (!_words[index].IsHidden())
      {
        _words[index].Hide();
        hiddenCount++;
      }
    }
  }

  public bool IsCompletelyHidden()
  {
    return _words.All(word => word.IsHidden());
  }

  public string GetDisplayText()
  {
    return $"{_reference.GetDisplayText()} " + string.Join(" ", _words.Select(word => word.GetDisplayText()));
  }
}