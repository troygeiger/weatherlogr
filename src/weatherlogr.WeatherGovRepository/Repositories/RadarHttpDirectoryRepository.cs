using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Xml;
using weatherlogr.Core.Contracts.Repositories.WeatherGov;
using weatherlogr.Core.DTO;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;

namespace weatherlogr.WeatherGovRepository.Repositories
{
    public class RadarHttpDirectoryRepository : IHttpDirectoryRepository
    {
        public Task<byte[]?> DownloadFileAsync(HttpDirectoryEntry directoryEntry, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpDirectoryEntry[]> GetDirectoryEntriesAsync(Uri url, CancellationToken cancellationToken = default)
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.UserAgent.Add(new(InternalConstants.AgentString));
            var response = await client.GetAsync(url, cancellationToken);
            List<HttpDirectoryEntry> results = new();
            if (response.IsSuccessStatusCode == false) return results.ToArray();



            string html = await response.Content.ReadAsStringAsync(cancellationToken);
            HtmlAgilityPack.HtmlDocument doc = new();
            doc.LoadHtml(html);
            foreach (var row in doc.DocumentNode.QuerySelectorAll("tr").Skip(3))
            {
                if (row.ChildNodes.Count != 3) continue;
                HttpDirectoryEntry entry = new()
                {
                    Name = row.ChildNodes[0].InnerText,
                    LastModified = DateTime.TryParse(row.ChildNodes[1].InnerText, out DateTime date) ? date : null,
                    Size = row.ChildNodes[2].InnerText
                };
                results.Add(entry);
                var a = row.ChildNodes[0].QuerySelector("a");
                if (a is null) continue;
                entry.Href = new(url, a.Attributes["href"].Value);

            }

            return results.ToArray();
        }

    }
}