using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            int dotIndex = input.IndexOf('.');
            int exponentIndex = input.IndexOfAny(new[] { 'e', 'E' });

            string integerPart = GetInteger(input, dotIndex, exponentIndex);
            string fractionPart = GetFraction(input, dotIndex, exponentIndex);
            string exponentPart = GetExponent(input, exponentIndex);

            return IsInteger(integerPart) && IsFraction(fractionPart) && IsExponent(exponentPart);
        }

        private static string GetInteger(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex == -1 && exponentIndex == -1)
            {
                return input;
            }

            if (dotIndex != -1)
            {
                return input[..dotIndex];
            }

            return input[..exponentIndex];
        }

        private static string GetFraction(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex == -1)
            {
                return string.Empty;
            }

            if (dotIndex > exponentIndex)
            {
                return input[dotIndex..];
            }

            return input[dotIndex..exponentIndex];
        }

        private static string GetExponent(string input, int exponentIndex)
        {
            if (exponentIndex == -1)
            {
                return string.Empty;
            }

            return input[exponentIndex..];
        }

        private static bool IsInteger(string integerPart)
        {
            if (integerPart.StartsWith("-"))
            {
                integerPart = integerPart[1..];
            }

            if (integerPart.Length > 1 && integerPart.StartsWith("0"))
            {
                return false;
            }

            return IsDigits(integerPart);
        }

        private static bool IsFraction(string fractionPart)
        {
            return string.IsNullOrEmpty(fractionPart) || IsDigits(fractionPart[1..]);
        }

        private static bool IsExponent(string exponentPart)
        {
            if (string.IsNullOrEmpty(exponentPart))
            {
                return true;
            }

            exponentPart = exponentPart[1..];
            if (exponentPart.StartsWith("+") || exponentPart.StartsWith("-"))
            {
                exponentPart = exponentPart[1..];
            }

            return IsDigits(exponentPart);
        }

        private static bool IsDigits(string digits)
        {
            foreach (char digit in digits)
            {
                if (!char.IsDigit(digit))
                {
                    return false;
                }
            }

            return !string.IsNullOrEmpty(digits);
        }
    }
}
