using System;
using System.Linq;

namespace Hotel.Entities;

public class Manager(string name, string surname, string email, string phoneNumber, int age,
    decimal salary) : Employee(name, surname, email, phoneNumber, age, salary, "Manager", "Administration")
{
    private readonly string _name = name;
    private readonly string _surname = surname;

    public void CheckHotelStatus(Hotel hotel)
    {
        Console.WriteLine("Checking hotel status...");
    }

    public override void Work()
    {
        Console.WriteLine($"Working as Manager... Manager name: {_name} {_surname}");
    }

    public void SuperviseAndPenalize(Hotel hotel)
    {
        if (hotel == null) return;

        var dirtyCount = hotel.Rooms.Count(r => !r.IsClean);
        if (dirtyCount == 0)
        {
            Console.WriteLine("All rooms are clean. No penalties.");
            return;
        }

        Console.WriteLine($"Found {dirtyCount} dirty room(s). Applying penalties to housekeepers...");

        var housekeepers = hotel.Employees.OfType<Housekeeper>().ToList();
        foreach (var hk in housekeepers)
        {
            hk.ApplyPenaltyPercent(0.01m * dirtyCount);
        }
    }
}