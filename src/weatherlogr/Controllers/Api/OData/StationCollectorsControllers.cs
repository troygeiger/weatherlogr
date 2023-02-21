using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using weatherlogr.Core.Contracts.Services;
using weatherlogr.Core.DTO;
using weatherlogr.CustomAttributes;

namespace weatherlogr.Controllers.Api.OData
{
    [Route("odata/StationCollectors")]
    [ODataEdmDefinition(typeof(StationCollectorRow), EntitySetName = "StationCollectors")]
    public class StationCollectorsControllers : ODataControllerBase
    {
        private readonly IStationCollectorService collectorService;

        public StationCollectorsControllers(IStationCollectorService collectorService)
        {
            this.collectorService = collectorService;
        }

        [EnableQuery]
        [HttpGet]
        [Produces(typeof(ODataResponseContainer<StationCollectorRow>))]
        public ActionResult Get()
        {
            return Ok(collectorService.AsQueryable());
        }
    }
}