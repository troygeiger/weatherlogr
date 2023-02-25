using System.ComponentModel.DataAnnotations;

namespace weatherlogr.Core.DTO;

public sealed class ObservationStationRow
{
    public ObservationStationRow()
    {
        StationIdentifier = string.Empty;
        Name = string.Empty;
        TimeZone = string.Empty;
    }

    public ObservationStationRow(string stationIdentifier, string name, string timeZone)
    {
        StationIdentifier = stationIdentifier;
        Name = name;
        TimeZone = timeZone;
    }

    [Key]
    public string StationIdentifier{get;set;}

    public string Name{get;set;}

    public string TimeZone{get;set;}
}