using System.Text;

namespace Lab4
{
    public class Util
    {
        public static string GetPathInProject(string path)
        {
            return $"../../../{path}";
        }

        public static string ToStringByteArray(byte[] array)
        {
            var sb = new StringBuilder();
            foreach (var b in array)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
        
    }
}