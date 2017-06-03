using System;
using System.Globalization;
using System.Windows.Controls;

namespace VehiclesWPF.Common
{
    public class NotEmptyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || (value != null && string.IsNullOrWhiteSpace(value.ToString())))
                return new ValidationResult(false, "Cannot be empty!");
            else
                return ValidationResult.ValidResult;
        }
    }
}
