using System;
using System.Collections.Generic;

namespace Console_Serep
{
    class ReadedReport
    {
        public List<Report> Items { get; set; }

        public void Sorter()
        {
            List<Report> sorted = new();
            DateTime d = new();
            for (int i = 0; i < Items.Count; i++)
            {
                d = new();
                for (int j = 0; j < Items.Count; j++)
                {
                    if (sorted.Contains(Items[j]))
                        continue;
                    else
                        d = d > Items[j].Date ? d : Items[j].Date;
                }

                foreach (var item in Items)
                {
                    if (sorted == null)
                        sorted = new List<Report>();
                    if (item.Date == d)
                    {
                        sorted.Add(item);
                        break;
                    }
                }
            }
            Items = sorted;
        }

        public void Counter(string count)
        {
            int year = Convert.ToInt32(count[0..4]);
            int pub = 0;
            int video = 0;
            int hour = 0;
            int minute = 0;
            int pp = 0;
            int study = 0;
            if (count.Length > 4)
            {
                int month = 0;
                    month = Convert.ToInt32(count[5..7]);
                foreach (var item in Items)
                {
                    if (item.Date.Year == year)
                    {
                        if (item.Date.Month == month)
                        {
                            pub += item.Publication;
                            video += item.Video;
                            hour += item.Hour;
                            minute += item.Minute;
                            pp += item.Pp;
                            study += item.Study;
                        }
                    }
                    else
                        continue;
                }
            }
            else
            {
                foreach (var item in Items)
                {
                    if (item.Date.Year == year)
                    {
                            pub += item.Publication;
                            video += item.Video;
                            hour += item.Hour;
                            minute += item.Minute;
                            pp += item.Pp;
                            study += item.Study;
                    }
                    else
                        continue;
                }
            }
            if(minute >= 60)
            {
                hour += Convert.ToInt32(Math.Floor(Convert.ToDecimal(minute) / 60));
                minute %= 60;
            }
            Console.WriteLine(pub + " - " + video + " - " + hour + ":" + minute + " - " + pp + " - " + study);
        }
    }
}
