using System;
using System.Globalization;
using System.Windows.Data;
using VehiclesWPF.Model;

namespace VehiclesWPF.View.Converter
{
    public class RegistrationNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is RegistrationNumber)
                return value.ToString();

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || (value != null && string.IsNullOrWhiteSpace(value.ToString())))
                return null;
            else if (value is string)
                return new RegistrationNumber(value.ToString());

            throw new NotImplementedException();
        }
    }
}
