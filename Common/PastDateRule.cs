using System;
using System.Globalization;
using System.Windows.Controls;

namespace VehiclesWPF.Common
{
    public class PastDateRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if ((DateTime)value > DateTime.Now)
                return new ValidationResult(false, "Date can not be in the future!");
            else
                return ValidationResult.ValidResult;
        }
    }
}
