using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "L123", 1200, 1));
        order1.AddProduct(new Product("Mouse", "M456", 25, 2));

        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Headphones", "H789", 80, 1));
        order2.AddProduct(new Product("Keyboard", "K321", 45, 1));
        order2.AddProduct(new Product("Monitor", "MN654", 200, 1));

        Console.WriteLine("Order 1 Packing Label:\n" + order1.GetPackingLabel());
        Console.WriteLine("Order 1 Shipping Label:\n" + order1.GetShippingLabel());
        Console.WriteLine("Order 1 Total Cost: $" + order1.GetTotalCost());

        Console.WriteLine("\nOrder 2 Packing Label:\n" + order2.GetPackingLabel());
        Console.WriteLine("Order 2 Shipping Label:\n" + order2.GetShippingLabel());
        Console.WriteLine("Order 2 Total Cost: $" + order2.GetTotalCost());
    }
}
