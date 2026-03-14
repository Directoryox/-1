using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.Entities;

public class Fridge(List<Drink>? drinks = null)
{
    public List<Drink> Drinks { get; set; } = drinks ?? new List<Drink>();

    public Drink? GetDrink(string name)
        => Drinks.FirstOrDefault(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && d.Quantity > 0);

    public bool TakeDrink(string name)
    {
        var d = Drinks.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && x.Quantity > 0);
        if (d == null) return false;
        d.Quantity--;
        return true;
    }

    public void Info()
    {
        Console.WriteLine("Fridge contents:");
        foreach (var d in Drinks)
            Console.WriteLine($"- {d.Name}: {d.Price:C}, qty: {d.Quantity}");
    }
}