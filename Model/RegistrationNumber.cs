using System.Text.RegularExpressions;

namespace VehiclesWPF.Model
{
    public class RegistrationNumber
    {
        public static string pattern = @"^([a-zA-Z]{2,3})(\s)([a-zA-Z0-9]{1,2})([0-9]{3})$";
        private string regionCode;
        private string prefixCode;
        private uint numberCode;

        public RegistrationNumber(string regionCode, string prefixCode, uint numberCode)
        {
            this.regionCode = regionCode.ToUpper();
            this.prefixCode = prefixCode.ToUpper();
            this.numberCode = numberCode;
        }

        public RegistrationNumber(string registrationNumber = "AAA XX123")
        {
            Regex re = new Regex(pattern, RegexOptions.IgnoreCase);

            var match = re.Match(registrationNumber);

            regionCode = match.Groups[1].ToString().ToUpper();
            prefixCode = match.Groups[3].ToString().ToUpper();
            numberCode = uint.Parse(match.Groups[4].ToString());
        }

        public override string ToString()
        {
            return regionCode + " " + prefixCode + numberCode.ToString();
        }

    }
}
