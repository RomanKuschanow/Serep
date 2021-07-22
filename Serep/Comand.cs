using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serep
{
    class Comand
    {
        private static string[,] comands = { {"/add", "/count", "/del", "/help", "/rep", "/search", "/show" }, {"добавляет введенный отчет на указанную дату.", "подсчитывает все очеты в указанном диапазоне", "удаляет выбранные записи", "выводит список всех команд", "добавляет отчет на текущую дату", "ищет все отчеты в указанном диапазоне", "выводит список всех отчетов"}};

        public static void Help()
        {
            for (int i = 0; i < comands.Length / 2; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(comands[0,i]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" - " + comands[1, i] + "\n");
            }
        }
    }
}
