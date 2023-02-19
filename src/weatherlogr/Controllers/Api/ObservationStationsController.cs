using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using weatherlogr.Core.Contracts.Repositories.WeatherGov;
using weatherlogr.Core.DTO;

namespace weatherlogr.Controllers.Api;


//[ApiController]
//[Route("[controller]")]
[ApiExplorerSettings(GroupName = "odata")]
public class ObservationStationsController : ODataController
{
    private readonly IStationLookupRepository repository;

    public ObservationStationsController(IStationLookupRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    [EnableQuery]
    [Produces(typeof(ODataContainer<StationLookupRow>))]
    public ActionResult Get(string state)
    {

        return Ok(repository.GetStations(state));
    }
}

public class ODataContainer<T>
{
    [JsonPropertyName("@odata.context")]
    public string? Context { get; set; }

    public T[]? Value { get; set; }
}