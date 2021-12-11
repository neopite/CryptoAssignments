using System;
using System.Collections;
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

        public string DecryptTextByDefaultXOR(int key)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < encryptedText.Length; i += 2)
            {
                var currSymbol = encryptedText.Substring(i, 2);
                int intvalue = Convert.ToInt32(currSymbol, 16);
                int value = intvalue ^ key;
                var charRep = (char) value;
                builder.Append(charRep);
            }

            return builder.ToString();
        }

        public static string Decrypt(byte key, string text)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                builder.Append((char) (text[i] ^ key));
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