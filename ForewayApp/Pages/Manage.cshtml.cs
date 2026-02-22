using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForewayApp.Pages;

public class BookingSummary
{
    public string PassengerName { get; set; } = "";
    public string Route         { get; set; } = "";
    public string DepartDate    { get; set; } = "";
    public string ReturnDate    { get; set; } = "";
    public string Status        { get; set; } = "";
    public string StatusCss     { get; set; } = "";
    public string TicketId      { get; set; } = "";
    public decimal Total        { get; set; }
}

public class ManageModel : PageModel
{
    public List<BookingSummary> Bookings { get; private set; } = new();

    public void OnGet()
    {
        // NOTE: Replace with EF Core query in production:
        // Bookings = await _db.Bookings.Select(b => new BookingSummary { ... }).ToListAsync();
        Bookings = new List<BookingSummary>
        {
            new() { PassengerName="Jane Doe",     Route="SFO → NRT", DepartDate="Jun 5, 2024",  ReturnDate="Jun 12, 2024", Status="Pending",   StatusCss="badge-pending", TicketId="BS02485", Total=1248 },
            new() { PassengerName="John Doe",     Route="LAX → LHR", DepartDate="Jul 10, 2024", ReturnDate="Jul 20, 2024", Status="Confirmed",  StatusCss="badge-confirm", TicketId="BS01834", Total=980  },
            new() { PassengerName="Maria Santos", Route="SFO → CDG", DepartDate="Aug 1, 2024",  ReturnDate="Aug 14, 2024", Status="Pending",   StatusCss="badge-pending", TicketId="BS03012", Total=760  },
            new() { PassengerName="Liam Chen",    Route="JFK → DXB", DepartDate="Sep 5, 2024",  ReturnDate="Sep 15, 2024", Status="Confirmed",  StatusCss="badge-confirm", TicketId="BS03298", Total=1100 },
            new() { PassengerName="Aiko Tanaka",  Route="ORD → NRT", DepartDate="Oct 20, 2024", ReturnDate="Oct 30, 2024", Status="Pending",   StatusCss="badge-pending", TicketId="BS04001", Total=890  },
        };
    }
}
