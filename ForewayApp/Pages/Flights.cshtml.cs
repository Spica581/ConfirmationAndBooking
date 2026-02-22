using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ForewayApp.Models;

namespace ForewayApp.Pages;

public class HeatmapCell  { public decimal Price { get; set; } public string CssClass { get; set; } = ""; }
public class HeatmapRow   { public string ReturnDate { get; set; } = ""; public List<HeatmapCell> Cells { get; set; } = new(); }

public class FlightsModel : PageModel
{
    private const int PageSize = 5;

    [BindProperty(SupportsGet = true)] public FlightSearchModel Search { get; set; } = new();
    [BindProperty(SupportsGet = true)] public int CurrentPage { get; set; } = 1;

    public List<FlightResult> Flights      { get; private set; } = new();
    public List<FlightResult> PagedFlights { get; private set; } = new();
    public int TotalPages                  { get; private set; }

    public List<string>     HeatmapDepartures { get; private set; } = new();
    public List<HeatmapRow> HeatmapRows       { get; private set; } = new();

    public void OnGet()
    {
        // NOTE: Replace with real API data in production
        Flights = new List<FlightResult>
        {
            new() { Airline="Hawaiian Airlines", AirlineCode="HA",  Duration="16h 45m", Price=624,  DepartTime="7:00 AM",  ArriveTime="4:15 PM +1", Stops=1, StopDetail="24h 45m in HNL" },
            new() { Airline="Japan Airlines",    AirlineCode="JAL", Duration="18h 22m", Price=663,  DepartTime="7:35 AM",  ArriveTime="12:15 PM+1", Stops=1, StopDetail="50m in HKG" },
            new() { Airline="United Airlines",   AirlineCode="UA",  Duration="11h 00m", Price=789,  DepartTime="10:00 AM", ArriveTime="3:00 PM +1", Stops=0, StopDetail="Non-stop" },
            new() { Airline="ANA",               AirlineCode="ANA", Duration="12h 15m", Price=712,  DepartTime="1:00 PM",  ArriveTime="5:15 PM +1", Stops=0, StopDetail="Non-stop" },
            new() { Airline="Korean Air",        AirlineCode="KAL", Duration="14h 30m", Price=598,  DepartTime="3:30 PM",  ArriveTime="8:00 PM +1", Stops=1, StopDetail="1h in ICN" },
            new() { Airline="Delta",             AirlineCode="DL",  Duration="13h 05m", Price=870,  DepartTime="5:00 PM",  ArriveTime="9:05 PM +1", Stops=1, StopDetail="45m in SEA" },
            new() { Airline="Cathay Pacific",    AirlineCode="CX",  Duration="15h 40m", Price=655,  DepartTime="9:00 PM",  ArriveTime="1:40 PM +2", Stops=1, StopDetail="1h 20m in HKG" },
        };

        TotalPages   = (int)Math.Ceiling(Flights.Count / (double)PageSize);
        CurrentPage  = Math.Max(1, Math.Min(CurrentPage, TotalPages));
        PagedFlights = Flights.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

        // Heatmap data
        HeatmapDepartures = new() { "2/12","2/13","2/14","2/15","2/16" };
        var rawPrices = new decimal[][] {
            new[]{837m,590m,592m,1308m,837m},
            new[]{710m,670m,840m, 720m,780m},
            new[]{990m,810m,760m, 650m,900m}
        };
        var returnDates = new[]{"3/7","3/8","3/9"};
        for (int r = 0; r < rawPrices.Length; r++) {
            var row = new HeatmapRow { ReturnDate = returnDates[r] };
            var min = rawPrices[r].Min(); var max = rawPrices[r].Max();
            foreach (var p in rawPrices[r])
                row.Cells.Add(new HeatmapCell { Price=p, CssClass=p==min?"low-price":p==max?"high-price":"" });
            HeatmapRows.Add(row);
        }
    }
}
