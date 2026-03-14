using System;

namespace Hotel.Entities;

public class FinanceSpecialist(string name, string surname, string email, string phoneNumber, int age, decimal salary) : Employee(name, surname, email, phoneNumber, age, salary, "Finance Specialist", "Finance Department") {
    public void CheckRevenue(Hotel hotel) {

        if (hotel == null) {
            Console.WriteLine("Hotel is null.");
            return;
        }

        Console.WriteLine($"Finance check by {Name} {Surname}: Total revenue = {hotel.TotalRevenue:C}");
    }

    public override void Work() {
        Console.WriteLine($"Working as Finance Specialist... {Name} {Surname}");
    }
}