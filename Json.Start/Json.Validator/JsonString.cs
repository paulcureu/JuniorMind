using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return HasContent(input) && IsDoubleQuoted(input) && !ContainsControlCharacters(input);
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
    }
}
