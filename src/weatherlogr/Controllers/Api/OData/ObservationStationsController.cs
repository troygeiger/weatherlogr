using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using weatherlogr.Core.Contracts.Repositories.WeatherGov;
using weatherlogr.Core.Contracts.Services;
using weatherlogr.Core.DTO;
using weatherlogr.CustomAttributes;

namespace weatherlogr.Controllers.Api.OData;

[Route("odata")]
[ODataEdmDefinition(typeof(StationLookupRow), EntitySetName = "ObservationStations(State)")]
public class ObservationStationsController : ODataControllerBase
{
    private readonly IObservationStationService repository;

    public ObservationStationsController(IObservationStationService repository)
    {
        this.repository = repository;
    }

    [HttpGet("ObservationStations({State})")]
    [EnableQuery]
    [Produces(typeof(ODataResponseContainer<StationLookupRow>))]
    public async Task<ActionResult> Get([Required] string State)
    {
        return Ok(await repository.GetStationsAsync(State));
    }
}
