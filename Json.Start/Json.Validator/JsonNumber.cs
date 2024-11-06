using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return IsDouble(input);
        }

        private static bool IsDouble(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (input.Length > 1 && input[0] == '0' && !input.Contains("."))
            {
                return false;
            }

            if (input[0] == '-')
            {
                return true;
            }

            return !IsLetter(input) && IsNumber(input);
        }

        private static bool IsLetter(string input)
        {
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsNumber(string input)
        {
            int digit = input.Length;
            if (input.Contains("."))
            {
                digit--;
            }

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    digit--;
                }
            }

            return digit == 0;
        }
    }
}
