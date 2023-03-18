using System.ComponentModel.DataAnnotations;

namespace weatherlogr.Core.DTO;

public sealed class StationCollectorRow
{
    public StationCollectorRow()
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
        [Required]
        public string PickupCronSchedule { get; set; }

        public DateTimeOffset? LastCollectionEnd { get; set; }
}