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
                "C:\\Users\\Stami\\RiderProjects\\Crypto\\Lab4\\Resources\\ResultHashedPasswords\\hashing-passwords1.csv",
                new List<string>() {"hash"});

            CSVCreator csv1 =
                new CSVCreator(
                    "C:\\Users\\Stami\\RiderProjects\\Crypto\\Lab4\\Resources\\ResultHashedPasswords\\hashing-passwords2.csv",
                    new List<string>() {"hash"});
            
            CSVCreator csv2 =
                new CSVCreator(
                    "C:\\Users\\Stami\\RiderProjects\\Crypto\\Lab4\\Resources\\ResultHashedPasswords\\hashing-passwords3.csv",
                    new List<string>() {"hash", "salt"});
            var topPasswords = PseudoRandomPasswordGenerator.GetTopPasswords(20);
            var commonPasswordsList = PseudoRandomPasswordGenerator.GetCommonPasswords(1000);
            var random = PseudoRandomPasswordGenerator.GenerateRandomPasswords(1000);
            var smashedList = topPasswords.Concat(commonPasswordsList).Concat(random).ToList();
            for (int i = 0; i < smashedList.Count; i++)
            {
                var hash = PasswordEncrypter.HashByMD5(smashedList[i]);
            }

            for (int i = 0; i < smashedList.Count; i++)
            {
                var hash = PasswordEncrypter.HashBySHA256(smashedList[i]);
                csv1.AddRow(new List<string>() {hash});
            }
            
            for (int i = 0; i < smashedList.Count; i++)
            {
                var saltProvider = new SaltProvider();
                var salt = saltProvider.GenerateSalt();
                var hash = PasswordEncrypter.HashByArgon2(smashedList[i],salt);
                csv2.AddRow(new List<string>() {hash});
            }
        }
    }
}