using System;
using System.Linq;
using System.Reflection;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return ExceptionalCase(input) && IsLetter(input) && IsNumber(input);
        }

        private static bool ExceptionalCase(string input)
        {
            return IsNullOrEmptyString(input) && IsFirstDigitZero(input) && IsExponentComplete(input);
        }

        private static bool IsNullOrEmptyString(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        private static bool IsFirstDigitZero(string input)
        {
            return input.Length <= 1 || input[0] != '0' || input.Contains('.');
        }

        private static bool IsExponentComplete(string input)
        {
            return input[^1] != '+' && input[^1] != '-' && input[^1] != 'e';
        }

        private static bool IsLetter(string input)
        {
            foreach (char c in input)
            {
                if (char.IsLetter(c) && c != 'e' && c != 'E')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ExponentIsAfterTheFraction(string input)
        {
            return !(input.Contains('e') && input.Contains('.')) || input.IndexOf('e') > input.IndexOf('.');
        }

        private static bool ToManyExponents(string input)
        {
            return input.Count(c => c == 'e' || c == 'E') <= 1;
        }

        private static bool IsNumber(string input)
        {
            return !NumberEndsWithDot(input) && IsMoreThanOneFractionalPart(input) && ExponentIsAfterTheFraction(input) && ToManyExponents(input);
        }

        private static bool NumberEndsWithDot(string input)
        {
            return input.EndsWith(".");
        }

        private static bool IsMoreThanOneFractionalPart(string input)
        {
            return input.Count(c => c == '.') <= 1;
        }
    }
}
