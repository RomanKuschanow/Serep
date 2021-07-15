using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Console_Serep
{
    class Program
    {
        static void Main()
        {
            ReadedReport json = File.Exists("report.json") ? JsonConvert.DeserializeObject<ReadedReport>(File.ReadAllText("report.json")) : new ReadedReport();

            Console.WriteLine("Вас приветствует прграмма Serep, удобное хранилище и калькулятор ваших отчетов о служении.\n" +
                "Для того чтобы продолжить напишите /rep и введите отчет в формате: 00 00 00:00 00 00\n" +
                "где первые и последние два нуля - это публикации, видео, п/п и изучения соответсвенно, а центральные 4 - часи.\n" +
                "В подавляющем большинстве случаев за один раз двузначная цифра в отчете не появляеться, но часы, как и минуты, стоит записывать с первым нулем, например: 01:05\n" +
                "Для более подробной информации напишите /help");
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "/rep":
                        Console.WriteLine("Введите отчет в формате 00 00 00:00 00 00");
                        string rep = Console.ReadLine();
                        if (json.Items == null)
                            json.Items = new List<Report>();
                        json.Items.Add(new Converter(rep).Report);
                        File.WriteAllText("report.json", JsonConvert.SerializeObject(json));
                        break;

                    case "/show":
                        Console.WriteLine("№ - Дата - публикации - видео - часы - п/п - изучения \n");
                        json.Items.Reverse();   
                        int i = 0;
                        foreach (Report j in json.Items)
                        {
                            i++;
                            Console.WriteLine(i + ") " + j.Date + " - " + j.Publication + " - " + j.Video + " - " + j.Hour + ':' + j.Minute + " - " + j.Pp + " - " + j.Study);
                        }
                        json.Items.Reverse();
                        break;

                    default:
                        Console.WriteLine("Такой команды не предусмотренно, попробуйте ввести другую или проверить наличие опечаток");
                        break;
                }
            }
        }
    }
}
