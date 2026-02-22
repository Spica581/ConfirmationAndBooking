using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ForewayApp.Models;

namespace ForewayApp.Pages;

public class FlightDetail : FlightResult
{
    public string FlightNumber  { get; set; } = "HA 449";
    public string Aircraft      { get; set; } = "Boeing 787-9 Dreamliner";
    public int    Distance      { get; set; } = 5095;
    public string SeatClass     { get; set; } = "Economy";
    public decimal BaseFare     { get; set; }
    public decimal Taxes        { get; set; }
    public decimal SeatFee      { get; set; }
    public Dictionary<string,string> Amenities { get; set; } = new();
}

public class FlightDetailsModel : PageModel
{
    public FlightDetail Flight   { get; private set; } = new();
    public List<string>  Seats   { get; private set; } = new();
    public HashSet<string> TakenSeats { get; private set; } = new();

    public void OnGet(string? airline, decimal price = 624)
    {
        // NOTE: In production query your data source using the flight id/params
        Flight = new FlightDetail
        {
            Airline      = airline ?? "Hawaiian Airlines",
            AirlineCode  = "HA",
            FlightNumber = "HA 449",
            Aircraft     = "Boeing 787-9 Dreamliner",
            Distance     = 5095,
            Duration     = "16h 45m",
            Price        = price,
            BaseFare     = price * 0.77m,
            Taxes        = price * 0.18m,
            SeatFee      = price * 0.05m,
            DepartTime   = "7:00 AM",
            ArriveTime   = "4:15 PM +1",
            DepartAirport= "SFO – San Francisco",
            ArriveAirport= "NRT – Tokyo Narita",
            Stops        = 1,
            StopDetail   = "24h 45m in HNL",
            SeatClass    = "Economy",
            Amenities    = new Dictionary<string,string>
            {
                {"Wi-Fi",     "Available ($12/flight)"},
                {"Meals",     "2 complimentary meals"},
                {"Baggage",   "1×23kg included"},
                {"USB power", "All seats"},
                {"IFE",       "10″ personal screen"},
                {"Legroom",   "31″ pitch"}
            }
        };

        // Generate a simple seat map layout
        // Rows 1-5 business (A B _ C D), rows 6-20 economy (A B C _ D E F)
        var taken = new HashSet<string>{"1A","1B","2C","3D","5A","7B","8C","10E","12F","14A","15D","17C","19F"};
        TakenSeats = taken;

        for (int row = 1; row <= 5; row++)   // Business rows
        {
            foreach (var s in new[]{"A","B","aisle","C","D"})
                Seats.Add(s == "aisle" ? "aisle" : $"{row}{s}");
        }
        for (int row = 6; row <= 20; row++)  // Economy rows
        {
            foreach (var s in new[]{"A","B","C","aisle","D","E","F"})
                Seats.Add(s == "aisle" ? "aisle" : $"{row}{s}");
        }
    }
}
