using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.ParseLogFile(@"C:\Users\Petr_Chebanenko\Documents\Visual Studio 2012\Projects\Task\MvcMusicStore\logs\2018-04-18.log");
            PrintResults();
            Console.ReadKey();
        }

        public static void PrintResults()
        {
            var typeCounts = Parser.counts;
            
            Console.WriteLine("Результаты парсинга лог файла");
            foreach(var type in typeCounts)
            {
                Console.WriteLine(string.Format("Тип записи в лог {0}, количество записей {1}",
                    type.Key, type.Value.ToString()));
            }

            if (typeCounts["ERROR"] != 0)
            {
                foreach (var er in Parser.errors)
                {
                    Console.WriteLine("Ошибка записалась в лог " + er);
                }
            }
        }
    }
}
