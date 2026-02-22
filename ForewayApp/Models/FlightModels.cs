namespace ForewayApp.Models;

/// <summary>
/// Represents a single available flight option shown on the Search Results page.
/// In production, this would be populated from an external flights API.
/// </summary>
public class FlightResult
{
    public string Airline      { get; set; } = string.Empty;
    public string AirlineCode  { get; set; } = string.Empty;  // e.g. "HA", "JL"
    public string LogoUrl      { get; set; } = string.Empty;
    public string Duration     { get; set; } = string.Empty;
    public decimal Price       { get; set; }
    public string DepartTime   { get; set; } = string.Empty;
    public string ArriveTime   { get; set; } = string.Empty;
    public int Stops           { get; set; }
    public string StopDetail   { get; set; } = string.Empty;
}

/// <summary>
/// Search parameters bound from the flight search form.
/// </summary>
public class FlightSearchModel
{
    public string From       { get; set; } = "SFO";
    public string To         { get; set; } = "NRT";
    public DateTime Depart   { get; set; } = DateTime.Today.AddDays(7);
    public DateTime Return   { get; set; } = DateTime.Today.AddDays(14);
    public int Adults        { get; set; } = 1;
    public int Children      { get; set; } = 0;
}

/// <summary>
/// Represents a booking confirmation.
/// In production, populated after payment processing.
/// </summary>
public class BookingConfirmation
{
    public string  TicketId           { get; set; } = "BS02485";
    public string  Status             { get; set; } = "PENDING";
    public string  ConfirmationEmail  { get; set; } = "user@example.com";

    public FlightLeg? OutboundLeg     { get; set; }
    public FlightLeg? ReturnLeg       { get; set; }

    public TravelerInfo Traveler1     { get; set; } = new();
    public TravelerInfo? Traveler2    { get; set; }

    public decimal FarePerAdult       { get; set; }
    public decimal TaxesPerAdult      { get; set; }
    public int AdultCount             { get; set; } = 2;
    public decimal Total              { get; set; } = 1200.00m;
}

public class FlightLeg
{
    public string Title          { get; set; } = string.Empty;  // "Departure 1-Stop"
    public string Duration       { get; set; } = string.Empty;  // "7h 27m"
    public List<LegSegment> Segments { get; set; } = new();
    public string? LayoverNote   { get; set; }
    public bool IsReturn         { get; set; }
}

public class LegSegment
{
    public string Date          { get; set; } = string.Empty;
    public string FlightNumber  { get; set; } = string.Empty;
    public string Aircraft      { get; set; } = string.Empty;
    public string DepartTime    { get; set; } = string.Empty;
    public string DepartAirport { get; set; } = string.Empty;
    public string ArriveTime    { get; set; } = string.Empty;
    public string ArriveAirport { get; set; } = string.Empty;
    public string FlightDuration{ get; set; } = string.Empty;
    public string Class         { get; set; } = "Economy";
}

public class TravelerInfo
{
    public string FullName    { get; set; } = string.Empty;
    public string Gender      { get; set; } = string.Empty;
    public string DateOfBirth { get; set; } = string.Empty;
    public string Phone       { get; set; } = string.Empty;
    public string Email       { get; set; } = string.Empty;
}
