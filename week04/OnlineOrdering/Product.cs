class Product
{
  private string _name;
  private double _price;
  private string _product_id;
  private int _quantity;
  private double _total;


  public Product(string name, double price, string product_id, int quantity)
  {
    _name = name;
    _price = price;
    _product_id = product_id;
    _quantity = quantity;
    _total = _price * _quantity;
  }

  public double GetTotal()
  {
    return _total;
  }

  public string DisplayProduct()
  {
    return $"{_product_id} - {_name}";
  }
}