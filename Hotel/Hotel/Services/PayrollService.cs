using System;
using Hotel.Entities;

namespace Hotel.Services;

public class PayrollService
{
    public void PayAll(Hotel.Entities.Hotel hotel)
    {
        if (hotel == null) return;

        Console.WriteLine("Payroll: starting payments...");

        foreach (var emp in hotel.Employees)
        {
            var amount = emp.GetSalary();
            emp.ReceiveSalary();
            Console.WriteLine($"Paid {amount:C} to {emp.Name} {emp.Surname} ({emp.GetType().Name}).");
        }

        Console.WriteLine("Payroll: finished.");
    }
}