using System;
using System.Collections.Generic;

namespace Serep_WPF
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

        public List<int> Search(int year, int month, bool onlyYear)
        {
            List<int> id = new();

            if (onlyYear == true)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].Date.Year == year)
                        id.Add(i);
                }
            }
            else
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].Date.Year == year && Items[i].Date.Month == month)
                        id.Add(i);
                }
            }
                   
            return id;
        }

        public string[] Counter(int year, int month, bool swich, int extra_minutes)
        {
            string strdate;
            int pub = 0;
            int video = 0;
            int hour = 0;
            int minute = 0;
            int pp = 0;
            int study = 0;

            if (swich == true)
                strdate = year.ToString();
            else
            {
                strdate = year.ToString() + '.' + month.ToString();
                minute = extra_minutes;
            }

            for (int i = 0; i < Items.Count; i++)
            {
                if (Search(year, month, swich).Contains(i))
                {
                    pub += Items[i].Publication;
                    video += Items[i].Video;
                    hour += Items[i].Hour;
                    minute += Items[i].Minute;
                    pp += Items[i].Pp;
                    study += Items[i].Study;
                }
            }

            if (minute >= 60)
            {
                hour += Convert.ToInt32(Math.Floor(Convert.ToDecimal(minute) / 60));
                minute %= 60;
            }

            return new string[] { strdate, pub.ToString(), video.ToString(), hour.ToString() + ':' + minute.ToString(), pp.ToString(), study.ToString() };
        }
    }
}
