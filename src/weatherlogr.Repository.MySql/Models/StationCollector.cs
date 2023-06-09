using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace weatherlogr.Repository.MySql.Models
{
    public sealed class StationCollector
    {
        [Key]
        [MaxLength(10)]
        public string StationIdentifier { get; set; } = string.Empty;

        [MaxLength(250)]
        public string StationName { get; set; } = string.Empty;

        [MaxLength(2)]
        public string State { get; set; } = string.Empty;

        [MaxLength(100)]
        [DefaultValue("")]
        public string TimeZone { get; set; } = string.Empty;

        public DateTimeOffset? LastCollectionEnd { get; set; }
    }
}