using System;

namespace Hotel.Entities;

public class Housekeeper(string name, string surname, string email, string phoneNumber,
    int age, decimal salary) : Employee(name, surname, email, phoneNumber, age, salary, "Housekeeper", "Cleaners Department")
{
    private readonly string _name = name;
    private readonly string _surname = surname;

    private decimal _currentSalary = salary;

    public void ApplyPenaltyPercent(decimal percent)
    {
        if (percent <= 0) return;
        var deduction = _currentSalary * percent;
        _currentSalary -= deduction;
        Console.WriteLine($"Housekeeper {_name} {_surname} penalized {deduction:C} ({percent:P}). New salary: {_currentSalary:C}");
    }

    public override decimal GetSalary() => _currentSalary;

    public override void ReceiveSalary()
    {
        Console.WriteLine($"Paid {_currentSalary:C} to {_name} {_surname} (Housekeeper).");
    }

    public void Clean(Room room)
    {
        if (room.IsClean)
        {
            Console.WriteLine("Room is already clean.");
            return;
        }

        Console.WriteLine("Cleaning...");
        room.Clean();

        Console.WriteLine("Room is clean.");
    }

    public override void Work()
    {
        Console.WriteLine($"Working as Housekeeper... Housekeeper name: {_name} {_surname}");
    }
}