using System;
public class Human
{
    protected string firstName;
    protected string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        protected set
        {
            if (value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }

            char firstLetter = value[0];

            if (!char.IsUpper(firstLetter))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            this.firstName = value;
        }

    }
    public string LastName
    {
        get
        {
            return this.lastName;
        }
        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            char firstLetter = value[0];
            if (!char.IsUpper(firstLetter))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }

            this.lastName = value;
        }
    }
}

