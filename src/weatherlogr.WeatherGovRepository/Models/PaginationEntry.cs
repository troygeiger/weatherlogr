namespace weatherlogr.WeatherGovRepository.Models;

internal sealed class PaginationEntry
{
    public string Next { get; set; } = string.Empty;

    public IEnumerable<KeyValuePair<string, string>> GetQueryKeyValue()
    {
        Uri next = new Uri(Next);
        foreach (string kv in Uri.UnescapeDataString(next.Query).Substring(1).Split('&'))
        {
            var seg = kv.Split('=');
            yield return new KeyValuePair<string, string>(seg[0], seg[1]);
        }
    }

    public string? GetCursor() => GetQueryKeyValue().Where(kv => kv.Key == "cursor")
        .Select(k => k.Value)
        .FirstOrDefault();
}