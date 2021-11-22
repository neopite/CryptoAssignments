using System;
using System.Collections.Generic;

namespace Lab4.Resources
{
    public class PseudoRandomPasswordGenerator
    {
        private const int validCharFrom = 33;
        private const int validCharTo = 122;

        private Dictionary<char[], char[]> translitSymbols = new Dictionary<char[], char[]>()
        {
            {new[] {'o', 'O'}, new[] {'0'}},
            {new[] {'i', 'I'}, new[] {'1', '!', 'l'}},

        };

        public static string GenerateRandomPassword(int fromSymbolsCount, int toSymbolsCount)
        {
            var random = new Random();
            var symbolsCount = random.Next(fromSymbolsCount, toSymbolsCount);

            char[] chars = new char[symbolsCount];
            for (int i = 0; i < symbolsCount; i++)
            {
                chars[i] = (char) random.Next(validCharFrom, validCharTo);
            }

            return new string(chars);
        }

        public string[] GenerateRandomPasswords(int count)
        {
            var passwords = new List<string>();
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                passwords.Add(GenerateRandomPassword(3,15));
            }

            return passwords.ToArray();
        }
    }
}