using System.Net.Http.Headers;
using RestSharp;

namespace weatherlogr.WeatherGovRepository;

public sealed class WeatherGovRestSharpFactory
{
    public WeatherGovRestSharpFactory()
    {
    }

    public RestClient GetNewClient() => GetNewClient("application/geo+json");

    public RestClient GetNewClient(string accept)
    {

        return new(new RestClientOptions("https://api.weather.gov")
        {
            UserAgent = "(WeatherLogR, github link coming - in development)"
        }
            , headerConfig =>
            {
                headerConfig.Accept.Clear();
                headerConfig.Accept.Add(new MediaTypeWithQualityHeaderValue(accept));
            });
    }
}