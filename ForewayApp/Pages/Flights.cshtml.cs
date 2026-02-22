using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ForewayApp.Models;

namespace ForewayApp.Pages;

public class HeatmapCell
{
    public decimal Price    { get; set; }
    public string CssClass  { get; set; } = string.Empty;
}

public class HeatmapRow
{
    public string ReturnDate        { get; set; } = string.Empty;
    public List<HeatmapCell> Cells  { get; set; } = new();
}

public class FlightsModel : PageModel
{
    // -----------------------------------------------------------------------
    // Properties bound from the query string (GET search form)
    // -----------------------------------------------------------------------
    [BindProperty(SupportsGet = true)]
    public FlightSearchModel Search { get; set; } = new();

    public List<FlightResult> Flights { get; private set; } = new();

    // Heatmap data
    public List<string>     HeatmapDepartures { get; private set; } = new();
    public List<HeatmapRow> HeatmapRows       { get; private set; } = new();

    // -----------------------------------------------------------------------
    // NOTE: In a real application, OnGet would call an external flights API
    //       using the Search parameters. Here we use hard-coded sample data.
    // -----------------------------------------------------------------------
    public void OnGet()
    {
        // --- Sample flight results -----------------------------------------
        Flights = new List<FlightResult>
        {
            new() {
                Airline      = "Hawaiian Airlines",
                AirlineCode  = "HA",
                LogoUrl      = "/images/hawaiian_airlines.png",
                Duration     = "16h 45m",
                Price        = 624,
                DepartTime   = "7:00 AM",
                ArriveTime   = "4:15 PM (+1)",
                Stops        = 1,
                StopDetail   = "24h 45m in HNL"
            },
            new() {
                Airline      = "Japan Airlines",
                AirlineCode  = "JAL",
                LogoUrl      = "/images/JAL.png",
                Duration     = "18h 22m",
                Price        = 663,
                DepartTime   = "7:35 AM",
                ArriveTime   = "12:15 PM (+1)",
                Stops        = 1,
                StopDetail   = "50m in HKG"
            }
        };

        // --- Heatmap sample data ------------------------------------------
        HeatmapDepartures = new() { "2/12", "2/13", "2/14", "2/15", "2/16" };

        var rawPrices = new decimal[][]
        {
            new[] { 837m, 590m, 592m, 1308m, 837m },
            new[] { 710m, 670m, 840m,  720m, 780m },
            new[] { 990m, 810m, 760m,  650m, 900m }
        };
        var returnDates = new[] { "3/7", "3/8", "3/9" };

        for (int r = 0; r < rawPrices.Length; r++)
        {
            var row  = new HeatmapRow { ReturnDate = returnDates[r] };
            var min  = rawPrices[r].Min();
            var max  = rawPrices[r].Max();
            foreach (var p in rawPrices[r])
            {
                row.Cells.Add(new HeatmapCell
                {
                    Price    = p,
                    CssClass = p == min ? "low-price" : p == max ? "high-price" : ""
                });
            }
            HeatmapRows.Add(row);
        }
    }
}
