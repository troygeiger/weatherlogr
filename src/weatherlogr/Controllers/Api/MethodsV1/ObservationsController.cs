using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using weatherlogr.Core.Contracts.Services;
using weatherlogr.Core.DTO;

namespace weatherlogr.Controllers.Api.MethodsV1
{
    public class ObservationsController : MethodControllerBase
    {
        private static IEnumerable<TimeZoneInfo> timeZones;

        static ObservationsController()
        {
            timeZones = TimeZoneInfo.GetSystemTimeZones();
        }

        private readonly IObservationService observationService;
        

        public ObservationsController(IObservationService observationService)
        {
            this.observationService = observationService;
            
        }

        [HttpGet]
        public async Task<IEnumerable<ObservationRow>> GetStationObservations(string stationIdentifier,
                                                                              DateTime start,
                                                                              DateTime end,
                                                                              CancellationToken cancellationToken)
        {
            return await observationService.GetStationObservations(stationIdentifier,
                                                                   start,
                                                                   end,
                                                                   cancellationToken);
        }

        [HttpGet]
        public IEnumerable<TimeZoneInfo> GetTimezoneDetails()
        {
            return timeZones;
        }
    }
}