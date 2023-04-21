# WeatherLogR

This project was developed to log observations, from weather.gov, and store them
into a database. This allows for long term archiving of conditions at a given
station.

It is intended to run as a service with a web interface for configuration and
analytics. Currently, only MySql is supported but other databases will be
supported at a later date.

## Debugging

Add an `appsettings.Development.json` file to the `src/weatherlogr/` folder and
add the following:
NOTE: This file is ignored by git.

```json
{
    "ConfigOptions":{
        "StorageRepositoryType": "MySql",
        "StorageConnectionString": "<connection string>"
    }
}
```
