using System;
using System.Globalization;
using System.Windows.Controls;

namespace VehiclesWPF.View.Rule
{
    public class NotEmptyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || (value != null && string.IsNullOrWhiteSpace(value.ToString())))
                return new ValidationResult(false, "Value cannot be empty!");
            else
                return ValidationResult.ValidResult;
        }
    }
}
