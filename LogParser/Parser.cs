using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser
{
    public class Parser
    {
        public static Dictionary<string, int> counts = new Dictionary<string, int>()
        {
            {"INFO", 0},
            {"DEBUG", 0},
            {"ERROR", 0},            
        };

        public static List<string> errors = new List<string>();

        public static void ParseLogFile(string path)
        {

            StreamReader sr = File.OpenText(path);
            if (sr == null)
            {
                return;
            }

            string line;
            while((line = sr.ReadLine()) != null)
            {
                if (line.Contains("INFO"))
                    counts["INFO"] += 1;
                else if (line.Contains("DEBUG"))
                    counts["DEBUG"] += 1;
                else if (line.Contains("ERROR"))
                {
                    errors.Add(line);
                    counts["ERROR"] += 1;
                }
            }
            
        }
    }
}
