using System;
using System.Collections.Generic;
using System.Text;

namespace Domain._01_TDD.Greetings
{
   
    public class StringUtil
    {
        /**
         * Check if all characters of a word is uppercase.
         */
        public static bool IsAllUpper(string word)
        {
            foreach(char character in word)
            {
                if (!char.IsUpper(character))
                {
                    return false;
                }
            }
            return true;
        }
        /**
         * Splits a list of strings into a list of all uppercase characters and not all uppercase characters.
         */
        public static (List<string>, List<string>) SplitNormalCaseAndUpper(List<String> words)
        {

            var normalCase = new List<string>();
            var upperCase = new List<string>();

            foreach(string word in words)
            {
                if (IsAllUpper(word))
                {
                    upperCase.Add(word);
                }
                else
                {
                    normalCase.Add(word);
                }
            }
            return (normalCase, upperCase);
        }

        public static bool HasComma(string word)
        {
            return word.Contains(",");
        }

        public static string[] SplitByComma(string word)
        {
            return word.Split(",");
        }

        public static bool HasQuoteMarks(string word)
        {
           return word.Contains("\"");
        }

    }
}
