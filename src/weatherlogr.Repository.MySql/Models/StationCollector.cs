using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace weatherlogr.Repository.MySql.Models
{
    public sealed class StationCollector
    {
        public StationCollector()
        {
            StationIdentifier = string.Empty;
            StationName = string.Empty;
            PickupCronSchedule = string.Empty;
        }

        [Key]
        [MaxLength(10)]
        public string StationIdentifier { get; set; }

        [MaxLength(250)]
        public string StationName { get; set; }

        [MaxLength(200)]
        public string PickupCronSchedule { get; set; }

        public DateTimeOffset? LastCollectionEnd { get; set; }
    }
}