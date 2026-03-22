using Hotel.Entities;
using Hotel.Enums;
using Hotel.Services;

namespace Hotel;

public class Program
{
    static void Main(string[] args)
    {
        var rooms = new List<Room>();
        var guests = new List<Guest>();
        var employees = new List<Employee>();
        var hotel = new Hotel.Entities.Hotel("Sea Breeze", "Ocean Ave 1", rooms, guests, employees, 0m);

        rooms.Add(new Room(101, 1, RoomType.SingleRoom, false, true, null));
        rooms.Add(new Room(102, 1, RoomType.DoubleRoom, false, true, null));
        rooms.Add(new Room(201, 2, RoomType.Family, false, false, null));

        var fridge101 = new Fridge(new List<Drink> { new Drink("Cola", 3m, 5), new Drink("Water", 1m, 10) });
        var r101 = hotel.FindRoomByNumber(101);
        r101?.AttachFridge(fridge101);

        var fridge102 = new Fridge(new List<Drink> { new Drink("Juice", 2.5m, 3) });
        var r102 = hotel.FindRoomByNumber(102);
        r102?.AttachFridge(fridge102);

        hotel.SetRating(5);

        var housekeeper = new Housekeeper("Anna", "Dombrovsika", "AnnaDombrovsika@hotel", "666888", 30, 1000m);
        var manager = new Manager("Kata", "Ivanova", "KataIvanova@hotel", "999666", 40, 2000m);
        var finance = new FinanceSpecialist("lilia", "Epur", "liliaEpur@hotel", "555-666", 35, 1500m);

        employees.Add(housekeeper);
        employees.Add(manager);
        employees.Add(finance);

        var hotelService = new HotelService(hotel);
        var payroll = new PayrollService();

        var guest = new Guest("Karina", "Vovkovich", "KarinaVovkovich@x.com", "777888", 28, 200m) { StayDays = 2 };
        guests.Add(guest);

        Console.WriteLine("--- Before check-in ---");
        hotel.ShowAllRooms();

        hotelService.CheckInGuest(guest, 101);

        r101 = hotel.FindRoomByNumber(101);
        if (r101 != null && r101.Fridge != null)
        {
            if (r101.BuyDrink(guest, "Cola"))
            {
                hotel.AddProfit(3m);
            }
        }

        manager.SuperviseAndPenalize(hotel);

        var r201 = hotel.FindRoomByNumber(201);
        if (r201 != null)
        {
            housekeeper.Clean(r201);
        }

        payroll.PayAll(hotel);
        finance.CheckRevenue(hotel);

        Console.WriteLine("--- Final hotel state ---");
        hotel.Info();
        hotel.ShowAllRooms();

        Console.WriteLine("Demo finished.");
    }
}