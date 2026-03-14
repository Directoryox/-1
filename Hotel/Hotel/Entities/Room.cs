using Hotel.Enums;
using System;

namespace Hotel.Entities;

public class Room(int roomNumber, int floor, RoomType roomType, bool isOccupied, bool isClean, Guest? guest)
{
    public int RoomNumber { get; set; } = roomNumber;
    private int Floor { get; set; } = floor;
    public RoomType RoomType { get; set; } = roomType;

    public decimal Price { get; set; }

    public bool IsOccupied { get; set; } = isOccupied;
    public bool IsClean { get; set; } = isClean;
    public Guest? Guest { get; set; } = guest;

    public Fridge? Fridge { get; set; }

    public void AttachFridge(Fridge fridge) => Fridge = fridge;

    public bool BuyDrink(Guest guest, string drinkName)
    {
        if (Fridge == null)
        {
            Console.WriteLine("No fridge in this room.");
            return false;
        }

        var drink = Fridge.GetDrink(drinkName);
        if (drink == null)
        {
            Console.WriteLine("Drink not available or out of stock.");
            return false;
        }

        if (guest.Budjet < drink.Price)
        {
            Console.WriteLine("Guest doesn't have enough money to buy the drink.");
            return false;
        }

        guest.Budjet -= drink.Price;
        Fridge.TakeDrink(drinkName);
        Console.WriteLine($"Guest {guest.Name} {guest.Surname} bought {drink.Name} for {drink.Price:C}. Remaining budget: {guest.Budjet:C}");
        return true;
    }

    public bool CheckIn(Guest guest)
    {
        if (IsOccupied || !IsClean)
        {
            Console.WriteLine("Room is not available.");

            return false;
        }

        var totalCost = Price * guest.StayDays;
        var getGuestBudget = guest.GetBudjet();

        if (getGuestBudget < totalCost)
        {
            Console.WriteLine("Guest budget is not enough.");

            return false;
        }

        guest.Budjet -= totalCost;
        IsOccupied = true;
        Guest = guest;

        Console.WriteLine($"Guest {guest.Name} {guest.Surname} checked in.");

        return true;
    }

    public decimal CheckOut()
    {
        if (!IsOccupied || Guest == null)
        {
            Console.WriteLine("Room is not occupied.");

            return 0;
        }

        var earnedMoney = Price * Guest.StayDays;

        Console.WriteLine("Guest checked out.");

        IsOccupied = false;
        Guest = null;

        return earnedMoney;
    }

    public void Clean()
        => IsClean = true;

    public void Info()
    {
        var guestName = Guest == null ? "No guest" : Guest.Name + " " + Guest.Surname;
        Console.WriteLine($"Room number: {RoomNumber}, Floor: {Floor}, Room type: {RoomType}, Guest: {guestName}," +
                          $" Is occupied: {IsOccupied}, Is clean: {IsClean}, Price: {Price:C}");
        Fridge?.Info();
    }
}