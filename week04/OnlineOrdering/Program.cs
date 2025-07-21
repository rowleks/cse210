using System;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address addr1 = new("123 Main St", "Salt Lake City", "UT", "USA");
        Address addr2 = new("456 Maple Ave", "Toronto", "ON", "Canada");
        Address addr3 = new("789 Oak Rd", "Austin", "TX", "USA");

        // Create customers
        Customer cust1 = new("Alice Smith", addr1);
        Customer cust2 = new("Samuel Johnson", addr2);
        Customer cust3 = new("Carol Raymond", addr3);

        // Create products
        Product prod1 = new("Dell Laptop", 999.99, "P001", 1);
        Product prod2 = new("JBL Headphones", 299.99, "P002", 2);
        Product prod3 = new("Samsung Smartphones", 149.99, "P003", 3);

        Order order1 = new(cust1, new Product[] { prod1, prod2, prod3 });
        Order order2 = new(cust2, new Product[] { prod2, prod3 });
        Order order3 = new(cust3, new Product[] { prod1, prod3 });


        Order[] orders = { order1, order2, order3 };
        foreach (Order order in orders)
        {
            Console.WriteLine(order.DisplayPackingLabel());
            Console.WriteLine(order.DisplayShippingLabel());
            Console.WriteLine($"Order Total: ${order.CalculateTotal()}");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("");
        }
    }
}