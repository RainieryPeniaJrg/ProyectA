using System.Text.RegularExpressions;

namespace BE_ProyectoA.Core.Domain.ValueObjects
{
    public partial record NumeroTelefono
    {


        //private const string Pattern = @"^(\+?1-)?(\()?((809)|(829)|(849))(\)?)\d{3}(\)?)\d{4}$";

        private NumeroTelefono(string value) => Value = value;

        public static NumeroTelefono? Create(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            return new NumeroTelefono(value);

        }

        public string Value { get; init; }

        //[GeneratedRegex(Pattern)]
        //private static partial Regex PhoneNumberRegex();
    }
}
