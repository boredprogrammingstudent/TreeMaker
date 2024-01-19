using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMaker.Utils
{
    static class FileReader
    {
        public static void ReadFile(string path, Action<string, string> callback)
        {
            const char CONTROL = ':';
            StreamReader sr = new(path);
            string? firstLine = sr.ReadLine();
            if(firstLine == null)
            {
                sr.Close();
                return;
            }
            string? nextLine = firstLine ?? string.Empty;
            do
            {
                string input1 = string.Empty;
                string input2 = string.Empty;
                char? curr = CONTROL;
                int i = 0;
                do
                {
                    input1 += curr == CONTROL ? string.Empty : curr;
                    curr = nextLine[i++];
                } while (curr != ':' && i != nextLine.Length);
                do
                {
                    input2 += curr == CONTROL ? string.Empty : curr;
                    curr = nextLine[i++];
                } while (curr != ':' && i != nextLine.Length);
                callback(input1, input2);
                nextLine = sr.ReadLine();
            } while (nextLine != null);
            sr.Close();
        }
    }
}
