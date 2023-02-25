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
    
    public class ObservationStationsController : MethodControllerBase
    {
        private readonly IObservationStationService service;

        public ObservationStationsController(IObservationStationService service)
        {
            this.service = service;
        }

        [HttpGet("~/[controller]/[action]({State})")]
        [ProducesResponseType(200)]
        public async Task<IQueryable<ObservationStationRow>> GetStations([Required, FromRoute] string State)
        {
            return await service.GetStationsAsync(State);
        }
    }
}
