using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using Lab1.FirstTask;

namespace Lab1
{
    class Program
    {
        private static string filePath = "C:\\Users\\Stami\\RiderProjects\\Crypto\\Lab1\\Resources\\lab1.txt";

        private static string firstTask =
            "7958401743454e1756174552475256435e59501a5c524e176f786517545e475f5245191772195019175e4317445f58425b531743565c521756174443455e595017d5b7ab5f525b5b58174058455b53d5b7aa175659531b17505e41525917435f52175c524e175e4417d5b7ab5c524ed5b7aa1b174f584517435f5217515e454443175b524343524517d5b7ab5fd5b7aa17405e435f17d5b7ab5cd5b7aa1b17435f5259174f584517d5b7ab52d5b7aa17405e435f17d5b7ab52d5b7aa1b17435f525917d5b7ab5bd5b7aa17405e435f17d5b7ab4ed5b7aa1b1756595317435f5259174f58451759524f4317545f564517d5b7ab5bd5b7aa17405e435f17d5b7ab5cd5b7aa175650565e591b17435f525917d5b7ab58d5b7aa17405e435f17d5b7ab52d5b7aa1756595317445817585919176e5842175a564e17424452175659175e5953524f1758511754585e59545e53525954521b177f565a5a5e595017535e4443565954521b177c56445e445c5e17524f565a5e5956435e58591b17444356435e44435e54565b17435244434417584517405f564352415245175a52435f5853174e5842175152525b174058425b5317445f584017435f52175552444317455244425b4319";

        private static string secondTask =
            "G0IFOFVMLRAPI1QJbEQDbFEYOFEPJxAfI10JbEMFIUAAKRAfOVIfOFkYOUQFI15ML1kcJFUeYhA4IxAeKVQZL1VMOFgJbFMDIUAAKUgFOElMI1ZMOFgFPxADIlVMO1VMO1kAIBAZP1VMI14ANRAZPEAJPlMNP1VMIFUYOFUePxxMP19MOFgJbFsJNUMcLVMJbFkfbF8CIElMfgZNbGQDbFcJOBAYJFkfbF8CKRAeJVcEOBANOUQDIVEYJVMNIFwVbEkDORAbJVwAbEAeI1INLlwVbF4JKVRMOF9MOUMJbEMDIVVMP18eOBADKhALKV4JOFkPbFEAK18eJUQEIRBEO1gFL1hMO18eJ1UIbEQEKRAOKUMYbFwNP0RMNVUNPhlAbEMFIUUALUQJKBANIl4JLVwFIldMI0JMK0INKFkJIkRMKFUfL1UCOB5MH1UeJV8ZP1wVYBAbPlkYKRAFOBAeJVcEOBACI0dAbEkDORAbJVwAbF4JKVRMJURMOF9MKFUPJUAEKUJMOFgJbF4JNERMI14JbFEfbEcJIFxCbHIJLUJMJV5MIVkCKBxMOFgJPlWOzKkfbF4DbEMcLVMJPx5MRlgYOEAfdh9DKF8PPx4LI18LIFVCL18BY1QDL0UBKV4YY1RDfXg1e3QAYQUFOGkof3MzK1sZKXIaOnIqPGRYD1UPC2AFHgNcDkMtHlw4PGFDKVQFOA8ZP0BRP1gNPlkCKw==";

        private static byte[] encodedSecondTask = Convert.FromBase64String(secondTask);
        static string decodedString = Encoding.UTF8.GetString(encodedSecondTask);

        static void Main(string[] args)
        {
            var xorAttacker = new XORAttacker(firstTask);
            for (byte i = 0; i < 255; i++)
            {
                Console.WriteLine(i+ "======================================");
                Console.WriteLine(xorAttacker.DecryptTextByDefaultXOR(i));
            }
        }

        private static void SolveFirstTask()
        {
            var xorAttacker = new XORAttacker(firstTask);
            for (byte i = 0; i < 255; i++)
            {
                Console.WriteLine(i+ "======================================");
                Console.WriteLine(xorAttacker.DecryptTextByDefaultXOR(i));
            }
        }


