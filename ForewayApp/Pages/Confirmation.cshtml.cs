using Microsoft.AspNetCore.Mvc.RazorPages;
using ForewayApp.Models;

namespace ForewayApp.Pages;

public class ConfirmationModel : PageModel
{
    public BookingConfirmation Booking { get; private set; } = new();

    // NOTE: In production, the ticketId would come from a query string /
    //       session after payment processing. Here we use static sample data.
    public void OnGet(string? ticketId = null)
    {
        Booking = new BookingConfirmation
        {
            TicketId           = ticketId ?? "BS02485",
            Status             = "PENDING",
            ConfirmationEmail  = "user@example.com",
            AdultCount         = 2,
            FarePerAdult       = 480.00m,
            TaxesPerAdult      = 120.00m,
            Total              = 1200.00m,

            Traveler1 = new TravelerInfo
            {
                FullName    = "User LName",
                Gender      = "Male",
                DateOfBirth = "12 Jun 1985",
                Phone       = "02091250-0518",
                Email       = "user@example.com"
            },

            Traveler2 = new TravelerInfo
            {
                FullName    = "User2 LName",
                Gender      = "Male",
                DateOfBirth = "12 Jun 1985",
                Phone       = "02091250-0518",
                Email       = "user2@example.com"
            },

            OutboundLeg = new FlightLeg
            {
                Title    = "Departure",
                Duration = "7h 27m",
                Segments = new List<LegSegment>
                {
                    new()
                    {
                        Date           = "WED Jun 5, 2024",
                        FlightNumber   = "Delta 868",
                        Aircraft       = "Boeing 737-900 • 1,534 Miles",
                        DepartTime     = "8:45 AM",
                        DepartAirport  = "Los Angeles, CA (LAX)",
                        ArriveTime     = "6:00 PM",
                        ArriveAirport  = "Minneapolis, MN (MSP)",
                        FlightDuration = "6h 55m",
                        Class          = "Economy"
                    },
                    new()
                    {
                        Date           = "WED Jun 5, 2024",
                        FlightNumber   = "Delta 2656",
                        Aircraft       = "Boeing 737-900 • 1,534 Miles",
                        DepartTime     = "8:45 AM",
                        DepartAirport  = "Minneapolis, MN (MSP)",
                        ArriveTime     = "8:40 PM",
                        ArriveAirport  = "Houston, TX (IAH)",
                        FlightDuration = "6h 53m",
                        Class          = "Economy"
                    }
                },
                LayoverNote = "Layover: Minneapolis, MN 1h 01m"
            },

            ReturnLeg = new FlightLeg
            {
                Title    = "Return",
                Duration = "3h 23m",
                IsReturn = true,
                Segments = new List<LegSegment>
                {
                    new()
                    {
                        Date           = "WED Jun 12, 2024",
                        FlightNumber   = "Delta 868",
                        Aircraft       = "Boeing 737-900 • 1,534 Miles",
                        DepartTime     = "8:45 AM",
                        DepartAirport  = "Los Angeles, CA (LAX)",
                        ArriveTime     = "8:40 PM",
                        ArriveAirport  = "Minneapolis, MN (MSP)",
                        FlightDuration = "6h 55m",
                        Class          = "Economy"
                    }
                }
            }
        };
    }
}
