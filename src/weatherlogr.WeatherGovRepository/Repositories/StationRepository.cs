using Microsoft.Extensions.Caching.Memory;
using RestSharp;
using weatherlogr.Core.Contracts.Repositories.WeatherGov;
using weatherlogr.Core.Extensions;
using weatherlogr.Core.DTO;
using weatherlogr.WeatherGovRepository.Models;

namespace weatherlogr.WeatherGovRepository.Repositories;

public sealed class StationRepository : IObservationStationRepository
{
    private readonly WeatherGovRestSharpFactory factory;
    private readonly IMemoryCache cache;

    public StationRepository(WeatherGovRestSharpFactory factory, IMemoryCache cache)
    {
        this.factory = factory;
        this.cache = cache;
    }

    public IQueryable<ObservationStationRow> GetStations(string state)
    {
        return cache.GetOrCreate<IQueryable<ObservationStationRow>>($"StationLookup_GetStations[{state}]", entry =>
        {
            entry.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30);

            var client = factory.GetNewClient();

            var request = new RestRequest("stations");
            request.AddQueryParameter("state", state);
            request.AddQueryParameter("limit", "100");

            var result = client.Execute<ObservationStationFeatureCollection>(request);
            List<ObservationStationRow> returnResults = new();

            while (result.IsSuccessful)
            {
                if (result.Data is null) continue;

                returnResults.AddRange(result.Data.Features
                    .Select(s => s.Properties)
                    .Where(x => x is not null)
                    .Select(p => new ObservationStationRow(p!.StationIdentifier, p.Name, p.TimeZone)));

                if (result.Data.Pagination?.Next is null || result.Data.Features.Any() == false) break;
                string? cursor = result.Data.Pagination.GetCursor();
                if (cursor is null) break;
                request.AddOrUpdateParameter("cursor", cursor, ParameterType.QueryString);

                result = client.Execute<ObservationStationFeatureCollection>(request);

            }

            return returnResults.AsQueryable<ObservationStationRow>();
        }) ?? Array.Empty<ObservationStationRow>().AsQueryable();
    }
}

