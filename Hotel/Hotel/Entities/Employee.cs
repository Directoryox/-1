namespace Hotel.Entities;

public class Employee(string name, string surname, string email, string phoneNumber,
    int age, decimal salary, string position, string department) : Person(name, surname, email, phoneNumber, age)
{
    private decimal Salary { get; set; } = salary;
    private string Position { get; set; } = position;
    private string Department { get; set; } = department;

    public virtual void Work()
    {
        Console.WriteLine($"Working... In {Department} Department as {Position}.");
    }

    public virtual void IncreaseGrade(string newDepartment, string newPosition)
    {
        Console.WriteLine("Increasing grade...");
        Department = newDepartment;
        Position = newPosition;
        Salary *= 1.50m;

        Console.WriteLine($"New salary: {Salary}, new position: {Position} and new department: {Department}.");
    }

    public virtual void IncreaseSalary(decimal increase)
    {
        Salary += increase;
        Console.WriteLine($"Salary increased by {increase}. New salary: {Salary}.");
    }

    public virtual decimal GetSalary() => Salary;

    public virtual void ReceiveSalary()
    {
        Console.WriteLine($"Salary {Salary:C} issued to {Name} {Surname} ({GetType().Name}).");
    }
}