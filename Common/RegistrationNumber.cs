using System;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace VehiclesWPF.Common
{
    public class RegistrationNumber
    {
        private string regionCode;
        private string prefixCode;
        private uint numberCode;

        public RegistrationNumber(string regionCode, string prefixCode, uint numberCode)
        {
            this.regionCode = regionCode;
            this.prefixCode = prefixCode;
            this.numberCode = numberCode;
        }

        public RegistrationNumber(string registrationNumber = "AAA XX123")
        {
            this.regionCode = registrationNumber.Substring(0, 3);
            this.prefixCode = registrationNumber.Substring(4, 2);
            this.numberCode = uint.Parse(registrationNumber.Substring(6, 3));
        }

        public override string ToString()
        {
            return regionCode + " " + prefixCode + numberCode.ToString();
        }

    }

    public class RegistrationNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is RegistrationNumber)
            {
                return value.ToString();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                return new RegistrationNumber(value.ToString());
            }

            throw new NotImplementedException();
        }
    }

    public class RegistrationNumberRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string registrationNumber = value.ToString();

            if (registrationNumber.Length > 9)
                return new ValidationResult(false, "Too long Registration Number (AAA XX123)");
            else if (registrationNumber.Length < 9)
                return new ValidationResult(false, "Too short Registration Number (AAA XX123)");
            else if (registrationNumber.Substring(0, 3).Any(c => !char.IsLetter(c)))
                return new ValidationResult(false, "First 3 characters must be letters. Region code (AAA)");
            else if (registrationNumber.Substring(4, 2).Any(c => !char.IsLetterOrDigit(c)))
                return new ValidationResult(false, "Next 2 characters must be letters or numbers. Prefix code (XX)");
            else if (registrationNumber.Substring(5, 3).Any(c => !char.IsDigit(c)))
                return new ValidationResult(false, "Last 3 characters must be numbers. Number code (123)");
            else
                return ValidationResult.ValidResult;
        }
    }
}
