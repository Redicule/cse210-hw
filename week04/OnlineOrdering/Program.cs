using System;

public class Program
{
    public static void Main()
    {
        // First order
        Address address1 = new Address("12 Oak Street", "Denver", "CO", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "A100", 999.99m, 1));
        order1.AddProduct(new Product("Mouse", "M200", 25.50m, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}\n");

        // Second order
        Address address2 = new Address("44 Hillcrest Road", "Cape Town", "WC", "South Africa");
        Customer customer2 = new Customer("Devon Hibbert", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Shirt", "S500", 15.99m, 3));
        order2.AddProduct(new Product("Sneakers", "SN900", 89.99m, 1));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}\n");
    }
}
