using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NCrontab;

namespace weatherlogr.Core.Validation
{
    public class CronValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not string strValue) return false;

            string[] segments = strValue.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (segments.Length < 5 || segments.Length > 6) return false;


            var schedule = CrontabSchedule.TryParse(strValue, new CrontabSchedule.ParseOptions() { IncludingSeconds = segments.Length == 6 });
            return schedule != null;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (!this.IsValid(value))
            {
                return new ValidationResult($"{validationContext.DisplayName} is not formatted correctly!");
            }

            return ValidationResult.Success;
        }
    }
}