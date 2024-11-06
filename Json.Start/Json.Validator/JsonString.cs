using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return HasContent(input) && IsDoubleQuoted(input) && !ContainsControlCharacters(input) && ContainsExcapeCharacter(input);
        }

        private static bool IsDoubleQuoted(string input)
        {
            return input.Length >= 2 && input[0] == '"' && input[^1] == '"';
        }

        private static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        private static bool ContainsControlCharacters(string input)
        {
            foreach (char character in input)
            {
                if (char.IsControl(character))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainsExcapeCharacter(string input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '\\' && i + 1 == input.Length - 1)
                {
                    return false;
                }
                else if (input[i] == '\\' && !char.IsLetter(input[i + 1]))
                {
                    return true;
                }
                else if (input[i] == '\\' && !IsExcapeCharacter(input[i + 1]))
                {
                    return false;
                }
                else if (input[i] == '\\' && input[i + 1] == 'u')
                {
                    return IsHexNumber(input.Substring(i + 1));
                }
            }

            return true;
        }

        private static bool IsHexNumber(string input)
        {
            int digits = 4;
            if (input.Length > digits + 1) // check if the hex number is at the end of the string
            {
                return true;
            }

            for (int i = 1; i < input.Length - 1; i++)
            {
                if (IsHexDigit(input[i]))
                {
                    digits--;
                }
            }

            return digits == 0;
        }

        private static bool IsHexDigit(char c)
        {
            return char.IsDigit(c) || (char.ToLower(c) >= 'a' && char.ToLower(c) <= 'f');
        }

        private static bool IsExcapeCharacter(char character)
        {
            const string excapeCharacter = @"\\[^ntrbfv\u""]";
            for (int i = 0; i < excapeCharacter.Length; i++)
            {
                if (character == excapeCharacter[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
