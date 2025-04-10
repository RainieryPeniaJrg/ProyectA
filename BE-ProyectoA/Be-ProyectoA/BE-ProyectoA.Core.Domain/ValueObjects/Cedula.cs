﻿using System.Text.RegularExpressions;

namespace BE_ProyectoA.Core.Domain.ValueObjects
{
    public partial record Cedula
    {

        private const string Pattern = @"^\d{11}$";

        private Cedula(string value) => Value = value;

        public static Cedula? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || !CedulaRegex().IsMatch(value))
            {
                return null;
            }

            return new Cedula(value);
        }

        public string Value { get; init; }

        [GeneratedRegex(Pattern)]
        private static partial Regex CedulaRegex();
    }
}
