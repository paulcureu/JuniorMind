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
                else if (input[i] == '\\' && IsExcapeCharacter(input[i + 1]))
                {
                    return true;
                }
                else if (input[i] == '\\' && !IsExcapeCharacter(input[i + 1]))
                {
                    return false;
                }
            }

            return true;
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
