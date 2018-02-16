using System;
using System.Collections.Generic;
using System.Linq;

public class CatLadyStartup
{
    public static void Main()
    {
        string input = string.Empty;
        var cats = new List<Cat>();

        while ((input = Console.ReadLine()) != "End")
        {
            var catInfo = input.Split();
            string breed = catInfo[0];
            string name = catInfo[1];
            Cat cat = null;
            switch (breed.ToLower())
            {
                case "siamese":
                    int earSize = int.Parse(catInfo[2]);
                    cat = new Siamese(name, earSize);
                    break;
                case "cymric":
                    var furLength = double.Parse(catInfo[2]);
                    cat = new Cymric(name, furLength);
                    break;
                case "streetextraordinaire":
                    int decibels = int.Parse(catInfo[2]);
                    cat = new StreetExtraordinaire(name, decibels);
                    break;
                default:
                    break;
            }
            cats.Add(cat);
        }
        input = Console.ReadLine();

        var currentCat = cats.SingleOrDefault(x => x.Name == input);

        switch (currentCat)
        {
            case Siamese s:
                Console.WriteLine(s);
                break;
            case Cymric c:
                Console.WriteLine(c);
                break;
            case StreetExtraordinaire str:
                Console.WriteLine(str);
                break;
            default:
                break;
        }
    }
}

