using System.ComponentModel.DataAnnotations;
using System.Drawing;
using weatherlogr.Core.Validation;

namespace weatherlogr.Core.DTO;

public class SystemConfigurationEntry
{
    [MaxLength(200)]
    [Required]
    [CronValidation]
    public string PickupSchedule { get; set; } = "0,15,30,45 * * * *";

}
