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
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '\\' && (!IsExcapeCharacter(input[i + 1]) || i + 1 == input.Length - 1))
                {
                    if (i > 0 && input[i - 1] == '\\')
                    {
                        continue;
                    }

                    return false;
                }
            }

            return ContainsHexNumber(input);
        }

        private static bool ContainsHexNumber(string input)
        {
            if (input.LastIndexOf('u') == -1 || input[input.LastIndexOf('u') - 1] != '\\')
            {
                return true;
            }

            return IsHexNumber(input.Substring(input.LastIndexOf('u')));
        }

        private static bool IsHexNumber(string input)
        {
            const int lengthHex = 4;
            if (input.Length > lengthHex + 1) // check if the hex number is at the end of the string
            {
                return true;
            }

            for (int i = 1; i < input.Length; i++)
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
            return Uri.IsHexDigit(c);
        }

        private static bool IsControlCharacter(char character)
        {
            const string controlCharacter = "\0\b\t\n\r";
            return controlCharacter.Contains(character);
        }

        private static bool IsExcapeCharacter(char character)
        {
            const string excapeCharacter = @"u\/0btnrf""";
            return excapeCharacter.Contains(character);
        }
    }
}
