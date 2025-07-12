using System;

public class Fraction
{
  private int _top;
  private int _bottom;

  public Fraction()
  {
    _top = 1;
    _bottom = 1;
  }

  public Fraction(int wholeNumber)
  {
    _top = wholeNumber;
    _bottom = 1;
  }

  public Fraction(int top, int bottom)
  {
    _top = top;
    _bottom = bottom;
  }

  public string GetFractionString()
  {
    if (_bottom == 0)
    {
      throw new DivideByZeroException("The denominator cannot be zero.");
    }
    string text = $"{_top}/{_bottom}";
    return text;
  }

  public float GetDecimalValue()
  {

    return _top / (float)_bottom;
  }
}