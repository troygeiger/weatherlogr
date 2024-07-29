namespace weatherlogr.Core;

public sealed class ConfigurationOptions
{
    public string StorageRepositoryType { get; set; } = "MySql";

    public string? StorageConnectionString { get; set; }

    public string? RadarImagesBasePath { get; set; }
}