        private static void SolveSecondTask()
        {
            var xorAttacker = new XORAttacker(GetPrefarableText(3, 1));
            var every2LetterLine = GetPrefarableText(3, 2);
            var every0LetterLine = GetPrefarableText(3, 0);
            var every1LetterLine = GetPrefarableText(3, 1);
            string decrypted = XORAttacker.Decrypt(76, every0LetterLine);
            string decrypted1 = XORAttacker.Decrypt(16, every1LetterLine);
            string decrypted2 = XORAttacker.Decrypt(108, every2LetterLine);
            //Console.WriteLine(everyThirdLetterLine);
            var builder = new StringBuilder();
            for (var i = 0; i < decrypted.Length; i++)
            {
                builder.Append(decrypted[i].ToString() + decrypted1[i].ToString() + decrypted2[i].ToString());
            }

            Console.WriteLine(builder.ToString());
        }

        public static string GetPrefarableText(int keyLength, int offset)
        {
            var sb = new StringBuilder();
            for (int j = 0; j < decodedString.Length / 3; j++)
            {
                sb.Append(decodedString[j * keyLength + offset]);
            }

            return sb.ToString();
        }

        public static void GetLetterFrequences()
        {
            Dictionary<char, int> frequences = new Dictionary<char, int>();
            for (int i = 0; i < decodedString.Length; i++)
            {
                if (frequences.ContainsKey(decodedString[i]))
                {
                    frequences[decodedString[i]]++;
                }
                else frequences.TryAdd(decodedString[i], 0);
            }

            var sortedDict = from entry in frequences orderby entry.Value ascending select entry;
            foreach (var keyValuePair in sortedDict)
            {
                Console.WriteLine(keyValuePair.Key + " = " + keyValuePair.Value);
            }
        }

        public static void WriteIndexesOfCoincidence(int maxOffset)
        {
            for (int i = 1; i < maxOffset; i++)
            {
                double indexCoincidence = 0;
                for (int j = 0; j < decodedString.Length; j++)
                {
                    if (j + i >= decodedString.Length)
                    {
                        break;
                    }

                    if (decodedString[j] == decodedString[i + j])
                    {
                        Console.WriteLine(decodedString[j]);
                        indexCoincidence++;
                    }
                }

                Console.WriteLine("Shifted on : " + i + " , index of Coincidence  = " + indexCoincidence);
            }
        }

        public static string ShiftString(string str, int offset)
        {
            return str.Substring(str.Length - offset, offset) + str.Substring(0, str.Length - offset);
        }


        private void DecypherSecondTask()
        {
            var xor = new XORAttacker(
                "7958401743454e1756174552475256435e59501a5c524e176f786517545e475f5245191772195019175e4317445f58425b531743565c521756174443455e595017d5b7ab5f525b5b58174058455b53d5b7aa175659531b17505e41525917435f52175c524e175e4417d5b7ab5c524ed5b7aa1b174f584517435f5217515e454443175b524343524517d5b7ab5fd5b7aa17405e435f17d5b7ab5cd5b7aa1b17435f5259174f584517d5b7ab52d5b7aa17405e435f17d5b7ab52d5b7aa1b17435f525917d5b7ab5bd5b7aa17405e435f17d5b7ab4ed5b7aa1b1756595317435f5259174f58451759524f4317545f564517d5b7ab5bd5b7aa17405e435f17d5b7ab5cd5b7aa175650565e591b17435f525917d5b7ab58d5b7aa17405e435f17d5b7ab52d5b7aa1756595317445817585919176e5842175a564e17424452175659175e5953524f1758511754585e59545e53525954521b177f565a5a5e595017535e4443565954521b177c56445e445c5e17524f565a5e5956435e58591b17444356435e44435e54565b17435244434417584517405f564352415245175a52435f5853174e5842175152525b174058425b5317445f584017435f52175552444317455244425b4319");
            Console.WriteLine(xor.DecryptTextByDefaultXOR(55));
        }

        private string GetPreviewText()
        {
            string allLines = File.ReadAllText(filePath);
            Console.WriteLine(allLines.Length / 8);
            return BitsToChar(allLines);
        }


        private static Char ConvertToChar(String value)
        {
            int result = 0;

            foreach (Char ch in value)
                result = result * 2 + ch - '0';

            return (Char) result;
        }

        public static string BitsToChar(string value)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            StringBuilder Sb = new StringBuilder();

            for (int i = 0; i < value.Length / 8; ++i)
                Sb.Append(ConvertToChar(value.Substring(8 * i, 8)));

            return Sb.ToString();
        }
    }
}