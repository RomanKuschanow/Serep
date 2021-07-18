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
            ReadedReport json;

            try
            {
                json = File.Exists("report.json") ? JsonConvert.DeserializeObject<ReadedReport>(File.ReadAllText("report.json")) : new ReadedReport();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!!!Файл поврежден, чтение не возможно. Будет создан новый файл. Поврежденный вы можете найти в папке с программой под именем 'destroyed'");
                File.Move("report.json", "destroyed.json");
                json = new();
            }

            try
            {
                json.Sorter();
            }
            catch
            {

            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Вас приветствует прграмма Serep, удобное хранилище и калькулятор ваших отчетов о служении.\n" +
                "Для того чтобы продолжить напишите /rep и введите отчет в формате: 0 0 0:0 0 0\n" +
                "где первые и последние два нуля - это публикации, видео, п/п и изучения соответсвенно, а центральные 2 - часи.\n" +
                "Для более подробной информации о списке команд напишите /help");
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                bool retry;
                switch (Console.ReadLine())
                {
                    case "/rep":
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Введите отчет в формате 0 0 0:0 0 0");
                        retry = true;
                        while (retry)
                        {
                            try
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                string rep = Console.ReadLine();
                                if (json.Items == null)
                                    json.Items = new List<Report>();
                                json.Items.Add(new Converter(rep).Report);
                                File.WriteAllText("report.json", JsonConvert.SerializeObject(json));
                                retry = false;
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Возникло исключение, возможно параметры были введены не правильно");
                            }
                        }
                        break;

                    case "/show":
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("№ - Дата - публикации - видео - часы - п/п - изучения \n");
                        retry = true;
                        while (retry)
                        {
                            try
                            {
                                json.Sorter();
                                int i = 0;
                                foreach (Report j in json.Items)
                                {
                                    i++;
                                    Console.WriteLine(i + ") " + j.Date + " - " + j.Publication + " - " + j.Video + " - " + j.Hour + ':' + j.Minute + " - " + j.Pp + " - " + j.Study);
                                }
                                retry = false;
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Возникло исключение, возможно параметры были введены не правильно");
                                retry = false;
                            }
                        }
                        break;

                    case "/add":
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Введите отчет в формате 0 0 0:0 0 0");
                        retry = true;
                        while (retry)
                        {
                            try
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                string _rep = Console.ReadLine();
                                string date = Console.ReadLine();
                                if (json.Items == null)
                                    json.Items = new List<Report>();
                                json.Items.Add(new Converter(_rep, date).Report);
                                File.WriteAllText("report.json", JsonConvert.SerializeObject(json));
                                retry = false;
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Возникло исключение, возможно параметры были введены не правильно");
                            }
                        }
                        break;

                    case "/count":
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Введите год, месяц и день за которые надо посчитать отчет");
                        retry = true;
                        while (retry)
                        {
                            try
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                string date = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.White;
                                json.Counter(date);
                                retry = false;
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Возникло исключение, возможно параметры были введены не правильно");
                            }
                        }
                        break;

                    case "/search":
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Ведите дату для поиска в формате год-месяц-число-час-минута-секунда: 0000 00 00 00 00 00");
                        retry = true;
                        while (retry)
                        {
                            try
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                json.Sorter();
                                string date = Console.ReadLine();
                                int i = 0;
                                Console.ForegroundColor = ConsoleColor.White;
                                foreach (var j in json.Search(date))
                                {
                                    i++;
                                    Console.WriteLine(i + ") " + json.Items[j].Date + " - " + json.Items[j].Publication + " - " + json.Items[j].Video + " - " + json.Items[j].Hour + ':' + json.Items[j].Minute + " - " + json.Items[j].Pp + " - " + json.Items[j].Study);
                                }
                                retry = false;
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Возникло исключение, возможно параметры были введены не правильно");
                            }
                        }
                        break;

                    case "/del":
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Ведите дату для удаления в формате год-месяц-число-час-минута-секунда: 0000 00 00 00 00 00");
                        retry = true;
                        while (retry)
                        {
                            try
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                json.Sorter();
                                string date = Console.ReadLine();
                                int i = 0;
                                Console.ForegroundColor = ConsoleColor.White;
                                foreach (var j in json.Search(date))
                                {
                                    i++;
                                    Console.WriteLine(i + ") " + json.Items[j].Date + " - " + json.Items[j].Publication + " - " + json.Items[j].Video + " - " + json.Items[j].Hour + ':' + json.Items[j].Minute + " - " + json.Items[j].Pp + " - " + json.Items[j].Study);
                                }
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("вы действительно хотите удалить все выше перечисленные записи? y/n");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                if (Console.ReadLine() == "y")
                                {
                                    json.Delete(date);
                                    File.WriteAllText("report.json", JsonConvert.SerializeObject(json));
                                }
                                else if (Console.ReadLine() == "n")
                                retry = false;
                                    break;
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Возникло исключение, возможно параметры были введены не правильно");
                            }
                        }
                        break;

                    case "/help":
                        Comand.Help();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Такой команды не предусмотренно, попробуйте ввести другую или проверить наличие опечаток");
                        break;
                }
            }
        }
    }
}
