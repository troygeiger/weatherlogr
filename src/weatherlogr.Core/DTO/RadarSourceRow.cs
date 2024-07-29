using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace weatherlogr.Core.DTO
{
    public class RadarSourceRow
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1024)]
        public string Url { get; set; } = string.Empty;

        public bool Enabled { get; set; } = false;

        [MaxLength(1024)]
        public string PickupCronTabSchedule { get; set; } = "0 * * * *";
    }
}