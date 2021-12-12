using System;
using System.Text;

namespace Lab4
{
    public class NumberPatternGenerator
    {
        public string GetRandomNumberPattern()
        {
            var sb = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < new Random().Next(7); i++)
            {
                sb.Append(random.Next(10));
            }

            return sb.ToString();
        }
    }
}