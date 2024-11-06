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
            if (!string.IsNullOrEmpty(input) && input.Length > 1 && !input.Contains('.') && input[0] == '0')
            {
                return false;
            }

            return double.TryParse(input, out double result);
        }
    }
}
