class Customer
{
  private string _name;
  private Address _address;

  public Customer(string name, Address address)
  {
    _name = name;
    _address = address;
  }

  public string GetName()
  {
    return _name;
  }


  public string DisplayCustomerAddress()
  {
    return _address.DisplayAddress();
  }


  public bool IsInUSA()
  {
    if (_address.LiveInUSA())
    {
      return true;
    }
    else
    {
      return false;
    }
  }
}
