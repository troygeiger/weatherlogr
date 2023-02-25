using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Formatter;
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

[Route("odata/ObservationStations")]
[ODataEdmDefinition(typeof(ObservationStationRow), EntitySetName = "ObservationStations")]
public class ObservationStationsController : ODataControllerBase
{
    private readonly IObservationStationService service;

    public ObservationStationsController(IObservationStationService repository)
    {
        this.service = repository;
    }

    
    [HttpGet]
    [EnableQuery]
    [Produces(typeof(ODataResponseContainer<ObservationStationRow>))]
    public async Task<ActionResult> Get([Required] string State)
    {
        return Ok(await service.GetStationsAsync(State));
    }
}
