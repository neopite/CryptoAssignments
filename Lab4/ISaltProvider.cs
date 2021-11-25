using System;
using System.Security.Cryptography;

namespace Lab4
{
    public interface ISaltProvider
    {
        public byte[] GenerateSalt(byte lenght);
    }

    public class SaltProvider : ISaltProvider
    {
        public byte[] GenerateSalt(byte lenght)
        {
            return CreateSalt(lenght);
        }

        private byte[] CreateSalt(byte lenght)
        {
            var buffer = new byte[new Random().Next(2,lenght)]; //set salt lenght
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }
    }
}