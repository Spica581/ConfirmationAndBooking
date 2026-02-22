# Foreway Enhanced — ASP.NET Core 8 Razor Pages

## Overview
Fully refactored, no-scroll flight booking application with multi-step booking flow, flight details with seat map, manage bookings, and a Chart.js pie chart on the confirmation page.

## Pages

| URL | Description |
|-----|-------------|
| `/`               | Hero home page with 4 main CTA navigation buttons |
| `/Flights`        | Paginated flight search (5/page) with price heatmap & chart |
| `/FlightDetails`  | Full flight details with pricing breakdown, amenities, interactive seat map |
| `/Book/Step1`     | Booking step 1 — Passenger Information |
| `/Book/Step2`     | Booking step 2 — Extras & Seat Preferences |
| `/Book/Step3`     | Booking step 3 — Payment & Order Summary |
| `/Confirmation`   | Booking confirmation + passenger flight status **Pie Chart** |
| `/Manage`         | Manage/view all bookings with filter, cancel, rebook actions |

## No-Scroll Architecture

Every page uses this viewport-locked flex structure:

```
<body>  ← flex column, height:100%, overflow:hidden
  <header class="header">   ← flex-shrink:0
  <main class="page-shell"> ← flex:1, overflow:hidden
    <div class="page-card">  ← flex column, overflow:hidden
      <div class="page-title-bar">  ← flex-shrink:0 (never scrolls)
      <div class="action-bar">      ← flex-shrink:0 (never scrolls)
      <div class="scroll-zone">     ← flex:1, overflow-y:auto  (only this scrolls)
  <footer class="footer">   ← flex-shrink:0
```

Long content (flight lists, forms) is paginated or placed in `.scroll-zone`.

## Pie Chart (Confirmation Page)

Located in `Pages/Confirmation.cshtml` and `Pages/Confirmation.cshtml.cs`.

- **Chart.js** (CDN) renders a pie chart with 3 slices:
  - 🟡 Pending Flights
  - 🟢 Completed Flights
  - 🟣 Cancelled
- Data from `BookingConfirmationEx.PendingCount / CompletedCount / CancelledCount`
- **To connect to a real DB:** Replace the hardcoded counts in `OnGet()` with Entity Framework queries:
  ```csharp
  PendingCount   = await _db.Bookings.CountAsync(b => b.Status == BookingStatus.Pending);
  CompletedCount = await _db.Bookings.CountAsync(b => b.Status == BookingStatus.Completed);
  CancelledCount = await _db.Bookings.CountAsync(b => b.Status == BookingStatus.Cancelled);
  ```

## Running the App

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)

```bash
cd EnhancedForewayApp
dotnet run
```

Open https://localhost:5001 or http://localhost:5000.

### Visual Studio
Open `ForewayApp.csproj` → press F5.

## Key Changes from Previous Version

| Area | Change |
|------|--------|
| CSS | Full rewrite to viewport-lock pattern (`html/body overflow:hidden`, flex column) |
| Scrolling | Only `.scroll-zone` divs scroll; header/title/actions never scroll |
| Navigation | Full nav in `_Layout.cshtml` + action bars on each page |
| Index page | Hero with 4 large CTA buttons + stats bar |
| Flights | Paginated (5/page) with `?page=N` query param |
| Flight Details | New page with info grid, pricing breakdown, interactive seat map |
| Book flow | Split into 3 steps: Passenger Info → Extras → Payment |
| Manage | Booking list with filter, view/rebook/cancel actions |
| Confirmation | Pie chart (Chart.js) for passenger flight status |
| Responsive | Media queries for 1920px, 1024px, 768px, 480px, 360px |
| Accessibility | `aria-label` on all interactive elements |
