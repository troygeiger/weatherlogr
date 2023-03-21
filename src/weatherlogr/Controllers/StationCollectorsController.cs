using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using weatherlogr.Core.Contracts.Services;
using weatherlogr.Core.DTO;
using weatherlogr.Core.Services;

namespace weatherlogr.Controllers;

public sealed class StationCollectorsController : Controller
{
    private readonly IStationCollectorService stationCollectorService;
    private readonly IObservationStationService observationStationService;
    private readonly HostedServiceMessaging serviceMessaging;

    public StationCollectorsController(IStationCollectorService stationCollectorService,
                                       IObservationStationService observationStationService,
                                       HostedServiceMessaging serviceMessaging)
    {
        this.stationCollectorService = stationCollectorService;
        this.observationStationService = observationStationService;
        this.serviceMessaging = serviceMessaging;
    }

    public async Task<IActionResult> Index()
    {
        return View(model: await stationCollectorService.GetAll());
    }

    [HttpGet]
    public IActionResult AddStation()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddStation(StationCollectorRow station)
    {
        if (!ModelState.IsValid)
            return View(station);
        var existing = await stationCollectorService.GetStationCollectorAsync(station.StationIdentifier);
        if (existing is not null)
        {
            ModelState.AddModelError(nameof(StationCollectorRow.StationIdentifier), "Station already exists!");
            return View(station);
        }
        await stationCollectorService.AddNewStationAsync(station);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IEnumerable<QueryResult>> LookupStations(string state, string query, int maxResults = 30)
    {
        if (string.IsNullOrEmpty(state))
            return Array.Empty<QueryResult>();

        return (await observationStationService.GetStationsAsync(state))
            .Where(s => s.StationIdentifier.StartsWith(query, StringComparison.OrdinalIgnoreCase)
                || s.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
            .Take(maxResults)
            .Select(s => new QueryResult()
            {
                Value = s.StationIdentifier,
                Name = s.Name,
                TimeZone = s.TimeZone,
                DisplayValue = $"{s.StationIdentifier} ({s.Name})"
            });
    }

    [HttpPost]
    public async Task<IActionResult> DeleteStation(string stationIdentifier)
    {
        bool result = await stationCollectorService.DeleteStationCollectorAsync(stationIdentifier);
        return result ? Ok() : NotFound();
    }

}

public class QueryResult
{
    public string? Value { get; set; }

    public string? Name { get; set; }

    public string? DisplayValue { get; set; }

    public string? TimeZone { get; set; }
}