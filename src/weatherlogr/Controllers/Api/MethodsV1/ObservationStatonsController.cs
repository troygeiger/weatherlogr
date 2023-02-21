using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weatherlogr.Core.Contracts.Services;
using weatherlogr.Core.DTO;

namespace weatherlogr.Controllers.Api.MethodsV1
{
    
    public class ObservationStatonsController : MethodControllerBase
    {
        private readonly IObservationStationService service;

        public ObservationStatonsController(IObservationStationService service)
        {
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IQueryable<StationLookupRow>> GetRows([Required] string state)
        {
            return await service.GetStationsAsync(state);
        }
    }
}
