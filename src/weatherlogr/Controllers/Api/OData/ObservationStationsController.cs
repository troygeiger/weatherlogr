using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.ComponentModel.DataAnnotations;
using weatherlogr.Core.Contracts.Repositories.WeatherGov;
using weatherlogr.Core.Contracts.Services;
using weatherlogr.Core.DTO;

namespace weatherlogr.Controllers.Api.OData;


//[ApiController]
//[Route("[controller]")]
[ApiExplorerSettings(GroupName = "odata")]
public class ObservationStationsController : ODataController
{
    private readonly IObservationStationService repository;

    public ObservationStationsController(IObservationStationService repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    [EnableQuery]
    [Produces(typeof(ODataContainer<StationLookupRow>))]
    public async Task<ActionResult> Get([Required] string state)
    {
        return Ok(await repository.GetStationsAsync(state));
    }
}
