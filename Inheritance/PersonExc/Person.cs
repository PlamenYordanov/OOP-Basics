using System;
using System.Text;

public class Person
{
    private string name;

    private int age;

    protected virtual string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }
            this.name = value;
        }
    }

    protected virtual int Age
    {
        get
        {
            return this.age;
        }
         set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }
            this.age = value;
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"Name: {this.Name}, Age: {this.Age}");
        return stringBuilder.ToString();
    }
}

