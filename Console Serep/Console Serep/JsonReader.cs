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
            DateTime d;
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

        public List<int> Search(string date)
        {
            int year = Convert.ToInt32(date[0..4]);
            int month = 0;
            int day = 0;
            int hour = 0;
            int minute = 0;
            int second = 0;
            List<int> id = new();
            try
            {
                month = Convert.ToInt32(date[5..7]);
                day = Convert.ToInt32(date[8..10]);
                hour = Convert.ToInt32(date[11..13]);
                minute = Convert.ToInt32(date[14..16]);
                second = Convert.ToInt32(date[17..19]);
            }
            catch
            {
                try
                {
                    month = Convert.ToInt32(date[5..7]);
                    day = Convert.ToInt32(date[8..10]);
                    hour = Convert.ToInt32(date[11..13]);
                    minute = Convert.ToInt32(date[14..16]);
                }
                catch
                {
                    try
                    {
                        month = Convert.ToInt32(date[5..7]);
                        day = Convert.ToInt32(date[8..10]);
                        hour = Convert.ToInt32(date[11..13]);
                    }
                    catch
                    {
                        try
                        {
                            month = Convert.ToInt32(date[5..7]);
                            day = Convert.ToInt32(date[8..10]);
                        }
                        catch
                        {
                            try
                            {
                                month = Convert.ToInt32(date[5..7]);
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            }

            switch (date.Length)
            {
                case 4:
                    for (int i = 0; i < Items.Count; i++)
                    {
                        if (Items[i].Date.Year == year)
                            id.Add(i);
                    }
                    break;

                case 7:
                    for (int i = 0; i < Items.Count; i++)
                    {
                        if (Items[i].Date.Year == year && Items[i].Date.Month == month)
                            id.Add(i);
                    }
                    break;

                case 10:
                    for (int i = 0; i < Items.Count; i++)
                    {
                        if (Items[i].Date.Year == year && Items[i].Date.Month == month && Items[i].Date.Day == day)
                            id.Add(i);
                    }
                    break;

                case 13:
                    for (int i = 0; i < Items.Count; i++)
                    {
                        if (Items[i].Date.Year == year && Items[i].Date.Month == month && Items[i].Date.Day == day && Items[i].Date.Hour == hour)
                            id.Add(i);
                    }
                    break;

                case 16:
                    for (int i = 0; i < Items.Count; i++)
                    {
                        if (Items[i].Date.Year == year && Items[i].Date.Month == month && Items[i].Date.Day == day && Items[i].Date.Hour == hour && Items[i].Date.Minute == minute)
                            id.Add(i);
                    }
                    break;

                case 19:
                    for (int i = 0; i < Items.Count; i++)
                    {
                        if (Items[i].Date.Year == year && Items[i].Date.Month == month && Items[i].Date.Day == day && Items[i].Date.Hour == hour && Items[i].Date.Minute == minute && Items[i].Date.Second == second)
                            id.Add(i);
                    }
                    break;

                default:
                    break;
            }

            return id;
        }

        public void Counter(string date)
        {
            int pub = 0;
            int video = 0;
            int hour = 0;
            int minute = 0;
            int pp = 0;
            int study = 0;

            for (int i = 0; i < Items.Count; i++)
            {
                if (Search(date).Contains(i))
                {
                    pub += Items[i].Publication;
                    video += Items[i].Video;
                    hour += Items[i].Hour;
                    minute += Items[i].Minute;
                    pp += Items[i].Pp;
                    study += Items[i].Study;
                }
            }
            
            if(minute >= 60)
            {
                hour += Convert.ToInt32(Math.Floor(Convert.ToDecimal(minute) / 60));
                minute %= 60;
            }
            Console.WriteLine(pub + " - " + video + " - " + hour + ":" + minute + " - " + pp + " - " + study);
        }

        public void Delete(string date)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Search(date).Contains(i))
                    Items.Remove(Items[i]);
            }
        }
    }
}
