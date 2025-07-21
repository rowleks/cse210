class Order
{
  private Customer _customer;
  private Product[] _products;

  public Order(Customer customer, Product[] products)
  {
    _customer = customer;
    _products = products;
  }

  public double CalculateTotal()
  {
    double total = 0;
    foreach (Product product in _products)
    {
      total += product.GetTotal();
    }
    if (_customer.IsInUSA())
    {
      total += 5;
    }
    else
    {
      total += 35;
    }
    return total;
  }

  public string DisplayPackingLabel()
  {
    string label = "ID - Product\n";
    foreach (Product product in _products)
    {
      label += $"{product.DisplayProduct()}\n";
    }
    return label;
  }

  public string DisplayShippingLabel()
  {
    string label = "";
    label += $"- {_customer.GetName()}\n{_customer.DisplayCustomerAddress()}";
    return label;
  }

}