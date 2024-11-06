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
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    return false;
                }
            }

            return input == "0";
        }
    }
}
