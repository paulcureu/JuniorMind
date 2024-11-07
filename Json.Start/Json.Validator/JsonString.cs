using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return HasContent(input) && IsDoubleQuoted(input) && ContainsControlCharacters(input) && ContainsExcapeCharacter(input);
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
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (IsControlCharacter(input[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ContainsExcapeCharacter(string input)
        {
            if (input.Contains('/'))
            {
                return true;
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '\\' && !char.IsWhiteSpace(input[i + 1]) && !IsExcapeCharacter(input[i + 1]))
                {
                    return false;
                }

                if (input[i] == '\\' && input[i + 1] == 'u' && !IsHexNumber(input.Substring(i + 1)))
                {
                    return false;
                }
            }

            return input.LastIndexOf('\\') + 1 != input.Length - 1;
        }

        private static bool IsHexNumber(string input)
        {
            const int lengthHex = 5;
            if (input.Length < lengthHex)
            {
                return false;
            }

            for (int i = 1; i < lengthHex; i++)
            {
                if (!IsHexDigit(input[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsHexDigit(char c)
        {
            return char.IsAsciiHexDigit(c);
        }

        private static bool IsControlCharacter(char character)
        {
            const int asciiSpace = 32;
            return character < asciiSpace;
        }

        private static bool IsExcapeCharacter(char character)
        {
            const string excapeCharacter = @"u\0btnrf""";
            return excapeCharacter.Contains(character);
        }
    }
}
