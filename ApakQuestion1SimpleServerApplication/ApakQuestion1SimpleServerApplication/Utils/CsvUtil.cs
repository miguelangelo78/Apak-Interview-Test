using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApakQuestion1SimpleServerApplication.Utils
{
    public class CsvUtil
    {
        public static string[] readAllLinesFromFile(string filepath)
        {
            return File.Exists(filepath) ? File.ReadAllLines(filepath) : new string[0];
        }

        public static void appendObjectToFile<T>(string filePath, T obj)
        {
            File.AppendAllText(filePath, obj.ToString() + Environment.NewLine);
        }

        public static void deleteRowFromFile(string filePath, int index)
        {
            if(index <= 0)
            {
                return;
            }

            List<string> rows = readAllLinesFromFile(filePath).ToList();

            for(int i = 0; i < rows.Count; i++)
            {
                if(int.Parse(rows[i].Split(",")[0]) == index)
                {
                    rows.RemoveAt(i);
                    break;
                }
            }

            using (TextWriter textWriter = new StreamWriter(filePath))
            {
                foreach (string s in rows)
                {
                    textWriter.WriteLine(s);
                }
            }
        }
    }
}
