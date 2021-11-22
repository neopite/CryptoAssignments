using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab4.Resources
{
    public class PseudoRandomPasswordGenerator
    {
        private const int validCharFrom = 33;
        private const int validCharTo = 122;


        private static string GenerateRandomPassword(int fromSymbolsCount, int toSymbolsCount)
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

        public static List<string> GetCommonPasswords(int count)
        {
            var passwords = File
                .ReadAllLines(@"C:\Users\Stami\RiderProjects\Crypto\Lab4\Resources\million-of-common-passwords.txt")
                .ToList();
            return passwords.TakeLast(count).ToList();
        }

        public static List<string> GetTopPasswords(int count)
        {
            var passwords = File
                .ReadAllLines(@"C:\Users\Stami\RiderProjects\Crypto\Lab4\Resources\top-100-common-passwords.txt")
                .ToList();
            return passwords.TakeLast(count).ToList();
        }


        public static string[] GenerateRandomPasswords(int count)
        {
            var passwords = new List<string>();
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                passwords.Add(GenerateRandomPassword(3, 15));
            }

            return passwords.ToArray();
        }
    }
}