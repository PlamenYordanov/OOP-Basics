using System;
public class Startup
{
    static void Main()
    {
        try
        {
            var studentArgs = Console.ReadLine().Split();
            var workerArgs = Console.ReadLine().Split();
            string studentFirstName = studentArgs[0];
            string studentLastName = studentArgs[1];
            string facultyNumber = studentArgs[2];
            Human student = new Student(studentFirstName, studentLastName, facultyNumber);
            string workerFirstName = workerArgs[0];
            string workerLastName = workerArgs[1];
            var salary = decimal.Parse(workerArgs[2]);
            var hoursPerDay = decimal.Parse(workerArgs[3]);
            Human worker = new Worker(workerFirstName, workerLastName, salary, hoursPerDay);
            Console.WriteLine(student + Environment.NewLine);
            Console.WriteLine(worker);
        }
        catch (ArgumentException ae)
        {

            Console.WriteLine(ae.Message);
        }

    }
}

