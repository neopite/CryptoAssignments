using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab4.Resources
{
    public class PseudoRandomPasswordGenerator
    {
        private const int validCharFrom = 33;
        private const int validCharTo = 122;
        private static List<string> firstNamesCached = new List<string>();

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

        public static List<string> GenerateUserWithNumbersPasswordPattern(int count)
        {
            var random = new Random();
            var list = new List<string>();
            if (firstNamesCached.Count == 0)
            {
                firstNamesCached.AddRange(File.ReadAllLines(GetPathInProject("Resources\\first-names.txt")));
            }

            for (int i = 0; i < count; i++)
            {
                var randomName = firstNamesCached[new Random().Next(firstNamesCached.Count - 1)];
                var numberPattern = new NumberPatternGenerator().GetRandomNumberPattern();
                list .Add(randomName.Insert((int) random.Next(randomName.Length), numberPattern));
            }

            return list;

        }

        public static List<string> GenerateRandomNumberSequence(int count)
        {
            var random = new Random();
            var list = new List<string>();
            for (int x = 0; x < count; x++)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < random.Next(6, 15); i++)
                {
                    sb.Append(random.Next(9));
                }

                list.Add(sb.ToString());
            }

            return list;
        }

        public static List<string> GenerateRandomName(int count)
        {
            var random = new Random();
            var list = new List<string>();
            if (firstNamesCached.Count == 0)
            {
                firstNamesCached.AddRange(File.ReadAllLines(GetPathInProject("Resources\\first-names.txt")));
            }

            for (int i = 0; i < count; i++)
            {
                list.Add(firstNamesCached[random.Next(firstNamesCached.Count - 1)]);
            }

            return list;
        }


        public static List<string> GetCommonPasswords(int count)
        {
            var passwords = File
                .ReadAllLines(GetPathInProject("Resources\\million-of-common-passwords.txt"))
                .ToList();
            return passwords.TakeLast(count).ToList();
        }

        public static List<string> GetTopPasswords(int count)
        {
            var passwords = File
                .ReadAllLines(GetPathInProject("Resources\\top-100-common-passwords.txt"))
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

        private static string GetPathInProject(string path)
        {
            return $"../../../{path}";
        }
    }
}