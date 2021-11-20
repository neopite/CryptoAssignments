using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.FirstTask
{
    public class XORAttacker
    {
        private string encryptedText;

        public XORAttacker(string encryptedText)
        {
            this.encryptedText = encryptedText;
        }

        public string DecryptTextByDefaultXOR(byte key)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < encryptedText.Length / 2; i += 2)
            {
                int intvalue = Convert.ToInt32(encryptedText.Substring(i, 2), 16);
                int value = (byte) intvalue ^ key;
                builder.Append((char) value + " ");
            }

            return builder.ToString();
        }

        public static string Decrypt(byte key, string text)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                builder.Append((char)(text[i] ^ key));
            }

            return builder.ToString();
        }

        public string DecryptTextByRepetativeKeyXOR(string key)
        {
            int keyPointer = 0;
            var sb = new StringBuilder();
            for (int i = 0; i < encryptedText.Length / 2; i += 2)
            {
                int intvalue = Convert.ToInt32(encryptedText.Substring(i, 2), 16);
                int value = (byte) intvalue ^ key.ToCharArray()[keyPointer];
                sb.Append((char) value + " ");
                keyPointer++;
                if (keyPointer == key.Length - 1)
                {
                    keyPointer = 0;
                }
            }

            return sb.ToString();
        }
    }
}