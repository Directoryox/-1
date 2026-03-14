using System;
using System.Linq;
using System.Collections.Generic;
using Hotel.Enums;

namespace Hotel.Entities;

public class Hotel(
    string name,
    string address,
    List<Room> rooms,
    List<Guest> guests,
    List<Employee> employees,
    decimal totalRevenue)
{
    public string Name { get; set; } = name;
    public string Address { get; set; } = address;

    public List<Room> Rooms { get; set; } = rooms;
    public List<Guest> Guests { get; set; } = guests;
    public List<Employee> Employees { get; set; } = employees;

    public decimal TotalRevenue { get; set; } = totalRevenue;

    public class HotelRating
    {
        public int Stars { get; }

        public HotelRating(int stars)
        {
            if (stars < 1) stars = 1;
            if (stars > 5) stars = 5;
            Stars = stars;
        }

        public decimal GetMultiplier()
        {
            if (Stars == 5) return 2.0m;
            if (Stars == 4) return 1.5m;
            if (Stars == 3) return 1.2m;
            if (Stars == 2) return 1.05m;
            return 1.0m;
        }
    }

    public HotelRating? Rating { get; private set; }

    public void SetRating(int stars) => SetRating(new HotelRating(stars));

    public void SetRating(HotelRating rating)
    {
        if (rating == null) return;
        Rating = rating;

        foreach (var room in Rooms)
        {
            room.Price = GetBasePrice(room.RoomType) * Rating.GetMultiplier();
        }
    }

    private static decimal GetBasePrice(RoomType type)
    {
        if (type == RoomType.SingleRoom) return 50m;
        if (type == RoomType.DoubleRoom) return 80m;
        if (type == RoomType.Family) return 120m;
        if (type == RoomType.Luxury) return 250m;
        return 50m;
    }

    public void AddRoom(Room room) => Rooms.Add(room);
    public void AddEmployee(Employee employee) => Employees.Add(employee);
    public void AddProfit(decimal profit) => TotalRevenue += profit;

    public Room? FindRoomByNumber(int roomNumber)
        => Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

    public void ShowAllRooms()
    {
        Console.WriteLine("All rooms: ");
        foreach (var room in Rooms)
        {
            room.Info();
        }
    }

    public void ShowFreeRooms()
    {
        Console.WriteLine("Free rooms: ");
        foreach (var room in Rooms.Where(room => !room.IsOccupied))
        {
            room.Info();
        }
    }

    public void Info()
    {
        Console.WriteLine($"Hotel name: {Name}");
        Console.WriteLine($"Hotel address: {Address}");
        Console.WriteLine($"Hotel rooms: {Rooms.Count}");
        Console.WriteLine($"Hotel employees: {Employees.Count}");
        Console.WriteLine($"Hotel total revenue: {TotalRevenue}");
        Console.WriteLine($"Hotel rating: {(Rating != null ? Rating.Stars.ToString() : "Not set")}");
    }
}