# Foreway – ASP.NET Core Razor Pages Application

## Overview
Converted from static HTML/CSS to ASP.NET Core 8.0 Razor Pages.

## Pages
| URL | Source File | Description |
|-----|------------|-------------|
| `/` | Index.cshtml | Landing / home page |
| `/Flights` | Flights.cshtml | Flight search results with interactive map & price chart |
| `/Confirmation` | Confirmation.cshtml | Booking confirmation page |
| `/Hotels` | Hotels.cshtml | Stub page |
| `/Deals` | Deals.cshtml | Stub page |
| `/About` | About.cshtml | Stub page |
| `/SignIn` | SignIn.cshtml | Stub page |

## Project Structure
```
ForewayApp/
├── ForewayApp.csproj
├── Program.cs
├── appsettings.json
├── Models/
│   └── FlightModels.cs        # BookingConfirmation, FlightResult, etc.
├── Pages/
│   ├── _ViewImports.cshtml
│   ├── _ViewStart.cshtml
│   ├── Index.cshtml / .cs
│   ├── Flights.cshtml / .cs   # Main flight results page
│   ├── Confirmation.cshtml / .cs
│   ├── Hotels/Deals/About/SignIn stubs
│   └── Shared/
│       ├── _Layout.cshtml     # Shared header, footer, CDN scripts
│       └── _FlightLeg.cshtml  # Partial: reusable flight leg card
└── wwwroot/
    └── css/
        └── site.css           # Merged & optimized stylesheet
```

## How to Run

### Prerequisites
- .NET 8.0 SDK — https://dotnet.microsoft.com/download

### Run
```bash
cd ForewayApp
dotnet run
```
Then open https://localhost:5001 (or http://localhost:5000).

### Visual Studio
Open `ForewayApp.csproj` → F5 to run.

## Key Changes from Static HTML
1. **CSS Merged** — `styles.css` (two near-identical copies) merged into a single `wwwroot/css/site.css`. Duplicate rules removed, conflicts resolved.
2. **Shared Layout** — `_Layout.cshtml` provides a consistent header/footer across all pages. CDN links (Leaflet, Chart.js) loaded once.
3. **Dynamic Data** — Flight results and booking confirmation are driven by C# model classes (`FlightModels.cs`). Replace the sample data in `Flights.cshtml.cs` / `Confirmation.cshtml.cs` with real API calls.
4. **Local image paths fixed** — Original HTML used absolute Windows paths (`C:\Users\...`). Replace with `/images/airline_logo.png` files placed in `wwwroot/images/`.
5. **Responsive / No-Overflow** — Layout uses CSS Grid & Flexbox breakpoints; max-width containers prevent horizontal overflow on all viewports.
6. **Partial View** — `_FlightLeg.cshtml` is a reusable partial for outbound and return flight legs.
