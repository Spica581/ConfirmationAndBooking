namespace ForewayApp.Models;

public class FlightResult
{
    public string Airline       { get; set; } = string.Empty;
    public string AirlineCode   { get; set; } = string.Empty;
    public string LogoUrl       { get; set; } = string.Empty;
    public string Duration      { get; set; } = string.Empty;
    public decimal Price        { get; set; }
    public string DepartTime    { get; set; } = string.Empty;
    public string ArriveTime    { get; set; } = string.Empty;
    public string DepartAirport { get; set; } = string.Empty;
    public string ArriveAirport { get; set; } = string.Empty;
    public int Stops            { get; set; }
    public string StopDetail    { get; set; } = string.Empty;
}

public class FlightSearchModel
{
    public string   From     { get; set; } = "SFO";
    public string   To       { get; set; } = "NRT";
    public DateTime Depart   { get; set; } = DateTime.Today.AddDays(7);
    public DateTime Return   { get; set; } = DateTime.Today.AddDays(14);
    public int      Adults   { get; set; } = 1;
    public int      Children { get; set; } = 0;
}

public class BookingConfirmation
{
    public string  TicketId          { get; set; } = "BS02485";
    public string  Status            { get; set; } = "PENDING";
    public string  ConfirmationEmail { get; set; } = "user@example.com";
    public FlightLeg?    OutboundLeg { get; set; }
    public FlightLeg?    ReturnLeg   { get; set; }
    public TravelerInfo  Traveler1   { get; set; } = new();
    public TravelerInfo? Traveler2   { get; set; }
    public decimal FarePerAdult      { get; set; }
    public decimal TaxesPerAdult     { get; set; }
    public int     AdultCount        { get; set; } = 2;
    public decimal Total             { get; set; } = 1200.00m;
}

public class FlightLeg
{
    public string Title      { get; set; } = string.Empty;
    public string Duration   { get; set; } = string.Empty;
    public bool   IsReturn   { get; set; }
    public string? LayoverNote { get; set; }
    public List<LegSegment> Segments { get; set; } = new();
}

public class LegSegment
{
    public string Date           { get; set; } = string.Empty;
    public string FlightNumber   { get; set; } = string.Empty;
    public string Aircraft       { get; set; } = string.Empty;
    public string DepartTime     { get; set; } = string.Empty;
    public string DepartAirport  { get; set; } = string.Empty;
    public string ArriveTime     { get; set; } = string.Empty;
    public string ArriveAirport  { get; set; } = string.Empty;
    public string FlightDuration { get; set; } = string.Empty;
    public string Class          { get; set; } = "Economy";
}

public class TravelerInfo
{
    public string FullName    { get; set; } = string.Empty;
    public string Gender      { get; set; } = string.Empty;
    public string DateOfBirth { get; set; } = string.Empty;
    public string Phone       { get; set; } = string.Empty;
    public string Email       { get; set; } = string.Empty;
}
