using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace weatherlogr.Core.DTO
{
    public class RadarIndexRow
    {
        [Key]
        public Guid ID { get; set; }

        public int RadarSourceID { get; set; }

        public DateTimeOffset RadarDate { get; set; }
    }
}