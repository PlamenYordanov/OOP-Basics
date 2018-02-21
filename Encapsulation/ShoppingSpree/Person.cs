using System.Collections.Generic;
using System;
using System.Linq;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bagOfProducts;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        bagOfProducts = new List<Product>();
    }
    public List<Product> BagOfProducts
    {
        get { return this.bagOfProducts; }
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (value == string.Empty)
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }
    public decimal Money
    {
        get { return this.money; }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }
    }
    public void BuyProduct(Product product)
    {
        if (this.money >= product.Price)
        {
            this.bagOfProducts.Add(product);
            this.money -= product.Price;
            Console.WriteLine($"{this.name} bought {product.Name}");
        }
        else
        {
            Console.WriteLine($"{this.name} can't afford {product.Name}");
        }
    }
    public override string ToString()
    {
        return (bagOfProducts.Any()) ? $"{this.name} - {string.Join(", ", this.bagOfProducts.Select(x => x.Name))}" 
            : $"{this.name} - Nothing bought";
    }
}