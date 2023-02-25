using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using weatherlogr.Core.Contracts.Services;
using weatherlogr.Core.DTO;

namespace weatherlogr.Controllers.Api.MethodsV1
{
    public class StationCollectorsController : MethodControllerBase
    {
        private readonly IStationCollectorService collectorService;

        public StationCollectorsController(IStationCollectorService collectorService)
        {
            this.collectorService = collectorService;
        }

        [HttpGet("~/[controller]/[action]({StationIdentifier})")]
        public async Task<StationCollectorRow?> GetStationCollector([FromRoute] string stationIdentifier)
        {
            return await collectorService.GetStationCollector(stationIdentifier);
        }
    }
}