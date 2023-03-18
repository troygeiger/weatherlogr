using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NCrontab;
using weatherlogr.Core.DTO;
using weatherlogr.Core.Validation;

namespace weatherlogr.Models
{
    public sealed class SystemConfigModel
    {
        public SystemConfigModel()
        {
            
        }

        public SystemConfigModel(SystemConfigurationEntry configurationEntry)
        {
            PickupSchedule = configurationEntry.PickupSchedule;
        }

        [Required]
        [CronValidation]
        public string? PickupSchedule { get; set; }

    }
}