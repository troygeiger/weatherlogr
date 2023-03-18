using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using weatherlogr.Core.Contracts.Repositories.Storage;
using weatherlogr.Core.Contracts.Services;
using weatherlogr.Core.DTO;
using weatherlogr.Models;

namespace weatherlogr.Controllers
{
    public class SystemConfigurationController : Controller
    {
        private readonly ILogger<SystemConfigurationController> _logger;
        private readonly ISystemConfigurationService configService;

        public SystemConfigurationController(ILogger<SystemConfigurationController> logger, ISystemConfigurationService configService)
        {
            this.configService = configService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(model: configService.Configuration);
        }

        [HttpPost]
        public IActionResult Index(SystemConfigurationEntry model)
        {
            if (!ModelState.IsValid)
                return View(model);

            configService.Configuration = model;
            configService.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
       
    }
}