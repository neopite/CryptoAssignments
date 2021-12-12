using System;
using System.Collections.Generic;
using System.Linq;
using Lab4.Resources;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVCreator csv = new CSVCreator(
                Util.GetPathInProject("Resources\\ResultHashedPasswords\\hashing-passwords1.csv"),
                new List<string>() {"hash"});

            CSVCreator csv1 =
                new CSVCreator(
                    Util.GetPathInProject("Resources\\ResultHashedPasswords\\hashing-passwords2.csv"),
                    new List<string>() {"hash"});
            
            CSVCreator csv2 =
                new CSVCreator(
                    Util.GetPathInProject("Resources\\ResultHashedPasswords\\hashing-passwords3.csv"),
                    new List<string>() {"hash", "salt"});
            var topPasswords = PseudoRandomPasswordGenerator.GetTopPasswords(100);
            var commonPasswordsList = PseudoRandomPasswordGenerator.GetCommonPasswords(100000);
            var random = PseudoRandomPasswordGenerator.GenerateRandomPasswords(10000);
            var randomNumberSequence = PseudoRandomPasswordGenerator.GenerateRandomNumberSequence(4500);
            var randomNamesWithNumbers = PseudoRandomPasswordGenerator.GenerateUserWithNumbersPasswordPattern(5000);
            var firstNames = PseudoRandomPasswordGenerator.GenerateRandomName(2500);
            var smashedList = new List<string>();
            smashedList.AddRange(topPasswords);
            smashedList.AddRange(commonPasswordsList);
            smashedList.AddRange(random);
            smashedList.AddRange(randomNumberSequence);
            smashedList.AddRange(randomNamesWithNumbers);
            smashedList.AddRange(firstNames);
            for (int i = 0; i < smashedList.Count; i++)
            {
                var hash = PasswordEncrypter.HashByMD5(smashedList[i]);
                Console.WriteLine(hash);
                csv.AddRow(new List<string>(){hash});
            }
            
            for (int i = 0; i < smashedList.Count; i++)
            {
                var hash = PasswordEncrypter.HashBySHA256(smashedList[i]);
                csv1.AddRow(new List<string>() {hash});
            }
            
            for (int i = 0; i < smashedList.Count; i++)
            {
                var saltProvider = new SaltProvider();
                var salt = saltProvider.GenerateSalt(32);
                var hash = PasswordEncrypter.HashByArgon2(smashedList[i],salt);
                csv2.AddRow(new List<string>() {hash,Util.ToStringByteArray(salt)});
            }
        }
    }
}