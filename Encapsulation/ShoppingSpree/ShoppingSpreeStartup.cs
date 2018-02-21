using System;
using System.Collections.Generic;
using System.Linq;

public class ShoppingSpreeStartup
{
    public static void Main()
    {
        try
        {
            string peopleArgs = Console.ReadLine();
            string productsPricesArgs = Console.ReadLine();
            var peopleData = new List<Person>();
            var productsData = new List<Product>();

            var people = peopleArgs.Split(new[] { ';', '=' }
                 ,StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            var productsPrices = productsPricesArgs
                .Split(new[] { ';', '=' }
                ,StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            ExtractPeopleData(peopleData, people);
            ExtractProductData(productsData, productsPrices);
            string inputLine = string.Empty;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var splitInput = inputLine.Split();
                string personName = splitInput[0];
                string productName = splitInput[1];
                var currentPerson = peopleData.Single(x => x.Name.Equals(personName));
                var currentProduct = productsData.Single(x => x.Name.Equals(productName));
                currentPerson.BuyProduct(currentProduct);

            }
            foreach (var person in peopleData)
            {
                Console.WriteLine(person);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private static void ExtractPeopleData(List<Person> peopleData, string[] people)
    {
        for (int i = 0; i < people.Length; i += 2)
        {
            string name = people[i];
            decimal money = decimal.Parse(people[i + 1]);
            var person = new Person(name, money);
            peopleData.Add(person);
        }
    }

    private static void ExtractProductData(List<Product> productsData, string[] productsPrices)
    {
        for (int i = 0; i < productsPrices.Length; i += 2)
        {
            string name = productsPrices[i];
            decimal price = decimal.Parse(productsPrices[i + 1]);
            var product = new Product(name, price);
            productsData.Add(product);
        }
    }
}


