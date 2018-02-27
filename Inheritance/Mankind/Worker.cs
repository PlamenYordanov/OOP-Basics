using System;
public class Worker : Human
{
    protected decimal weekSalary;
    protected decimal workHoursPerDay;

    public Worker(string firstName, string lastName,
        decimal weekSalary, decimal workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }
    public decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        protected set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            this.weekSalary = value;
        }
    }
    public decimal WorkHoursPerDay
    {
        get
        {
            return this.workHoursPerDay;
        }
        protected set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            this.workHoursPerDay = value;
        }
    }

    public override string ToString()
    {
        decimal salaryPerHour = this.weekSalary / (this.workHoursPerDay * 5);
        return $"First Name: {this.firstName}" + Environment.NewLine +
               $"Last Name: {this.lastName}" + Environment.NewLine +
               $"Week Salary: {this.weekSalary:f2}" + Environment.NewLine +
               $"Hours per day: {this.workHoursPerDay:f2}" + Environment.NewLine +
               $"Salary per hour: {salaryPerHour:f2}";
    }
}

