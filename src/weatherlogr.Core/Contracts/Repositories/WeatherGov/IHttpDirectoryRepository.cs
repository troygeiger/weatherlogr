using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weatherlogr.Core.DTO;

namespace weatherlogr.Core.Contracts.Repositories.WeatherGov
{
    public interface IHttpDirectoryRepository
    {
        Task<HttpDirectoryEntry[]> GetDirectoryEntriesAsync(Uri url, CancellationToken cancellationToken = default);

        Task<byte[]?> DownloadFileAsync(HttpDirectoryEntry directoryEntry, CancellationToken cancellationToken = default);
    }
}