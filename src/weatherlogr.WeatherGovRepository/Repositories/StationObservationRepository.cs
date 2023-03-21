using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using weatherlogr.Core.Contracts.Repositories.WeatherGov;
using weatherlogr.Core.DTO;
using weatherlogr.WeatherGovRepository.Models;

namespace weatherlogr.WeatherGovRepository.Repositories
{
    public sealed class StationObservationRepository : IStationObservationsRepository
    {
        const string dtFormat = "yyyy-MM-ddThh:mm:ssZ";
        private readonly WeatherGovRestSharpFactory factory;

        public StationObservationRepository(WeatherGovRestSharpFactory factory)
        {
            this.factory = factory;
        }

        private string GetDateTimeString(DateTimeOffset dt) => dt.Offset == TimeSpan.Zero ? dt.ToString(dtFormat) : dt.ToUniversalTime().ToString(dtFormat);


        public async Task<IEnumerable<ObservationRow>> GetStationObservationsAsync(string stationIdentifier,
                                                                                   DateTimeOffset startDate,
                                                                                   DateTimeOffset endDate,
                                                                                   CancellationToken cancellationToken = default)
        {
            var client = factory.GetNewClient();

            RestRequest request = new($"stations/{stationIdentifier}/observations");
            request.AddQueryParameter("start", GetDateTimeString(startDate));
            request.AddQueryParameter("end", GetDateTimeString(endDate));
            var response = await client.ExecuteAsync<GeoJsonFeatureCollection<Observation>>(request, cancellationToken);
            if (!response.IsSuccessful) return Array.Empty<ObservationRow>();

            return response.Data?.Features
                .Where(f => f.Properties is not null)
                .Select(f => f.Properties!)
                .OrderBy(p => p.timestamp)
                .Select(p => new ObservationRow()
                {
                    StationID = stationIdentifier,
                    ObsDescription = p.TextDescription,
                    EntryDate = p.timestamp,
                    Temperature = p.Temperature?.Value,
                    TemperatureUOM = p.Temperature?.UnitCode,
                    BarometricPressure = p.BarometricPressure?.Value,
                    BarometricPressureUOM = p.BarometricPressure?.UnitCode,
                    DewPoint = p.Dewpoint?.Value,
                    DewPointUOM = p.Dewpoint?.UnitCode,
                    HeatIndex = p.HeatIndex?.Value,
                    HeatIndexUOM = p.HeatIndex?.UnitCode,
                    Humidity = p.RelativeHumidity?.Value,
                    HumidityUOM = p.RelativeHumidity?.UnitCode,
                    Visibility = p.Visibility?.Value,
                    VisibilityUOM = p.Visibility?.UnitCode,
                    WindChill = p.WindChill?.Value,
                    WindChillUOM = p.WindChill?.UnitCode,
                    WindGust = p.WindGust?.Value,
                    WindGustUOM = p.WindGust?.UnitCode,
                    WindSpeed = p.WindSpeed?.Value,
                    WindSpeedUOM = p.WindSpeed?.UnitCode
                }) ?? Array.Empty<ObservationRow>();
        }
    }
}