using System;
using System.Linq;

public class Student : Human
{
    protected string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get
        {
            return this.facultyNumber;
        }
        protected set
        {
            bool isDigitOrLetter = value.All(c => char.IsLetterOrDigit(c));
            if (value.Length < 5 || value.Length > 10 || !isDigitOrLetter)
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {this.firstName}" + Environment.NewLine +
               $"Last Name: {this.lastName}" + Environment.NewLine +
               $"Faculty number: {this.facultyNumber}";
    }
}

