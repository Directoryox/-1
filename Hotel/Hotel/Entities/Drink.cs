namespace Hotel.Entities;

public class Drink(string name, decimal price, int quantity) {
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
    public int Quantity { get; set; } = quantity;
}