using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using weatherlogr.Core.Contracts.Services;

namespace weatherlogr.Controllers
{
    public class AnalyticsController : Controller
    {
        private readonly IStationCollectorService stationCollector;

        public AnalyticsController(IStationCollectorService stationCollector)
        {
            this.stationCollector = stationCollector;
        }

        [HttpGet]
        public async Task<IActionResult> ChartTemperatures()
        {
            return View(model: await stationCollector.GetAll());
        }
    }
}