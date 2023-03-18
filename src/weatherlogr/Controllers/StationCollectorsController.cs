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
    private readonly HostedServiceMessaging serviceMessaging;

    public StationCollectorsController(IStationCollectorService stationCollectorService,
                                       HostedServiceMessaging serviceMessaging)
    {
        this.stationCollectorService = stationCollectorService;
        this.serviceMessaging = serviceMessaging;
    }

    public async Task<IActionResult> Index()
    {
        return View(model: await stationCollectorService.AsQueryable().ToArrayAsync());
    }

    [HttpGet]
    public IActionResult AddStation()
    {
        return View();
    }

    [HttpGet]
    public IActionResult EditStation(string id)
    {
        return View(model: stationCollectorService.AsQueryable()
            .FirstOrDefault(s=>s.StationIdentifier == id));
    }

    [HttpPost]
    public IActionResult EditStation([FromRoute] string id, StationCollectorRow station)
    {
        if (!ModelState.IsValid)
        {
            return View(model: station);
        }

        return RedirectToAction("Index");
    }
}

class QueryResult
{
    public string? Value{get;set;}
}