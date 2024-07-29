using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using weatherlogr.Core.Contracts.Services;

namespace weatherlogr.Controllers
{
    public class RadarSourcesController : Controller
    {
        private readonly IRadarSourcesService sourcesService;

        public RadarSourcesController(IRadarSourcesService sourcesService)
        {
            this.sourcesService = sourcesService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await sourcesService.GetAllAsync());
        }
    }
}