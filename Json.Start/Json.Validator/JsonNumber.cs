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

            if (input.Length > 1 && input[0] == '0')
            {
                return false;
            }

            return !IsLetter(input) && IsDigit(input);
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

        private static bool IsDigit(string input)
        {
            int digit = input.Length;
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
