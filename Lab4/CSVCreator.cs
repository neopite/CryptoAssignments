using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4.Resources
{
    public class CSVCreator
    {
        private List<string> headers;
        private string path;

        public CSVCreator(string path, List<string> headers)
        {
            this.headers = headers;
            this.path = path;
            AddRow(headers);
            // savePath = String.Format("Lab4\\Resources\\ResultHashedPasswords\\{0}.csv",fileName);
            // if (File.Exists(savePath))
            // {
            //     File.Delete(savePath);
            // }
            // else CreateEmptyFile(savePath);
        }

        public void AddRow(List<string> newRow)
        {
            using (var file = File.AppendText(path))
            {
                for (int i = 0; i < newRow.Count; i++)
                {
                    if (String.IsNullOrEmpty(newRow[i])) continue;
                    file.Write(newRow[i]);
                    if (i != newRow.Count - 1)
                    {
                        file.Write(',');
                    }
                }

                file.WriteLine();
            }
        }

        public static void CreateEmptyFile(string filename)
        {
            File.Create(filename);
        }
    }
}