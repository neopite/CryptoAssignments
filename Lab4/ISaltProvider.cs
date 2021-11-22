using System.Security.Cryptography;

namespace Lab4
{
    public interface ISaltProvider
    {
        public byte[] GenerateSalt();
    }

    public class SaltProvider : ISaltProvider
    {
        public byte[] GenerateSalt()
        {
            return CreateSalt();
        }

        private byte[] CreateSalt()
        {
            var buffer = new byte[16]; //set salt lenght
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }
    }
}