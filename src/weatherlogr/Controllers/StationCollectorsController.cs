using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using weatherlogr.Core.Contracts.Services;
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
    public IActionResult Search(string query)
    {
        return Json(new QueryResult[]{
            new(){Value = "Hello"},
            new(){Value = "World"}
        });
    }

    [HttpGet]
    public IActionResult AddStation()
    {
        return View();
    }
}

class QueryResult
{
    public string? Value{get;set;}
}