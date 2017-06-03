using System;
using System.Globalization;
using System.Windows.Controls;

namespace VehiclesWPF.View.Rule
{
    public class PastDateRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Date cannot be empty!");
            else if ((DateTime)value > DateTime.Now)
                return new ValidationResult(false, "This date has to be in past!");
            else
                return ValidationResult.ValidResult;
        }
    }
}
