using System;
using System.Collections.Generic;
using System.Linq;

public class CompanyRosterStartup
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var employees = new List<Employee>();
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            string name = input[0];
            var salary = decimal.Parse(input[1]);
            string position = input[2];
            string department = input[3];
            var employee = new Employee(name, salary, position, department);
            for (int j = 4; j < input.Length; j++)
            {
                if (input[j].Contains("@"))
                {
                    var email = input[j];
                    employee.Email = email;
                }
                else
                {
                    employee.Age = input[j];
                }
                employees.Add(employee);
            }
        }
        if (!employees.Any())
        {
            return;
        }
        var highestAvgDepartment = employees.GroupBy(x => x.Department)
                .OrderByDescending(e => e.Average(s => s.Salary)).First().Key;
        var highestAvgSalary = employees.Where(e => e.Department == highestAvgDepartment)
            .OrderByDescending(x => x.Salary);
        Console.WriteLine($"Highest Average Salary: {highestAvgDepartment}");

        foreach (var emp in highestAvgSalary)
        {
            Console.WriteLine($"{emp.Name} {emp.Salary:f2} {emp.Email} {emp.Age}");
        }
    }
}

