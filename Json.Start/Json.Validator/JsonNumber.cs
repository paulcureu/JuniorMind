using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

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
                return input.Substring(0, dotIndex);
            }

            return input.Substring(0, exponentIndex);
        }

        private static string GetFraction(string input, int dotIndex, int exponentIndex)
        {
            if (dotIndex == -1)
            {
                return null;
            }

            if (exponentIndex == -1 || dotIndex > exponentIndex)
            {
                return input.Substring(dotIndex);
            }

            return input.Substring(dotIndex, exponentIndex - dotIndex);
        }

        private static string GetExponent(string input, int exponentIndex)
        {
            if (exponentIndex == -1)
            {
                return null;
            }

            return input.Substring(exponentIndex);
        }

        private static bool IsInteger(string integerPart)
        {
            if (string.IsNullOrEmpty(integerPart))
            {
                return false;
            }

            if (integerPart.Length > 1 && integerPart.StartsWith("0"))
            {
                return false;
            }

            if (integerPart.StartsWith("-"))
            {
                integerPart = integerPart.Substring(1);
            }

            return IsDigits(integerPart);
        }

        private static bool IsFraction(string fractionPart)
        {
            if (fractionPart == null)
            {
                return true;
            }

            return IsDigits(fractionPart.Substring(1));
        }

        private static bool IsExponent(string exponentPart)
        {
            if (exponentPart == null)
            {
                return true;
            }

            exponentPart = exponentPart.Substring(1);
            if (exponentPart.StartsWith("+") || exponentPart.StartsWith("-"))
            {
                exponentPart = exponentPart.Substring(1);
            }

            return IsDigits(exponentPart);
        }

        private static bool IsDigits(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsDigit(s[i]))
                {
                    return false;
                }
            }

            return !string.IsNullOrEmpty(s);
        }
    }
}
