using System;

public class Book
{
    protected string title;
    protected string author;
    protected decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public string Title
    {
        get
        {
            return this.title;
        }
        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }
    public string Author
    {
        get
        {
            return this.author;
        }
        protected set
        {
            var authorName = value.Split();
            if (authorName.Length == 2)
            {
                char firstLetter = authorName[1][0];
                if (char.IsDigit(firstLetter))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            this.author = value;
        }
    }
    public virtual decimal Price
    {
        get
        {
            return this.price;
        }
        protected set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }
    public override string ToString()
    {
        return $"Type: { this.GetType().Name}" + Environment.NewLine +
               $"Title: {this.Title}" + Environment.NewLine +
               $"Author: { this.Author}" + Environment.NewLine +
               $"Price: { this.Price:f2}";
    }
}



