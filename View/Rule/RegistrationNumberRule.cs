using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using VehiclesWPF.Model;

namespace VehiclesWPF.View.Rule
{
    public class RegistrationNumberRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string registrationNumber = value.ToString();

            if (value == null || (value != null && string.IsNullOrWhiteSpace(value.ToString())))
                return ValidationResult.ValidResult;

            Regex re = new Regex(RegistrationNumber.pattern, RegexOptions.IgnoreCase);

            if (!re.IsMatch(registrationNumber))
                return new ValidationResult(false, "Wrong Registration number. Format (AAA XX123) or empty!");
            else
                return ValidationResult.ValidResult;
        }
    }
}
