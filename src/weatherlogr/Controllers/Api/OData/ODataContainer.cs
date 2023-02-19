using System.Text.Json.Serialization;

namespace weatherlogr.Controllers.Api.OData;

public class ODataContainer<T>
{
    [JsonPropertyName("@odata.context")]
    public string? Context { get; set; }

    public T[]? Value { get; set; }
}