using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weatherlogr.Core.DTO
{
    public class HttpDirectoryEntry
    {
        public string Name { get; set; } = string.Empty;

        public DateTime? LastModified { get; set; }

        public string? Size { get; set; }

        public Uri? Href { get; set; }
    }
}