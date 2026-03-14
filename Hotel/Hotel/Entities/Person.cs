namespace Hotel.Entities;

public abstract class Person(string name, string surname, string email, string phoneNumber, int age)
{
    public string Name { get; set; } = name;
    public string Surname { get; set; } = surname;
    private string Email { get; set; } = email;
    private string PhoneNumber { get; set; } = phoneNumber;
    private int Age { get; set; } = age;

    public virtual void IntroducePerson()
    {
        Console.WriteLine($"Name: {Name}, Surname: {Surname}, Email: {Email}, Phone: {PhoneNumber}, Age: {Age}");
    }
}