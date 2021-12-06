using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2
{
    class Program
    {
        public static List<string> CreateDuplets(string str)
        {
            var result = new List<string>();
            for (int i = 0; i < str.Length; i++)
            {
                if (i % 2 == 0 && i < str.Length - 1)
                {
                    result.Add($"{str[i]}{str[i + 1]}");
                }
            }

            return result;
        }

        public static string MakeXor(string byte_str1, string byte_str2)
        {
            var byte1 = Convert.ToInt32(byte_str1, 16);
            var byte2 = Convert.ToInt32(byte_str2, 16);
            var xorBytes = (byte) (byte1 ^ byte2);
            return xorBytes.ToString("X").PadLeft(2, '0');
        }

        public static string Xor(List<string> arr1, List<string> arr2)
        {
            var numbersAndWords = arr1.Zip(
                arr2, (byte_str1, byte_str2) => MakeXor(byte_str1, byte_str2));
            return String.Join("", numbersAndWords.ToArray());
        }

        public static List<string> GetXors(List<string> duplets1, List<string> duplets2)
        {
            var result = new List<string>();
            for (int i = 0; i < duplets1.Count - duplets2.Count + 1; i++)
            {
                var xor = Xor(duplets1.GetRange(i, duplets2.Count), duplets2).ToList();
                result.Add(String.Join("", xor.ToArray()));
            }

            return result;
        }

        public static string GetResult(List<string> array)
        {
            var sb = new StringBuilder();
            foreach (var line in array)
            {
                sb.Append(String.Join("",Convert.FromHexString(line).Select(x => Convert.ToChar(x))));
            }
            return sb.ToString();

        }

        static void Main(string[] args)
        {
            var str1_ciphered =
                "280dc9e47f3352c307f6d894ee8d534313429a79c1d8a6021f8a8eabca919cfb685a0d468973625e757490daa981ea6b";
            var str2_ciphered = "2f0cdfe464344e8650edc59daac3504b1710d56b89dce5011e8c90f6";

            var supposedWord = "And lose the name of action.";

            var result1 = CreateDuplets(str1_ciphered);
            var result2 = CreateDuplets(str2_ciphered);

            var xorCipheredStrings = Xor(result1, result2);

            var duplets1 = CreateDuplets(xorCipheredStrings);
            var duplets2 = CreateDuplets(Convert.ToHexString(Encoding.UTF8.GetBytes(supposedWord)));

            var array = GetXors(duplets1, duplets2);

            var result = GetResult(array);
            Console.WriteLine(result);
        }
    }
}