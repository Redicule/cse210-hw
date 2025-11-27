using System.Collections.Generic;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal productTotal = 0;

        foreach (var product in _products)
        {
            productTotal += product.GetTotalCost();
        }

        decimal shippingCost = _customer.LivesInUSA() ? 5m : 35m;

        return productTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing List:\n";

        foreach (var product in _products)
        {
            label += $"- {product.GetProductLabel()}\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddressString()}";
    }
}
