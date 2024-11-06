using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return ExceptionalCase(input) && !IsLetter(input) && IsNumber(input);
        }

        private static bool ExceptionalCase(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (input.Length > 1 && input[0] == '0' && !input.Contains("."))
            {
                return false;
            }

            if (input[^1] == '+' || input[^1] == '-' || input[^1] == 'e')
            {
                return false;
            }

            if (input[0] == '-')
            {
                return true;
            }

            return true;
        }

        private static bool IsLetter(string input)
        {
            int index = 0;
            int findE = 0;
            int findDot = 0;
            int toMuchE = 0;
            foreach (char c in input)
            {
                if (char.IsLetter(c) && c != 'e' && c != 'E')
                {
                    return true;
                }

                if (c == 'e')
                {
                    findE = index;
                    toMuchE++;
                }

                if (c == '.')
                {
                    findDot = index;
                }

                index++;
            }

            if (input[0] == 'e' || (findE < findDot && findE > 0))
            {
                return true;
            }

            return toMuchE > 1;
        }

        private static bool IsNumber(string input)
        {
            if (input[^1] == '.')
            {
                return false;
            }

            int digit = input.Length;
            if (input.Contains("."))
            {
                digit--;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'e' || input[i] == 'E' || input[i] == '+' || input[i] == '-')
                {
                    digit--;
                }
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
