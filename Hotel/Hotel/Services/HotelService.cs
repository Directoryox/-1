using Hotel.Entities;

namespace Hotel.Services;

public class HotelService(Entities.Hotel hotel)
{
    public void CheckInGuest(Entities.Guest guest, int roomNumber)
    {
        var room = hotel.FindRoomByNumber(roomNumber);

        if (room == null)
        {
            Console.WriteLine("Room not found.");
            
            return;
        }
        
        var success = room.CheckIn(guest);

        if (!success)
        {
            return;
        }
        
        var earnedMoney = room.Price * guest.StayDays;
        hotel.AddProfit(earnedMoney);
        Console.WriteLine($"Guest {guest.Name} {guest.Surname} checked in.");
    }
    
    public void CheckOutGuest(Entities.Guest guest, int roomNumber)
    {
        var room = hotel.FindRoomByNumber(roomNumber);
        
        if (room == null)
        {
            Console.WriteLine("Room not found.");
            
            return;
        }
        
        room.CheckOut();
    }

    public void CleanRoom(Housekeeper housekeeper, int roomNumber)
    {
        var room = hotel.FindRoomByNumber(roomNumber);
        
        if (room == null)
        {
            Console.WriteLine("Room not found.");
            
            return;
        }
        
        housekeeper.Clean(room);
    }
}