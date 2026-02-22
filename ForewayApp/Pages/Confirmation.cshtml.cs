using Microsoft.AspNetCore.Mvc.RazorPages;
using ForewayApp.Models;

namespace ForewayApp.Pages;

/// <summary>
/// Extended BookingConfirmation with flight-status chart data.
/// NOTE: In production, populate PendingCount/CompletedCount/CancelledCount
/// from your Entity Framework DbContext, e.g.:
///   PendingCount   = await _db.Bookings.CountAsync(b => b.Status == BookingStatus.Pending);
///   CompletedCount = await _db.Bookings.CountAsync(b => b.Status == BookingStatus.Completed);
/// </summary>
public class BookingConfirmationEx : BookingConfirmation
{
    // Chart data — counts across all passengers / bookings
    public int PendingCount   { get; set; }
    public int CompletedCount { get; set; }
    public int CancelledCount { get; set; }
    public int TotalFlights   => PendingCount + CompletedCount + CancelledCount;

    public int PendingPct   => TotalFlights > 0 ? (int)Math.Round(PendingCount   * 100.0 / TotalFlights) : 0;
    public int CompletedPct => TotalFlights > 0 ? (int)Math.Round(CompletedCount * 100.0 / TotalFlights) : 0;
    public int CancelledPct => TotalFlights > 0 ? (int)Math.Round(CancelledCount * 100.0 / TotalFlights) : 0;
}

public class ConfirmationModel : PageModel
{
    public BookingConfirmationEx Booking { get; private set; } = new();

    public void OnGet(string? ticketId = null)
    {
        Booking = new BookingConfirmationEx
        {
            TicketId          = ticketId ?? "BS02485",
            Status            = "PENDING",
            ConfirmationEmail = "user@example.com",
            AdultCount        = 2,
            FarePerAdult      = 480.00m,
            TaxesPerAdult     = 120.00m,
            Total             = 1200.00m,

            // NOTE: Replace with real DB queries in production
            PendingCount   = 4,   // e.g. 40% of 10 total bookings
            CompletedCount = 5,   // 50%
            CancelledCount = 1,   // 10%

            Traveler1 = new TravelerInfo
            {
                FullName    = "Jane Doe",
                Gender      = "Female",
                DateOfBirth = "12 Jun 1985",
                Phone       = "+1 555-0100",
                Email       = "jane@example.com"
            },
            Traveler2 = new TravelerInfo
            {
                FullName    = "John Doe",
                Gender      = "Male",
                DateOfBirth = "15 Mar 1983",
                Phone       = "+1 555-0101",
                Email       = "john@example.com"
            },

            OutboundLeg = new FlightLeg
            {
                Title    = "Departure",
                Duration = "7h 27m",
                Segments = new List<LegSegment>
                {
                    new() { Date="WED Jun 5, 2024", FlightNumber="Delta 868",  Aircraft="Boeing 737-900", DepartTime="8:45 AM", DepartAirport="Los Angeles, CA (LAX)", ArriveTime="6:00 PM", ArriveAirport="Minneapolis, MN (MSP)", FlightDuration="6h 55m", Class="Economy" },
                    new() { Date="WED Jun 5, 2024", FlightNumber="Delta 2656", Aircraft="Boeing 737-900", DepartTime="8:45 AM", DepartAirport="Minneapolis, MN (MSP)", ArriveTime="8:40 PM", ArriveAirport="Houston, TX (IAH)",      FlightDuration="6h 53m", Class="Economy" }
                },
                LayoverNote = "Layover: Minneapolis, MN — 1h 01m"
            },

            ReturnLeg = new FlightLeg
            {
                Title    = "Return",
                Duration = "3h 23m",
                IsReturn = true,
                Segments = new List<LegSegment>
                {
                    new() { Date="WED Jun 12, 2024", FlightNumber="Delta 868", Aircraft="Boeing 737-900", DepartTime="8:45 AM", DepartAirport="Los Angeles, CA (LAX)", ArriveTime="8:40 PM", ArriveAirport="Minneapolis, MN (MSP)", FlightDuration="6h 55m", Class="Economy" }
                }
            }
        };
    }
}
