namespace Hotel.Entities;

public class Guest(string name, string surname, string email, string phoneNumber, int age, decimal budjet) : Person(name, surname, email, phoneNumber, age)
{
    public decimal Budjet { get; set; }
    
    public int StayDays { get; set; }
    
    public decimal GetBudjet()
    {
        Console.WriteLine($"Getting budjet... Budjet: {Budjet}");
        
        return Budjet;
    }
}