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
            var topPasswords = PseudoRandomPasswordGenerator.GetTopPasswords(100);
            var commonPasswordsList = PseudoRandomPasswordGenerator.GetCommonPasswords(100000);
            var random = PseudoRandomPasswordGenerator.GenerateRandomPasswords(50000);
            var smashedList = topPasswords.Concat(commonPasswordsList).Concat(random).ToList();
            for (int i = 0; i < smashedList.Count; i++)
            {
                var hash = PasswordEncrypter.HashByMD5(smashedList[i]);
                csv1.AddRow(new List<string>(){hash});
            }
            
            for (int i = 0; i < smashedList.Count; i++)
            {
                var hash = PasswordEncrypter.HashBySHA256(smashedList[i]);
                csv1.AddRow(new List<string>() {hash});
            }
            
            for (int i = 0; i < smashedList.Count; i++)
            {
                var saltProvider = new SaltProvider();
                var salt = saltProvider.GenerateSalt(8);
                var hash = PasswordEncrypter.HashByArgon2(smashedList[i],salt);
                csv2.AddRow(new List<string>() {hash,Convert.ToBase64String(salt)});
            }
        }
    }
}