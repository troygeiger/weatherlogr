using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weatherlogr.WeatherGovRepository.Models
{
    public sealed class UnitValueEntry
    {
        public string? UnitCode { get; set; }

        public decimal? Value { get; set; }

        public string? QualityControl { get; set; }
    }
}